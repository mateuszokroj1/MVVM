using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Mvvm
{
    /// <summary>
    /// Base class for view models classes. Implements basic functionality 
    /// </summary>
    public abstract class ModelBase : INotifyPropertyChanged
    {
        #region Fields

        /// <summary>
        /// Notifies when property changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Methods

        /// <summary>
        /// Raises PropertyChanged event. Use it to notify about changes in properties.
        /// </summary>
        /// <param name="propertyName">Name of changed property</param>
        protected void RaisePropertyChanged([CallerMemberName] string propertyName = "") =>
            RaisePropertiesChanged(propertyName);

        /// <summary>
        /// Raises PropertyChanged event for many elements. Use it to notify about changes in properties.
        /// </summary>
        /// <param name="propertiesNames"></param>
        protected void RaisePropertiesChanged(params string[] propertiesNames)
        {
            if (propertiesNames?.Length > 0)
                foreach (var name in propertiesNames)
                    if (!string.IsNullOrWhiteSpace(name))
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        /// <summary>
        /// Sets value in <paramref name="destination"/> when is not equal to <paramref name="newValue"/> and notify about changes in property.
        /// </summary>
        /// <typeparam name="T">Type to set</typeparam>
        /// <param name="destination">Field to set</param>
        /// <param name="newValue">Source value</param>
        /// <param name="propertyName">Name of property that was changed</param>
        protected void SetPropertyAndNotify<T>(ref T destination, T newValue, [CallerMemberName] string propertyName = "") =>
            SetPropertyAndNotifyMany(ref destination, newValue, propertyName);

        /// <summary>
        /// Sets value in <paramref name="destination"/> when is not equal to <paramref name="newValue"/> and notify about changes in properties.
        /// </summary>
        /// <typeparam name="T">Type to set</typeparam>
        /// <param name="destination">Field to set</param>
        /// <param name="newValue">Source value</param>
        /// <param name="propertiesNames">Names of properties that was changed</param>
        protected void SetPropertyAndNotifyMany<T>(ref T destination, T newValue, params string[] propertiesNames)
        {
            if(!Equals(destination, newValue))
            {
                destination = newValue;

                RaisePropertiesChanged(propertiesNames);
            }
        }

        #endregion
    }
}
