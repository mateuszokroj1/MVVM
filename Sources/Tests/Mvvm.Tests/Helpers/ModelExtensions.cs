using System;
using System.ComponentModel;
using System.Reactive.Linq;

namespace Mvvm.Tests.Helpers
{
    public static class ModelExtensions
    {
        internal static IObservable<TReturn> CreatePropertyObservable<TModel, TReturn>(this TModel model, string propertyName, Func<TModel,TReturn> callback)
            where TModel : INotifyPropertyChanged
        {
            return CreatePropertyChangedObservable(model)
            .Where(name => name == propertyName)
            .Select(args => callback(model));
        }

        internal static IObservable<string> CreatePropertyChangedObservable<TModel>(this TModel model)
            where TModel : INotifyPropertyChanged
        {
            return Observable.FromEventPattern<PropertyChangedEventHandler, PropertyChangedEventArgs>
            (
                handler => model.PropertyChanged += handler,
                handler => model.PropertyChanged -= handler
            )
            .Select(args => args?.EventArgs?.PropertyName)
            .Where(name => !string.IsNullOrWhiteSpace(name));
        }
    }
}
