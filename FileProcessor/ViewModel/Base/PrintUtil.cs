using System;
using System.Collections.Generic;
using System.IO;
namespace FileProcessor.ViewModel.Base
{
    /// <summary>
    /// Print object that uses the values in the properties section to write raw data into a Text File.
    /// </summary>
    /// <summary>
    ///     Programmer       : R. Dookkoo.
    ///     Modified Date    : 02 June 2017.
    /// </summary>
    /// <remarks>
    ///     Usage: Used in the Sample application, availabe to use in .Net Framework applications.
    /// </remarks>
    public class PrintUtil
    {
        #region Private Declarations
        private string _printFileName = @"\sample.txt";
        private IList<string> _outputColumns;
        private dynamic _printList;
        private bool _forceCreation = true;
        #endregion

        #region Public Properties
        /// <summary>
        /// Sets and Gets the value of the File Name to use when Print/Saving the file
        /// </summary>
        public string PrintFileName
        {
            get { return _printFileName; }
            set { _printFileName = value; }
        }

        /// <summary>
        /// Sets and Gets the Output Columns to print on the OutputFile
        /// </summary>
        public IList<string> OutputColumns
        {
            get { return _outputColumns; }
            set => _outputColumns = value;
        }

        /// <summary>
        /// Sets and Gets the Print Information (RAW) data in the form of a Linq Query
        /// </summary>
        public dynamic PrintList
        {
            get { return _printList; }
            set { _printList = value; }
        }

        /// <summary>
        /// Sets and Gets a value indicating whether or not to delete and previously created files
        /// </summary>
        public bool ForceCreation
        {
            get { return _forceCreation; }
            set { _forceCreation = value; }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Prints the file to a Text file based on the properties values
        /// </summary>
        public bool PrintFile()
        {
            try
            {
                if (_printFileName == "") throw new Exception("Output File Name is Required");
                if (_outputColumns == null) throw new Exception("At least 1 Output Column is Required");
                if (_printList == null) throw new Exception("Print File is Empty");

                //get the app domain
                _printFileName = AppDomain.CurrentDomain.BaseDirectory + _printFileName;

                //control file creation parameters
                if (_forceCreation)
                    if (File.Exists(_printFileName)) File.Delete(_printFileName);

                //create File
                using (var textWriter = new StreamWriter(_printFileName))
                {
                    foreach (dynamic line in _printList)
                    {
                        for (var i = 0; i <= _outputColumns.Count - 1; i++)
                        {
                            var sb = new System.Text.StringBuilder();
                            if (_outputColumns[i] != "#")
                            {
                                sb.Append(line.GetType().GetProperty(_outputColumns[i]).GetValue(line, null));
                                sb.Append("\t");
                            }
                            else
                            {
                                sb.Append(line);
                            }
                            textWriter.Write(sb);
                        }
                        textWriter.WriteLine();
                    }
                }
                return File.Exists(_printFileName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}