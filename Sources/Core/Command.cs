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

        public Command()
        {

        }

        protected Command() { }

        #endregion

        #region Fields

        public event EventHandler CanExecuteChanged;
        private readonly Action<object> toExecute;
        private readonly 

        #endregion

        #region Methods

        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
