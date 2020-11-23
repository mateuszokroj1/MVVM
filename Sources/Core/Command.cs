using System;
using System.Windows.Input;

namespace Mvvm
{
    /// <summary>
    /// Basic command that invokes delegate when can be executed.
    /// </summary>
    public class Command : ICommand
    {
        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="Command"/>.
        /// </summary>
        /// <param name="canExecute">Gives information about command availability.</param>
        /// <param name="toExecute">Runs action to do.</param>
        /// <exception cref="NullReferenceException"/>
        public Command(Func<object, bool> canExecute, Action<object> toExecute)
        {
            this.canExecute = canExecute ?? throw new NullReferenceException(nameof(canExecute));
            this.toExecute = toExecute ?? throw new NullReferenceException(nameof(canExecute));
        }

        /// <summary>
        /// Creates a new instance of <see cref="Command"/>.
        /// </summary>
        /// <param name="canExecute">Gives information about command availability.</param>
        /// <param name="toExecute">Runs action to do.</param>
        /// <exception cref="NullReferenceException"/>
        public Command(Func<object, bool> canExecute, Action toExecute) :
            this(canExecute, parameter => toExecute())
        { }

        /// <summary>
        /// Creates a new instance of <see cref="Command"/>.
        /// </summary>
        /// <param name="canExecute">Gives information about command availability.</param>
        /// <param name="toExecute">Runs action to do.</param>
        /// <exception cref="NullReferenceException"/>
        public Command(Func<bool> canExecute, Action<object> toExecute) :
            this(parameter => canExecute(), toExecute)
        { }

        /// <summary>
        /// Creates a new instance of <see cref="Command"/>.
        /// </summary>
        /// <param name="canExecute">Gives information about command availability.</param>
        /// <param name="toExecute">Runs action to do.</param>
        /// <exception cref="NullReferenceException"/>
        public Command(Func<bool> canExecute, Action toExecute) :
            this(parameter => canExecute(), parameter => toExecute())
        { }

        /// <summary>
        /// Creates a new instance of <see cref="Command"/>.
        /// </summary>
        /// <param name="toExecute">Runs action to do.</param>
        /// <exception cref="NullReferenceException"/>
        public Command(Action<object> toExecute) :
            this(parameter => true, toExecute)
        { }

        /// <summary>
        /// Creates a new instance of <see cref="Command"/>.
        /// </summary>
        /// <param name="toExecute">Runs action to do.</param>
        /// <exception cref="NullReferenceException"/>
        public Command(Action toExecute) :
            this(parameter => true, toExecute)
        { }

        /// <summary>
        /// Creates a new instance of <see cref="Command"/>. Parameters must be set manually.
        /// </summary>
        protected Command() { }

        #endregion

        #region Fields

        /// <summary>
        /// Notifies when CanExecute changed.
        /// </summary>
        public event EventHandler CanExecuteChanged;

        protected readonly Action<object> toExecute;
        protected readonly Func<object, bool> canExecute;

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
