using UsingInitializerType.ViewModels;

namespace UsingInitializerType
{
    public interface IViewModelFactory
    {
        T Create<T, TArgs>(TArgs args) where T : IViewModel;

        T Create<T>() where T : IViewModel;
    }
}