using labr1.Models;
using System.Collections.Generic;

public interface ICustomerService
{
    IEnumerable<Customers> GetAllCustomers();
    Customers GetCustomerById(int id);
    void AddCustomer(Customers customer);
    void UpdateCustomer(Customers customer);
    void DeleteCustomer(int id);
    void AddPayment(Payment payment);
    void UpdateCustomerCredit(int customerId, decimal paymentAmount);
}
