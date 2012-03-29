using System;

using InfrastructureCrap.Persistence;

namespace UsingInitializerType.ViewModels
{
  public class DetailViewModel : IViewModelFor<ShowCustomerDetails>
  {
    readonly IStore _store;

    // If you care for what's inside your TInitializer model,
    // add the parameter to the ctor of the view.
    // Compare to ListViewModel - where we're not interested in the model.
    public DetailViewModel(IStore store, ShowCustomerDetails model)
    {
      _store = store;

      var c = _store.LoadCustomer(model.CustomerId);
      Console.WriteLine("Customer details: {0}, {1}", c.Name, c.Birthday);
    }
  }

  public class ShowCustomerDetails
  {
    public ShowCustomerDetails(int customerId)
    {
      CustomerId = customerId;
    }

    public int CustomerId { get; private set; }
  }
}
