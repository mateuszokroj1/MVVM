using System;
using System.Collections.Generic;
using System.Linq;

using Mvvm.Tests.Helpers;

using Xunit;

namespace Mvvm.Tests.ModelBase.Methods
{
    public class SetPropertyAndNotifyMany
    {
        [Fact]
        public void WhenValuesAreNotEqualAndSomePropertyNamesAreNotEmpty_ShouldSetValueAndNotifyAboutNotEmptyElements()
        {
            object val1 = "val1";
            object val2 = "val2";
            var demo = new DemoModel();
            var testedValues = new string[] { "Name", " Name1   ds", null, "", "  " };
            var expectedValues = testedValues.Where(name => !string.IsNullOrWhiteSpace(name));
            var results = new List<string>();

            using (demo.CreatePropertyChangedObservable().Subscribe(name => results.Add(name)))
            {
                demo.SetPropertyAndNotifyMany(ref val2, val1, testedValues);
            }

            Assert.Equal(val1, val2);
            Assert.Equal(expectedValues, results);
        }

        [Fact]
        public void WhenValuesAreEqual_ShouldDoNothing()
        {
            int val1 = 2, val2 = val1;
            var demo = new DemoModel();

            using (demo.CreatePropertyChangedObservable().Subscribe(_ => throw new InvalidOperationException()))
            {
                demo.SetPropertyAndNotifyMany(ref val1, val2, "  ", "", null, "example");
            }

            string[] nullArray = null;
            demo.SetPropertyAndNotifyMany(ref val1, val2, nullArray);

            Assert.Equal(val1, val2);
        }
    }
}
