using System;

using InfrastructureCrap.Persistence;

namespace UsingInitializerType.ViewModels
{
  public class DetailViewModel : IViewModelFor<ShowCustomerDetails>
  {
    readonly IStore _store;

    public DetailViewModel(IStore store)
    {
      _store = store;
    }

    public void SetModel(ShowCustomerDetails model)
    {
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
