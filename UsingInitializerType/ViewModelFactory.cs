using System;
using System.Collections;
using System.Reflection;

using Castle.Facilities.TypedFactory;
using Castle.MicroKernel;
using Castle.MicroKernel.Lifestyle;
using Castle.Windsor;

using UsingInitializerType.ViewModels;

namespace UsingInitializerType
{
  public interface IViewModelFactory
  {
    IViewModelFor<TInitializer> Create<TInitializer>(TInitializer model);
    IViewModelFor<TInitializer> CreateScoped<TInitializer>(TInitializer model);
    void Release(object viewModel);
  }

  class ScopedSelector : DefaultTypedFactoryComponentSelector
  {
    readonly IWindsorContainer _container;

    public ScopedSelector(IWindsorContainer container)
    {
      _container = container;
    }

    protected override IDictionary GetArguments(MethodInfo method, object[] arguments)
    {
      var defaultArgs = base.GetArguments(method, arguments);
      
      if (method.Name != "CreateScoped")
      {
        return defaultArgs;
      }

      defaultArgs.Add("scope", _container.BeginScope());
      return defaultArgs;
    }
  }
}
