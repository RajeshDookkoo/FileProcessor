using System;
using System.Collections.Generic;
using Microsoft.VisualBasic.FileIO;
namespace FileProcessor.ViewModel.Base
{
    /// <summary>
    /// Read utility that uses a VB6 TextFieldParser to read a CSV file.
    /// </summary>
    /// <summary>
    ///     Programmer       : R. Dookkoo.
    ///     Modified Date    : 02 June 2017.
    /// </summary>
    /// <remarks>
    ///     Usage: Used in the Sample application, availabe to use in .Net Framework applications.
    /// </remarks>
    /// <example>
    /// C#
    /// <code>
    ///    ReadUtil.ReadCsvFile(file);
    /// </code>
    /// VB
    /// <code>
    ///    ReadUtil.ReadCsvFile(file);
    /// </code>
    /// </example>
    public class ReadUtil
    {
        #region Read CSV File
        public static IList<string[]> ReadCsvFile(string file)
        {
            var data = new List<string[]>();
            try
            {
                //use VB6 TextFieldParser to read CSV Files
                using (var csvReader = new TextFieldParser(file))
                {
                    //set reader values
                    csvReader.SetDelimiters(new string[] { "," });
                    csvReader.HasFieldsEnclosedInQuotes = true;

                    //read file
                    while (!csvReader.EndOfData)
                    {
                        //read column data
                        var fieldData = csvReader.ReadFields();
                        if (fieldData != null)
                            data.Add(fieldData);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return data;
        }
        #endregion
    }
}