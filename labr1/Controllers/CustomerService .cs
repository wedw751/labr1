using labr1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

public class CustomerService : ICustomerService, IDisposable
{
    private readonly BankContext _db;
    private bool _disposed = false;

    public CustomerService(BankContext db)
    {
        _db = db;
    }

    public IEnumerable<Customers> GetAllCustomers()
    {
        return _db.Customers1.ToList();
    }

    public Customers GetCustomerById(int id)
    {
        return _db.Customers1.Find(id);
    }

    public void AddCustomer(Customers customer)
    {
        _db.Customers1.Add(customer);
        _db.SaveChanges();
    }

    public void UpdateCustomer(Customers customer)
    {
        _db.Entry(customer).State = EntityState.Modified;
        _db.SaveChanges();
    }

    public void DeleteCustomer(int id)
    {
        var customer = _db.Customers1.Find(id);
        if (customer != null)
        {
            _db.Customers1.Remove(customer);
            _db.SaveChanges();
        }
    }

    public void AddPayment(Payment payment)
    {
        payment.PaymentDate = DateTime.Now;
        _db.Payments.Add(payment);
        _db.SaveChanges();
    }

    public void UpdateCustomerCredit(int customerId, decimal paymentAmount)
    {
        var customer = _db.Customers1.Find(customerId);
        if (customer != null)
        {
            customer.CreditOutstanding -= paymentAmount;
            _db.SaveChanges();
        }
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            _disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
