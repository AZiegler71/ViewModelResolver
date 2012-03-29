using System;
using System.Collections.Generic;
using System.Linq;

using InfrastructureCrap.Models;

namespace InfrastructureCrap.Persistence
{
  public class InMemoryStore : IStore
  {
    readonly List<Customer> _list;

    public InMemoryStore()
    {
      _list = new List<Customer>
              {
                new Customer { Id = 1, Name = "Alex", Birthday = new DateTime(1980, 5, 23, 13, 25, 0) },
                new Customer { Id = 2, Name = "Marci", Birthday = new DateTime(1979, 8, 11, 3, 25, 0) }
              };
    }

    public Customer LoadCustomer(int id)
    {
      return _list.Single(x => x.Id == id);
    }

    public IEnumerable<Customer> LoadAllCustomers()
    {
      return _list;
    }
  }

  public interface IStore
  {
    Customer LoadCustomer(int id);
    IEnumerable<Customer> LoadAllCustomers();
  }
}
