// // Services/CustomerServiceImpl.cs
// using dotnetapp.Models;
// using dotnetapp.Repositories;  // You may need to include the appropriate repository namespace

// public class CustomerServiceImpl : CustomerService
// {
//     private readonly CustomerRepository _customerRepository;  // Assuming there's a CustomerRepository

//     public CustomerServiceImpl(CustomerRepository customerRepository)
//     {
//         _customerRepository = customerRepository;
//     }

//     public Customer registerCustomer(Customer customer)
//     {
//         // Add any business logic or validation before registering the customer
//         // For example, check if the customer already exists or if the provided data is valid.

//         // Call the repository method to register the customer
//         return _customerRepository.RegisterCustomer(customer);
//     }

//     public Customer GetCustomerById(long customerId)
//     {
//         // Call the repository method to retrieve the customer by ID
//         return _customerRepository.GetCustomerById(customerId);
//     }
// }
