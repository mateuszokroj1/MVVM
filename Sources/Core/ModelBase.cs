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
        /// 
        /// </summary>
        /// <param name="propertyName"></param>
        protected void RaisePropertyChanged([CallerMemberName] string propertyName = "") =>
            RaisePropertiesChanged(propertyName);

        /// <summary>
        /// 
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
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="destination"></param>
        /// <param name="newValue"></param>
        /// <param name="propertyName"></param>
        protected void SetPropertyAndNotify<T>(ref T destination, T newValue, [CallerMemberName] string propertyName = "") =>
            SetPropertyAndNotifyMany(ref destination, newValue, propertyName);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="destination"></param>
        /// <param name="newValue"></param>
        /// <param name="propertiesNames"></param>
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
