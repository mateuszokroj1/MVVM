using System;
using System.ComponentModel;
using System.Reactive.Linq;

using Mvvm.Tests.Helpers;

using Xunit;

namespace Mvvm.Tests.ViewModel.Methods
{
    public class RaisePropertyChanged
    {
        #region Constructor

        public RaisePropertyChanged()
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

        #endregion

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void WhenArgumentIsNull_ShouldDoNothing(string testValue)
        {
            bool isInvoked = false;
            this.propertyChangedObservable.Where(name => name == testValue).Subscribe(n => isInvoked = true);

            this.model.Raise1(testValue);

            Assert.False(isInvoked);
        }

        [Theory]
        [InlineData("Test1")]
        [InlineData(" ftey165%^ ")]
        [InlineData("@#89   ")]
        public void WhenArgumentIsNotEmpty_ShouldRaiseEvent(string testValue)
        {
            bool isInvoked = false;
            this.propertyChangedObservable.Where(name => name == testValue).Subscribe(n => isInvoked = true);

            this.model.Raise1(testValue);

            Assert.True(isInvoked);
        }
    }
}
