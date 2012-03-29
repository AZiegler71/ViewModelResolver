using System;

using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

using InfrastructureCrap;
using InfrastructureCrap.Persistence;

using UsingInitializerType.ViewModels;

namespace UsingInitializerType
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Using initializer type");
      using (var container = new WindsorContainer())
      {
        container.Install(new ScopedInfrastructureInstaller());
        container.Install(new Installer());

        var factory = container.Resolve<IViewModelFactory>();
        var model = factory.CreateScoped(new ShowList());
        Console.WriteLine("Releasing main view model");
        factory.Release(model);
        Console.WriteLine("Released");
      }

      Console.WriteLine("Press any key...");
      Console.ReadKey();
    }
  }

  class ScopedInfrastructureInstaller : IWindsorInstaller
  {
    public void Install(IWindsorContainer container, IConfigurationStore store)
    {
      container.Register(Component
                            .For<IWindsorContainer>()
                            .Instance(container),
                          Component
                            .For<IStore>()
                            .ImplementedBy<InMemoryStore>()
                            .LifestyleScoped()
                            .OnCreate(x => Console.WriteLine("Creating new store"))
                            .OnDestroy(x => Console.WriteLine("Destroying store")));
    }
  }
}
