using System;

using Mvvm.Tests.Helpers;

using Xunit;

namespace Mvvm.Tests.ModelBase.Methods
{
    public class SetPropertyAndNotify
    {
        [Theory]
        [InlineData("", false)]
        [InlineData("  ", false)]
        [InlineData("T", true)]
        [InlineData(null, false)]
        [InlineData("  j634$^yt ", true)]
        public void WhenValuesAreNotEqual_PropertyNamesInTestCases_ShouldSetValueAndNotifyAboutValidElements(string propertyName, bool shouldRaiseEvent)
        {
            object val1 = "val1";
            object val2 = "val2";
            var demo = new DemoModel();

            if(shouldRaiseEvent)
                Assert.PropertyChanged(demo, propertyName, () => demo.SetPropertyAndNotify(ref val2, val1, propertyName));
            else
            {
                using (demo.CreatePropertyChangedObservable().Subscribe(_ => throw new InvalidOperationException()))
                {
                    demo.SetPropertyAndNotify(ref val2, val1, propertyName);
                }
            }
            
            Assert.Equal(val1, val2);
        }

        [Fact]
        public void WhenValuesAreEqual_ShouldDoNothing()
        {
            bool val1 = true, val2 = val1;
            var demo = new DemoModel();

            using (demo.CreatePropertyChangedObservable().Subscribe(_ => throw new InvalidOperationException()))
            {
                demo.SetPropertyAndNotify(ref val1, val2, "Test");
            }

            Assert.Equal(val1, val2);
        }
    }
}
