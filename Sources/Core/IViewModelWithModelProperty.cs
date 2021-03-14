namespace Mvvm
{
    public interface IViewModelWithModelProperty<out TModel>
    {
        TModel Model { get; }
    }
}