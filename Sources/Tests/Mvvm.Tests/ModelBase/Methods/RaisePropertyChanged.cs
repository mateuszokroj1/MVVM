using Mvvm.Tests.Helpers;

using Xunit;

namespace Mvvm.Tests.ViewModel.Methods
{
    public class RaisePropertyChanged
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void WhenArgumentIsNull_ShouldDoNothing(string testValue)
        {
            object result = null;
            var model = new DemoModel();
            model.PropertyChanged += (obj, e) => result = e.PropertyName;

            model.RaisePropertyChanged(testValue);

            Assert.Null(result);
        }

        [Theory]
        [InlineData("Test1")]
        [InlineData(" ftey165%^ ")]
        [InlineData("@#89   ")]
        public void WhenArgumentIsNotEmpty_ShouldRaiseEvent(string testValue)
        {
            var model = new DemoModel();

            Assert.PropertyChanged(model, testValue, () => model.RaisePropertyChanged(testValue));
        }
    }
}
