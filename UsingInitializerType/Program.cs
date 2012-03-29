using System;

using Castle.Windsor;

using InfrastructureCrap;

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
        container.Install(new InfrastructureInstaller());
        container.Install(new Installer());

        var factory = container.Resolve<IViewModelFactory>();
        var model = factory.Create(new ShowList());
        factory.Release(model);
      }

      Console.WriteLine("Press any key...");
      Console.ReadKey();
    }
  }
}
