using FileProcessor.Model.Base;
namespace FileProcessor.Model
{
    /// <summary>
    /// Model Class to host/define the incoming structure model.
    /// </summary>
    /// <summary>
    ///     Programmer       : R. Dookkoo.
    ///     Modified Date    : 02 June 2017.
    /// </summary>
    /// <remarks>
    ///     Usage: Used in the Sample application, availabe to use in .Net Framework applications.
    /// </remarks>
    public class ContactInfo : ObservableObject
    {
        #region Private Declarations
        private string _firstName;
        private string _lastName;
        private string _address;
        private string _streetName;
        private string _phoneNumber;
        #endregion

        #region Public Properties
        /// <summary>
        /// Sets and Gets the FirstName value
        /// </summary>
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged("FirstName");
            }
        }
      
        /// <summary>
        /// Sets and Gets the LastName value
        /// </summary>
        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged("LastName");
            }
        }
      
        /// <summary>
        /// Sets and Gets the Address value
        /// </summary>
        public string Address
        {
            get { return _address; }
            set
            {
                _address = value;
                OnPropertyChanged("Address");
            }
        }
       
        /// <summary>
        /// Sets and Gets the StreetName value - This property is derived from the Address Property
        /// </summary>
        public string StreetName
        {
            get { return _streetName; }
            set
            {
                _streetName = value;
                OnPropertyChanged("StreetName");
            }
        }
      
        /// <summary>
        /// Sets and Gets the Phone Number value
        /// </summary>
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                _phoneNumber = value;
                OnPropertyChanged("PhoneNumber");
            }
        }
        #endregion
    }
}
