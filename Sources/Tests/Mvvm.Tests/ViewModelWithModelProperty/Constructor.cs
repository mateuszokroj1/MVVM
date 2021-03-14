using System;

using Mvvm.Tests.Helpers;

using Xunit;

namespace Mvvm.Tests.ViewModelWithModelProperty
{
    public class Constructor
    {
        [Fact]
        public void WhenArgumentIsNullAndTypeIsNullable_ShouldNotThrow()
        {
            var model = new DemoViewModel<object>(null);

            Assert.Null(model.Model);
        }

        [Fact]
        public void WhenArgumentIsNotNull_ShouldSetProperty()
        {
            var result = Math.PI;
            var model = new DemoViewModel<double>(result);

            Assert.Equal(result, model.Model);
        }
    }
}
