using UsingInitializerType.ViewModels;

namespace UsingInitializerType
{
    public interface IViewModelFactory
    {
        IViewModelFor<TArgs> Create<TArgs>(TArgs args);

        TViewModel Create<TViewModel>();
    }
}