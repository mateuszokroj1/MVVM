namespace Mvvm.Tests.Helpers
{
    internal class DemoModel : Mvvm.ModelBase
    {
        public DemoModel() : base() { }

        public new void RaisePropertyChanged(string param)
        {
            base.RaisePropertyChanged(param);
        }

        public new void RaisePropertiesChanged(params string[] @params)
        {
            base.RaisePropertiesChanged(@params);
        }

        public new void SetPropertyAndNotify<T>(ref T dest, T src, string name)
        {
            base.SetPropertyAndNotify(ref dest, src, name);
        }

        public new void SetPropertyAndNotifyMany<T>(ref T dest, T src, params string[] names)
        {
            base.SetPropertyAndNotifyMany(ref dest, src, names);
        }
    }
}
