namespace Mvvm.Tests.Helpers
{
    internal class DemoViewModel<TModel> : ViewModelWithModelProperty<TModel>
    {
        public DemoViewModel(TModel model) : base(model) { }

        public void PropertySetter(TModel model) => Model = model;
    }
}
