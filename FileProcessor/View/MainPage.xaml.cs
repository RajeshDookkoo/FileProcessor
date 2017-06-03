using System.Windows;
using FileProcessor.View.Base;
using FileProcessor.ViewModel;
using Microsoft.Win32;
namespace FileProcessor.View
{
    /// <summary>
    /// Main View Interaction logic with ViewModel.
    /// </summary>
    /// <summary>
    ///     Programmer       : R. Dookkoo.
    ///     Modified Date    : 02 June 2017.
    /// </summary>
    /// <remarks>
    ///     Usage: Used in the Sample application, availabe to use in .Net Framework applications.
    /// </remarks>
    public partial class MainPage
    {
        #region Initialization
        //Initialize Page
        public MainPage()
        {
            InitializeComponent();
        }
        #endregion

        #region Button Events
        //Button Open File event
        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            //animate the Button
            ButtonAnimation.ButtonToAnimate = btnOpenFile;

            //create the instance of the ViewModel.
            var context = new ContactInfoViewModel();

            var openFileDialog = new OpenFileDialog { Filter = "Csv files (*.csv)|*.csv|All files (*.*)|*.*" };
            if (openFileDialog.ShowDialog() == true)
                context.LoadRecords(openFileDialog.FileName);

            //assign the context (data) of the instance object to the main window content
            DataContext = context;
            btnPrintFile.IsEnabled = true;
        }

        //Button Print Event
        private void btnPrintFile_Click(object sender, RoutedEventArgs e)
        {
            //create the instance of the ViewModel.
            var context = (ContactInfoViewModel)DataContext;

            //call the appropriate print definition
            if (optFrequency.IsChecked.Value) context.Print(ContactInfoViewModel.PrintOptions.Frequency);
            if (optAddress.IsChecked.Value) context.Print(ContactInfoViewModel.PrintOptions.AddressSort);
            if (optCustom.IsChecked.Value) context.Print(ContactInfoViewModel.PrintOptions.Default);
            if (optName.IsChecked.Value) context.Print(ContactInfoViewModel.PrintOptions.NameList);
        }
        #endregion
    }
}
