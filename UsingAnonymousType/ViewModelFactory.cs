using Castle.Windsor;

namespace UsingAnonymousType
{
  public interface IViewModelFactory
  {
    T Create<T>();
    T Create<T>(object argumentsAsAnonymousType);
  }

  public class ViewModelFactory : IViewModelFactory
  {
    readonly IWindsorContainer _container;

    public ViewModelFactory(IWindsorContainer container)
    {
      _container = container;
    }

    public T Create<T>()
    {
      return _container.Resolve<T>();
    }

    public T Create<T>(object argumentsAsAnonymousType)
    {
      return _container.Resolve<T>(argumentsAsAnonymousType);
    }
  }
}