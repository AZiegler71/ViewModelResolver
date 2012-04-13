using System;
using InfrastructureCrap.Persistence;

namespace UsingInitializerType.ViewModels
{
    public class DetailViewModel : IDetailViewModel
    {
        private readonly IStore _store;

        // If you care for what's inside your TInitializer model,
        // add the parameter to the ctor of the view.
        // Compare to ListViewModel - where we're not interested in the model.
        public DetailViewModel(IStore store, ShowCustomerDetails args)
        {
            _store = store;

            var c = _store.LoadCustomer(args.CustomerId);
            Console.WriteLine("Customer details: {0}, {1}", c.Name, c.Birthday);
        }
    }
}