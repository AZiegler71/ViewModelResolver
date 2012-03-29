using UsingInitializerType.ViewModels;

namespace UsingInitializerType
{
  public interface IViewModelFactory
  {
    IViewModelFor<TInitializer> Create<TInitializer>(TInitializer model);
    void Release(object viewModel);
  }
}
