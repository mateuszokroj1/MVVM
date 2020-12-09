using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvvm.Tests.Helpers
{
    internal class DemoModel : Mvvm.ViewModel
    {
        public void Raise1(string param)
        {
            RaisePropertyChanged(param);
        }

        public void Raise2(params string[] @params)
        {
            RaisePropertiesChanged(@params);
        }

        public void Set1<T>(ref T dest, T src, string name)
        {
            SetPropertyAndNotify(ref dest, src, name);
        }

        public void Set2<T>(ref T dest, T src, params string[] names)
        {
            SetPropertyAndNotify(ref dest, src, names);
        }
    }
}
