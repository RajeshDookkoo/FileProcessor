using System.Collections.Generic;
using System.IO;
using FileProcessor.ViewModel.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace FileProcessorTests.ViewModel.Base
{
    /// <summary>
    /// Test Cases to validate functionality on the core modular components of this application namely: read and print utilities.
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
    ///    ButtonAnimation.ButtonToAnimate = Button2;
    ///    ButtonAnimation.MakeButtonSlideAway();
    /// </code>
    /// VB
    /// <code>
    ///    ButtonAnimation.ButtonToAnimate = Button1;
    ///    ButtonAnimation.MakeButtonSlideAway();
    /// </code>
    /// </example>
    [TestClass()]
    public class CommandUtilsTests
    {
        #region Private Declarations
        private const string CsvTestFileName = @"C:\test.csv";
        private const string TxtTestFileName = @"\test.txt";
        #endregion

        #region Read Utility Tests
        //1. Create a file with sample data using PrintUtil
        //2. Check if the file exists
        //3. Read the contents and check if file can be read
        //4. Check if all of the content matches the sample data (Count Comparison)
        //5. Clean up - Delete test processing files 
        [TestMethod()]
        public void ReadCsvFileTest()
        {
            //create a file that we will try to read using the component
            var printFile = new PrintUtil
            {
                ForceCreation = true,
                OutputColumns = new List<string>(),
                PrintFileName = TxtTestFileName,
                PrintList = "1234"
            };
            printFile.OutputColumns.Add("#");
            printFile.PrintFile();

            //check if file exists
            Assert.IsTrue(File.Exists(printFile.PrintFileName));

            //check if this file can be read
            Assert.IsTrue(ReadUtil.ReadCsvFile(printFile.PrintFileName).Count > 0);

            //check if the file was loaded with all records
            Assert.IsTrue(ReadUtil.ReadCsvFile(printFile.PrintFileName).Count == 4);

            //clean up now
            File.Delete(printFile.PrintFileName);
            Assert.IsFalse(File.Exists(printFile.PrintFileName));
        }
        #endregion

        #region Print Uility Tests
        //1. Create a file with sample data
        //2. Check if the file exists
        //3. Read the contents and check if the content matches the sample data
        //4. Clean up - Delete test processing files 
        [TestMethod()]
        public void PrintFileTest()
        {

            //create a file that we will try to read using the component
            var printFile = new PrintUtil
            {
                ForceCreation = true,
                OutputColumns = new List<string>(),
                PrintFileName = TxtTestFileName,
                PrintList = "#"
            };
            printFile.OutputColumns.Add("#");
            printFile.PrintFile();

            //check if file exists
            Assert.IsTrue(File.Exists(printFile.PrintFileName));

            //read the contents of the file
            using (var streamReader = new StreamReader(printFile.PrintFileName))
            {
                var stream = streamReader.ReadLine();
                Assert.AreEqual("#", stream, "File was not Printed successfully");
            }

            //clean up now
            File.Delete(printFile.PrintFileName);
            Assert.IsFalse(File.Exists(printFile.PrintFileName));
        }
        #endregion
    }
}