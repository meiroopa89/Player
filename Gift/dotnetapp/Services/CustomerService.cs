// Services/CustomerService.cs
using dotnetapp.Models;

public interface CustomerService
{
    // Customer RegisterCustomer(Customer customer,long userId);
    Customer registerCustomer(Customer customer);
    Customer viewCustomerById(long customerId);
    Customer getCustomerById(long customerId);
    
}