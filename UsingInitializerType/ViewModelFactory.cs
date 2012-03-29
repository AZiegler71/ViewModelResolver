using Castle.Windsor;

using UsingInitializerType.ViewModels;

namespace UsingInitializerType
{
  public class ViewModelFactory : IViewModelFactory
  {
    readonly IWindsorContainer _container;

    public ViewModelFactory(IWindsorContainer container)
    {
      _container = container;
    }

    public IViewModelFor<TInitializer> Create<TInitializer>(TInitializer initializer)
    {
      // Alternatively, pass the initializer as a "model" using an anonymous type.
      // IViewModelFor<T> implementers would then, by convention, need to have
      // the "model" as a ctor parameter.
      var viewModel = _container.Resolve<IViewModelFor<TInitializer>>();
      viewModel.SetModel(initializer);
      return viewModel;
    }
  }

  public interface IViewModelFactory
  {
    IViewModelFor<TInitializer> Create<TInitializer>(TInitializer initializer);
  }
}
