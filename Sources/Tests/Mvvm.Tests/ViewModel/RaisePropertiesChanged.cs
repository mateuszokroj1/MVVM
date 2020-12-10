using System;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Linq;

using Mvvm.Tests.Helpers;

namespace Mvvm.Tests.ViewModel.Methods
{
    public class RaisePropertiesChanged
    {
        #region Constructor

        public RaisePropertiesChanged()
        {
            this.propertyChangedObservable =
                Observable
                .FromEventPattern<PropertyChangedEventHandler, PropertyChangedEventArgs>
                (
                    handler => this.model.PropertyChanged += handler,
                    handler => this.model.PropertyChanged -= handler
                )
                .Select(args => args?.EventArgs?.PropertyName);
        }

        #endregion

        #region Fields

        private readonly DemoModel model = new DemoModel();
        private readonly IObservable<string> propertyChangedObservable;

        private readonly string[] raise2_nullArgument1 = null;
        private readonly string[] raise2_nullArgument2 = new string[] { null, "TEST1", "", "   54$%( " };

        #endregion

        public void 

        var expectedResult = raise2_nullArgument1.Where(value => !string.IsNullOrEmpty(value));

        List<string> resultlist = new List<string>();

            this.propertyChangedObservable.Subscribe(value => resultlist.Add(value));

            this.model.Raise2(raise2_nullArgument1);

            Assert.Equal(expectedResult.Count(), resultlist.Count);

            foreach (var expectedValue in expectedResult)
                if (!resultlist.Contains(expectedValue))
                    throw new AssertActualExpectedException(expectedResult, resultlist, "Collections are not equal");
    }
}
