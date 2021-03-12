using System.Collections.Generic;
using System.Linq;
using System;

using Mvvm.Tests.Helpers;

using Xunit;

namespace Mvvm.Tests.ModelBase.Methods
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

            using (model.CreatePropertyChangedObservable()
                 .Subscribe(name => result = testValue))
            {
                model.RaisePropertiesChanged(argument_forTest1);
            }

            Assert.Null(result);
        }

        [Fact]
        public void WhenSomeArgumentsAreInvalid_ShouldNotifyAboutValidElements()
        {
            var expectedResults = this.argument_forTest2.Where(name => !string.IsNullOrWhiteSpace(name));
            var results = new List<string>(expectedResults.Count());
            var model = new DemoModel();

            using (model.CreatePropertyChangedObservable().Subscribe(name => results.Add(name)))
            {
                model.RaisePropertiesChanged(this.argument_forTest2);
            }

            Assert.Equal(expectedResults, results);
        }
    }
}
