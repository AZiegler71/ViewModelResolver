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

        public IViewModelFor<TArgs> Create<TArgs>(TArgs args)
        {
            return _container.Resolve<IViewModelFor<TArgs>>(new
            {
                args
            });
        }

        public TViewModel Create<TViewModel>()
        {
            return _container.Resolve<TViewModel>();
        }
    }
}