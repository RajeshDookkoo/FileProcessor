using System.ComponentModel;
namespace FileProcessor.Model.Base
{
    /// <summary>
    /// Base Class that will be applied to all models, so we dont have the keep instantiating the INotifyPropertyChanged Members.
    /// </summary>
    /// <summary>
    ///     Programmer       : R. Dookkoo.
    ///     Modified Date    : 02 June 2017.
    /// </summary>
    /// <remarks>
    ///     Usage: Used in the Sample application, availabe to use in .Net Framework applications.
    /// </remarks>
    public abstract class ObservableObject : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Members
        /// <summary>
        /// Raised when a property on this object has a new value.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises this object's PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The property that has a new value.</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged == null) return;
            var e = new PropertyChangedEventArgs(propertyName);
            PropertyChanged(this, e);
        }
        #endregion 
    }
}
