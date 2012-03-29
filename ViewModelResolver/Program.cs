using System;

using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

using ViewModelResolver.Infrastructure;
using ViewModelResolver.ViewModels.UsingAnonymousType;

namespace ViewModelResolver
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Using anonymous type");
      using (var container = new WindsorContainer())
      {
        container.Install(new InfrastructureInstaller());
        container.Install(new UsingAnonymousTypeInstaller());

        container.Resolve<ListViewModel>();
      }

      Console.WriteLine("Press any key...");
      Console.ReadKey();
    }
  }

  class UsingAnonymousTypeInstaller : IWindsorInstaller
  {
    public void Install(IWindsorContainer container, IConfigurationStore store)
    {
      container.Register(Classes
                           .FromThisAssembly()
                           .InNamespace("ViewModelResolver.ViewModels.UsingAnonymousType")
                           .If(t => t.Name.EndsWith("ViewModel"))
                           .WithServiceSelf()
                           .LifestyleTransient(),
                         Component
                           .For<IViewModelFactory>()
                           .ImplementedBy<ViewModelFactory>());
    }
  }

  class InfrastructureInstaller : IWindsorInstaller
  {
    public void Install(IWindsorContainer container, IConfigurationStore store)
    {
      container.Register(Component
                           .For<IWindsorContainer>()
                           .Instance(container),
                         Component
                           .For<IStore>()
                           .ImplementedBy<InMemoryStore>());
    }
  }
}
