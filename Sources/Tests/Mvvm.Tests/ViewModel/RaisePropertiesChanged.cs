using Mvvm.Tests.Helpers;

using Xunit;

namespace Mvvm.Tests.ViewModel.Methods
{
    public class RaisePropertiesChanged
    {
        #region Fields

        private readonly string[] argument_forTest1 = null;
        private readonly string[] argument_forTest2 = new string[] { null, "", " ", "a 1 %" };

        #endregion

        [Fact]
        public void WhenArgumentIsNull_ShouldDoNothing()
        {
            var model = new DemoModel();
            object result = null;
            object testValue = new object();

            model.PropertyChanged += (obj, e) => result = testValue;

            model.Raise2(argument_forTest1);

            Assert.Null(result);
        }

        [Fact]
        public void WhenSomeArgumentsAreInvalid_ShouldNotifyAboutValidElements()
        {

        }
    }
}
