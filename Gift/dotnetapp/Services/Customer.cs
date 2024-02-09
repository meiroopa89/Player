// Services/CustomerService.cs
using dotnetapp.Models;

public interface CustomerService
{
    Customer RegisterCustomer(Customer customer);
    Customer GetCustomerById(long customerId);
}