using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Mvvm
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class ViewModel : INotifyPropertyChanged
    {
        #region Constructor

        /// <summary>
        /// Initializes <see cref="ViewModel"/> instance.
        /// </summary>
        protected ViewModel()
        {
            PropertyChangedObservable = Observable.FromEventPattern<>();
        }

        #endregion

        #region Fields

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Properties

        public IObservable<string> PropertyChangedObservable { get; }

        #endregion

        #region Methods

        protected void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (!string.IsNullOrWhiteSpace(propertyName))
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void SetPropertyAndNotify<T>(ref T destination, T newValue, [CallerMemberName] string propertyName = "") =>
            SetPropertyAndNotify(ref destination, newValue, propertyName);

        protected void SetPropertyAndNotify<T>(ref T destination, T newValue, params string[] propertiesNames)
        {
            if(!Equals(destination, newValue))
            {
                destination = newValue;

                if (propertiesNames?.Length > 0)
                    foreach (var name in propertiesNames)
                        RaisePropertyChanged(name);
            }
        }

        #endregion
    }
}
