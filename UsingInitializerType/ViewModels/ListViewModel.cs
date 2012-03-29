using System;
using System.Linq;

using InfrastructureCrap.Persistence;

namespace UsingInitializerType.ViewModels
{
  public class ListViewModel : IViewModelFor<ShowList>, IDisposable
  {
    readonly IStore _store;
    readonly IViewModelFactory _factory;
    readonly IDisposable _scope;

    public ListViewModel(IStore store, IViewModelFactory factory, IDisposable scope)
    {
      _store = store;
      _factory = factory;
      _scope = scope;

      var customers = _store.LoadAllCustomers();
      foreach (var customer in customers)
      {
        Console.WriteLine("Customer: {0}", customer.Name);
      }
      
      var detailed = customers.First();
      Console.WriteLine("Going to display the details of {0}", detailed.Name);

      var viewModel = _factory.Create(new ShowCustomerDetails(detailed.Id));
      _factory.Release(viewModel);
    }

    public void Dispose()
    {
      _scope.Dispose();
    }
  }

  public class ShowList
  {
  }
}