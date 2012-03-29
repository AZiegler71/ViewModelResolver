using System;

using ViewModelResolver.Infrastructure;

namespace ViewModelResolver.ViewModels.UsingAnonymousType
{
  public class DetailViewModel
  {
    public DetailViewModel(IStore store, int customerId)
    {
      var customer = store.LoadCustomer(customerId);
      Console.WriteLine("Customer details: {0}, {1}", customer.Name, customer.Birthday);
    }
  }
}
