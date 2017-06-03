using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using FileProcessor.ViewModel.Interface;
using FileProcessor.ViewModel.Base;
using FileProcessor.Model;
namespace FileProcessor.ViewModel
{
    /// <summary>
    /// ViewModel part of the MWWM pattern, this container is responsible for managing the data translation from Model to View and View to Model.
    /// </summary>
    /// <summary>
    ///     Programmer       : R. Dookkoo.
    ///     Modified Date    : 02 June 2017.
    /// </summary>
    /// <remarks>
    ///     Usage: Used in the Sample application, availabe to use in .Net Framework applications.
    /// </remarks>
       internal class ContactInfoViewModel : IProcessorCommand
    {
        #region Declarations

        #region Declarations - Private
        private const string PrintFileName = @"\sample.txt";
        #endregion

        #region Declarations - Enum
        public enum PrintOptions
        {
            Frequency,
            AddressSort,
            NameList,
            Default
        }
        #endregion

        #region Declaration Public Property for UI View
        public IList<ContactInfo> Records { get; set; } = new List<ContactInfo>();
        #endregion

        #endregion

        #region Public Methods Executed by the View
        public void LoadRecords(string filePath)
        {
            //call generic csvReader to read filestream and pass the data as a memory object
            var resultData = ReadUtil.ReadCsvFile(filePath);

            //populate model based on data returned
            if (resultData.Count <= 0) return;
            foreach (var resultRow in resultData)
            {
                if (resultRow[0] == "FirstName") continue;
                var contact = new ContactInfo();
                for (var i = 0; i < resultRow.Length; i++)
                {
                    if (i == 0) contact.FirstName = resultRow[i];
                    if (i == 1) contact.LastName = resultRow[i];
                    if (i == 2) contact.Address = resultRow[i];
                    if (i == 2) contact.StreetName = Regex.Replace(resultRow[i], "[0-9]", "");
                    if (i == 3) contact.PhoneNumber = resultRow[i];
                }
                Records.Add(contact);
            }
        }

        public void Print(PrintOptions optName)
        {
            //initialize the Print Utility
            var printer = new PrintUtil
            {
                ForceCreation = true,
                PrintFileName = PrintFileName,
                OutputColumns = new List<string>()
            };

            //switch Print View - use linq to order and sort the raw data into various file formats
            switch (optName)
            {
                case PrintOptions.Frequency:
                    printer.OutputColumns.Add("LastName"); printer.OutputColumns.Add("Frequency");
                    printer.PrintList = Records.GroupBy(
                            l => l.LastName,
                            l => l.LastName,
                            (key, g) => new { LastName = key, Frequency = g.Count() }).OrderByDescending(l => l.Frequency);
                    break;

                case PrintOptions.AddressSort:
                    printer.OutputColumns.Add("Address");
                    printer.PrintList = Records.OrderBy(a => a.StreetName);
                    break;

                case PrintOptions.NameList:
                    printer.OutputColumns.Add("FirstName"); printer.OutputColumns.Add("LastName");
                    printer.PrintList = Records.OrderByDescending(o => o.LastName).Select(p => new ContactInfo { FirstName = p.FirstName, LastName = p.LastName }).ToList();
                    break;

                case PrintOptions.Default:
                    printer.OutputColumns.Add("FirstName"); printer.OutputColumns.Add("LastName");
                    printer.OutputColumns.Add("Address"); printer.OutputColumns.Add("PhoneNumber");
                    printer.PrintList = Records;
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(optName), optName, null);
            }
            //call Generic Print based on View
            if (printer.PrintFile())
            {
                Process.Start("notepad.exe", printer.PrintFileName);
            }
        }
        #endregion
    }
}
