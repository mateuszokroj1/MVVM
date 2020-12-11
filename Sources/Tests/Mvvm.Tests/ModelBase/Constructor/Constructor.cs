using Mvvm.Tests.Helpers;

using Xunit;

namespace Mvvm.Tests.ModelBase.Constructor
{
    public class Constructor
    {
        [Fact]
        public void ShouldNotThrow()
        {
            new DemoModel();
        }
    }
}
