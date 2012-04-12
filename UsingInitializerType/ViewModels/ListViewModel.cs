using System;
using System.Linq;
using InfrastructureCrap.Persistence;

namespace UsingInitializerType.ViewModels
{
    public class ListViewModel : IListViewModel
    {
        private readonly IStore _store;
        private readonly IViewModelFactory _factory;

        public ListViewModel(IStore store, IViewModelFactory factory)
        {
            _store = store;
            _factory = factory;

            var customers = _store.LoadAllCustomers();
            foreach (var customer in customers)
                Console.WriteLine("Customer: {0}", customer.Name);

            var detailed = customers.First();
            Console.WriteLine("Going to display the details of {0}", detailed.Name);

            IViewModelFor<ShowCustomerDetails> viewModel = _factory.Create(new ShowCustomerDetails(detailed.Id));
        }
    }
}