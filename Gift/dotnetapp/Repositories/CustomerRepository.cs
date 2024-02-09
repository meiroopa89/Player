// // Repositories/CustomerRepository.cs
// using System;
// using System.Collections.Generic;
// using dotnetapp.Models;

// namespace dotnetapp.Repositories
// {
//     public class CustomerRepository
//     {
//         private readonly List<Customer> _customers = new List<Customer>();
//         private long _nextCustomerId = 1;

//         public Customer registerCustomer(Customer customer)
//         {
//             customer.CustomerId = _nextCustomerId++;
//             _customers.Add(customer);
//             return customer;
//         }

//         public Customer viewCustomerById(long customerId)
//         {
//             return _customers.Find(c => c.CustomerId == customerId);
//         }
//     }
// }



// Repositories/CustomerRepository.cs
using System.Collections.Generic;
using dotnetapp.Models;

namespace dotnetapp.Repositories
{
    public class CustomerRepository
    {
        private readonly List<Customer> _customers = new List<Customer>();
        private long _nextCustomerId = 1;

        public Customer registerCustomer(Customer customer)
        {
            customer.CustomerId = _nextCustomerId++;
            _customers.Add(customer);
            return customer;
        }

        public Customer viewCustomerById(long customerId)
        {
            return _customers.Find(c => c.CustomerId == customerId);
        }
    }
}
