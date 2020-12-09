using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Mvvm.Tests.Helpers;

using Xunit;

namespace Mvvm.Tests.ViewModel
{
    public class SetProperty
    {
        [Fact]
        public void SetProperty1()
        {
            object val1 = "val1";
            object val2 = "val2";
            var demo = new DemoModel();

            demo.Set1(ref val2, val1, "Name");
        }

        [Fact]
        public void SetProperty2()
        {
            object val1 = "val1";
            object val2 = "val2";
            var demo = new DemoModel();

            demo.Set2(ref val2, val1, "Name", "Name1");
        }
    }
}
