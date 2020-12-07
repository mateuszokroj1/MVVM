using System;

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
            Assert.Throws<NullReferenceException>(() => new Mvvm.Command(canExecute1_null, toExecute2_valid));
        }

        [Fact]
        public void Constructor2_WhenArgumentsAreNull_Variant2_ShouldThrowNullReference()
        {
            Assert.Throws<NullReferenceException>(() => new Mvvm.Command(canExecute1_valid, toExecute2_null));
        }

        [Fact]
        public void Constructor2_WhenArgumentsAreNull_Variant3_ShouldThrowNullReference()
        {
            Assert.Throws<NullReferenceException>(() => new Mvvm.Command(canExecute1_null, toExecute2_null));
        }

        [Fact]
        public void Constructor2_WhenArgumentsAreValid_ShouldSetFields()
        {
            var result = new Mvvm.Command(canExecute1_valid, toExecute2_valid);

            Assert.Throws<ApplicationException>(() => result.CanExecute(null));
            Assert.Throws<ApplicationException>(() => result.Execute(null));
        }

        #endregion

        #region Constructor3

        [Fact]
        public void Constructor3_WhenArgumentsAreNull_Variant1_ShouldThrowNullReference()
        {
            Assert.Throws<NullReferenceException>(() => new Mvvm.Command(canExecute2_null, toExecute1_valid));
        }

        [Fact]
        public void Constructor3_WhenArgumentsAreNull_Variant2_ShouldThrowNullReference()
        {
            Assert.Throws<NullReferenceException>(() => new Mvvm.Command(canExecute2_valid, toExecute1_null));
        }

        [Fact]
        public void Constructor3_WhenArgumentsAreNull_Variant3_ShouldThrowNullReference()
        {
            Assert.Throws<NullReferenceException>(() => new Mvvm.Command(canExecute2_null, toExecute1_null));
        }

        [Fact]
        public void Constructor3_WhenArgumentsAreValid_ShouldSetFields()
        {
            var result = new Mvvm.Command(canExecute2_valid, toExecute1_valid);

            Assert.Throws<ApplicationException>(() => result.CanExecute(null));
            Assert.Throws<ApplicationException>(() => result.Execute(null));
        }

        #endregion

        #region Constructor4

        [Fact]
        public void Constructor4_WhenArgumentsAreNull_Variant1_ShouldThrowNullReference()
        {
            Assert.Throws<NullReferenceException>(() => new Mvvm.Command(canExecute2_null, toExecute2_valid));
        }

        [Fact]
        public void Constructor4_WhenArgumentsAreNull_Variant2_ShouldThrowNullReference()
        {
            Assert.Throws<NullReferenceException>(() => new Mvvm.Command(canExecute2_valid, toExecute2_null));
        }

        [Fact]
        public void Constructor4_WhenArgumentsAreNull_Variant3_ShouldThrowNullReference()
        {
            Assert.Throws<NullReferenceException>(() => new Mvvm.Command(canExecute2_null, toExecute2_null));
        }

        [Fact]
        public void Constructor4_WhenArgumentsAreValid_ShouldSetFields()
        {
            var result = new Mvvm.Command(canExecute2_valid, toExecute2_valid);

            Assert.Throws<ApplicationException>(() => result.CanExecute(null));
            Assert.Throws<ApplicationException>(() => result.Execute(null));
        }

        #endregion

        #region Constructor5

        [Fact]
        public void Constructor5_WhenArgumentIsNull_Variant1_ShouldThrowNullReference()
        {
            Assert.Throws<NullReferenceException>(() => new Mvvm.Command(toExecute1_null));
        }

        [Fact]
        public void Constructor5_WhenArgumentIsValid_ShouldSetFields()
        {
            var result = new Mvvm.Command(toExecute1_valid);

            Assert.True(result.CanExecute(null));
            Assert.Throws<ApplicationException>(() => result.Execute(null));
        }

        #endregion

        #region Constructor6

        [Fact]
        public void Constructor6_WhenArgumentsAreNull_Variant1_ShouldThrowNullReference()
        {
            Assert.Throws<NullReferenceException>(() => new Mvvm.Command(toExecute2_null));
        }

        [Fact]
        public void Constructor6_WhenArgumentsAreValid_ShouldSetFields()
        {
            var result = new Mvvm.Command(toExecute2_valid);

            Assert.True(result.CanExecute(null));
            Assert.Throws<ApplicationException>(() => result.Execute(null));
        }

        #endregion
    }
}
