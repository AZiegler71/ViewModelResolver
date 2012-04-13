using Castle.Windsor;
using UsingInitializerType.ViewModels;

namespace UsingInitializerType
{
    public class ViewModelFactory : IViewModelFactory
    {
        private readonly IWindsorContainer _container;

        public ViewModelFactory(IWindsorContainer container)
        {
            _container = container;
        }

        public T Create<T, TArgs>(TArgs args) where T : IViewModel
        {
            return (T)_container.Resolve<IInstanceFor<T, TArgs>>(new
            {
                args
            });
        }

        public T Create<T>() where T : IViewModel
        {
            return _container.Resolve<T>();
        }
    }
}