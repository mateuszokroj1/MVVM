using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;

namespace Mvvm.Tests.Command
{
    public class Constructors
    {
        #region Helper fields

        private static readonly Func<object, bool> canExecute1_null = null;
        private static readonly Func<bool> canExecute2_null = null;
        private static readonly Action<object> toExecute1_null = null;
        private static readonly Action toExecute2_null = null;

        private static readonly Func<object, bool> canExecute1_valid = arg => throw new ApplicationException();
        private static readonly Func<bool> canExecute2_valid = () => throw new ApplicationException();
        private static readonly Action<object> toExecute1_valid = arg => throw new ApplicationException();
        private static readonly Action toExecute2_valid = () => throw new ApplicationException();

        #endregion

        #region Constructor1

        [Fact]
        public void Constructor1_WhenArgumentsAreNull_Variant1_ShouldThrowNullReference()
        {
            Assert.Throws<NullReferenceException>(() => new Mvvm.Command(canExecute1_null, toExecute1_null));
        }

        [Fact]
        public void Constructor1_WhenArgumentsAreNull_Variant2_ShouldThrowNullReference()
        {
            Assert.Throws<NullReferenceException>(() => new Mvvm.Command(canExecute1_valid, toExecute1_null));
        }

        [Fact]
        public void Constructor1_WhenArgumentsAreNull_Variant3_ShouldThrowNullReference()
        {
            Assert.Throws<NullReferenceException>(() => new Mvvm.Command(canExecute1_null, toExecute1_valid));
        }

        [Fact]
        public void Constructor1_WhenArgumentsAreValid_ShouldSetFields()
        {
            var result = new Mvvm.Command(canExecute1_valid, toExecute1_valid);

            Assert.Throws<ApplicationException>(() => result.CanExecute(null));
            Assert.Throws<ApplicationException>(() => result.Execute(null));
        }

        #endregion

        #region Constructor2

        [Fact]
        public void Constructor2_WhenArgumentsAreNull_Variant1_ShouldThrowNullReference()
        {
            Assert.Throws<NullReferenceException>(() => new Mvvm.Command(canExecute1_null, toExecute1_valid));
        }

        [Fact]
        public void Constructor2_WhenArgumentsAreNull_Variant2_ShouldThrowNullReference()
        {
            Assert.Throws<NullReferenceException>(() => new Mvvm.Command(canExecute1_null, toExecute1_valid));
        }

        [Fact]
        public void Constructor2_WhenArgumentsAreNull_Variant3_ShouldThrowNullReference()
        {
            Assert.Throws<NullReferenceException>(() => new Mvvm.Command(canExecute1_null, toExecute1_valid));
        }

        [Fact]
        public void Constructor2_WhenArgumentsAreValid_ShouldSetFields()
        {

        }

        [Fact]
        public void Constructor2_When_Should()
        {

        }

        [Fact]
        public void Constructor2_When_Should()
        {

        }

        #endregion
    }
}
