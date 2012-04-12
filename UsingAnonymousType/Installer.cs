using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace UsingAnonymousType
{
    internal class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes
                                   .FromThisAssembly()
                                   .InNamespace("UsingAnonymousType.ViewModels")
                                   .WithServiceSelf()
                                   .LifestyleTransient(),
                               Component
                                   .For<IViewModelFactory>()
                                   .ImplementedBy<ViewModelFactory>());
        }
    }
}