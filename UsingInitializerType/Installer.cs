using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using UsingInitializerType.ViewModels;

namespace UsingInitializerType
{
    internal class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.AddFacility<TypedFactoryFacility>();

            container.Register(Component.For<IViewModelFor<ShowCustomerDetails>>()
                                   .ImplementedBy<DetailViewModel>()
                                   .LifestyleTransient(),
                               Component.For<IListViewModel>()
                                   .ImplementedBy<ListViewModel>()
                                   .LifestyleTransient(),
                               Component.For<IViewModelFactory>()
                                   .ImplementedBy<ViewModelFactory>()
                                   .LifestyleSingleton());
        }
    }
}