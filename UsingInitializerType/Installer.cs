using System.Collections;
using System.Reflection;

using Castle.Facilities.TypedFactory;
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
      container.AddFacility<TypedFactoryFacility>();

      container.Register(Classes
                           .FromThisAssembly()
                           .BasedOn(typeof(IViewModelFor<>))
                           .WithServiceFirstInterface()
                           .LifestyleTransient(),
                         Component
                           .For<IViewModelFactory>()
                           .AsFactory(c => c.SelectedWith<ScopedSelector>()),
                         Component.For<ScopedSelector, ITypedFactoryComponentSelector>());
    }
  }
}
