using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;

namespace Mvvm.Tests
{
    public class CommandTest
    {
        #region Helper fields

        private static readonly Func<object, bool> canExecute1_null = null;
        private static readonly Func<bool> canExecute2_null = null;
        private static readonly Action<object> toExecute1_null = null;
        private static readonly Action toExecute2_null = null;

        private static readonly Func<object, bool> canExecute1_valid = null;
        private static readonly Func<bool> canExecute2_valid = null;
        private static readonly Action<object> toExecute1_valid = null;
        private static readonly Action toExecute2_valid = null;

        #endregion

        #region Constructors

        [Fact]
        public void Constructor1_WhenArgumentsAreNull__ShouldThrowNullReference()
        {
            Assert.Throws<NullReferenceException>(() => new Command(canExecute1_null, toExecute1_null));
        }

        [Fact]
        public void Constructor1_WhenArgumentsAreValid_ShouldSet()
        {

        }

        [Fact]
        public void Constructor1_When_Should()
        {

        }

        [Fact]
        public void Constructor1_When_Should()
        {

        }

        [Fact]
        public void Constructor1_When_Should()
        {

        }

        [Fact]
        public void Constructor1_When_Should()
        {

        }

        #endregion
    }
}
