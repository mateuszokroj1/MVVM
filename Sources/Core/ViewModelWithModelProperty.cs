namespace Mvvm
{
    public abstract class ViewModelWithModelProperty<TModel> : ModelBase, IViewModelWithModelProperty<TModel>
    {
        protected ViewModelWithModelProperty(TModel model)
        {
            Model = model;
        }

        public TModel Model { get; protected set; }
    }
}
