namespace FileProcessor.ViewModel.Interface
{
    /// <summary>
    /// Internal interface to ensure that the view model meets the base requirements and implement the minimum functionality.
    /// </summary>
    /// <summary>
    ///     Programmer       : R. Dookkoo.
    ///     Modified Date    : 02 June 2017.
    /// </summary>
    /// <remarks>
    ///     Usage: Used in the Sample application, availabe to use in .Net Framework applications.
    /// </remarks>
    internal interface IProcessorCommand
    {
        #region Basic Method Definitions
        void LoadRecords(string filePath);
        void Print(ContactInfoViewModel.PrintOptions printOptions);
        #endregion
    }
}