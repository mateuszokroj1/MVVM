
using Mvvm.Tests.Helpers;

using Xunit;

namespace Mvvm.Tests.ViewModelWithModelProperty
{
    public class Property
    {
        [Fact]
        public void WhenProtectedSetterUsed_ShouldGetEqualValue()
        {
            var model = new DemoViewModel<int>(1);

            model.PropertySetter(-100);

            Assert.Equal(-100, model.Model);
        }
    }
}
