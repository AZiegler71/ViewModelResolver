using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

using UsingInitializerType.ViewModels;

namespace UsingInitializerType
{
  class Installer : IWindsorInstaller
  {
    public void Install(IWindsorContainer container, IConfigurationStore store)
    {
      container.Register(Classes
                           .FromThisAssembly()
                           .BasedOn(typeof(IViewModelFor<>))
                           .WithServiceFirstInterface()
                           .LifestyleTransient(),
                         Component
                           .For<IViewModelFactory>()
                           .ImplementedBy<ViewModelFactory>());
    }
  }
}