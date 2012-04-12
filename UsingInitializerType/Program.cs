using System;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using InfrastructureCrap.Persistence;
using UsingInitializerType.ViewModels;

namespace UsingInitializerType
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Using initializer type");
            using (var container = new WindsorContainer())
            {
                container.Install(new ScopedInfrastructureInstaller());
                container.Install(new Installer());

                IViewModelFactory factory = container.Resolve<IViewModelFactory>();
                IViewModel model = factory.Create<IListViewModel>();
                Console.WriteLine("Releasing main view model");
            }

            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }
    }

    internal class ScopedInfrastructureInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component
                                   .For<IWindsorContainer>()
                                   .Instance(container),
                               Component
                                   .For<IStore>()
                                   .ImplementedBy<InMemoryStore>()
                                   .LifestyleSingleton()
                                   .OnCreate(x => Console.WriteLine("Creating new store"))
                                   .OnDestroy(x => Console.WriteLine("Destroying store")));
        }
    }
}