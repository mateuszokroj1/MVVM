using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Mvvm
{
    /// <summary>
    /// Basic command that invokes delegate when can be executed.
    /// </summary>
    public class Command : ICommand
    {
        #region Constructors

        public Command(Func<object, bool> canExecute, Action<object> toExecute)
        {
            this.canExecute = canExecute ?? throw new NullReferenceException(nameof(canExecute));
            this.toExecute = toExecute ?? throw new NullReferenceException(nameof(canExecute));
        }

        public Command()
        : this()
        { }

        protected Command() { }

        #endregion

        #region Fields

        public event EventHandler CanExecuteChanged;
        private readonly Action<object> toExecute;
        private readonly Func<object, bool> canExecute;

        #endregion

        #region Methods

        /// <summary>
        /// Checks that command can be executed
        /// </summary>
        /// <param name="parameter">Command parameter</param>
        public bool CanExecute(object parameter) =>
            this.canExecute(parameter);

        /// <summary>
        /// Invokes delegate used in constructor
        /// </summary>
        /// <param name="parameter">Command parameter</param>
        public void Execute(object parameter) =>
            this.toExecute(parameter);

        /// <summary>
        /// Invokes CanExecuteChanged event.
        /// </summary>
        public void RaiseCanExecuteChanged() =>
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);

        #endregion
    }
}
