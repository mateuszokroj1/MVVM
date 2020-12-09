using System;

using Xunit;

namespace Mvvm.Tests.Command
{
    public class Methods
    {
        #region CanExecute

        [Fact]
        public void CanExecute_ShouldUseArgumentInInvokedMethod()
        {
            object result = null;
            int testValue = 2;
            Action nullAction = null;

            var command = new Mvvm.Command(param => { result = param; return true; }, nullAction);

            command.CanExecute(testValue);

            Assert.Equal(testValue, result);
        }

        [Fact]
        public void CanExecute_ShouldReturnValueFromInvokedMethod()
        {
            Action nullAction = null;
            var command = new Mvvm.Command(param => true, nullAction);

            Assert.True(command.CanExecute(null));
        }

        #endregion

        #region Execute

        [Fact]
        public void Execute_ShouldUseArgumentInInvokedMethod()
        {
            object result = null;
            int testValue = 2;

            var command = new Mvvm.Command(() => true, param => result = param);

            command.Execute(testValue);

            Assert.Equal(testValue, result);
        }

        #endregion
    }
}
