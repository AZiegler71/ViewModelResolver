using System;
using InfrastructureCrap.Persistence;

namespace UsingAnonymousType.ViewModels
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