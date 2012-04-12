using System;
using Castle.Windsor;
using InfrastructureCrap;
using UsingAnonymousType.ViewModels;

namespace UsingAnonymousType
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Using anonymous type");
            using (var container = new WindsorContainer())
            {
                container.Install(new InfrastructureInstaller());
                container.Install(new Installer());

                var factory = container.Resolve<IViewModelFactory>();
                factory.Create<ListViewModel>();
            }

            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }
    }
}