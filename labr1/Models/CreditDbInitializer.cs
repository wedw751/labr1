using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace labr1.Models
{
    public class CreditDbInitializer : DropCreateDatabaseAlways<BankContext>
    {
        protected override void Seed(BankContext context)
        {
            Customers s1 = new Customers
            {
                CustomerID = 1023,
                FirstName = "John",
                LastName = "Doe",
                DateOfBirth = new DateTime(1990, 1, 1),
                Email = "john.doe@example.com",
                PhoneNumber = "1234567890",
                CreditLimit = 1000,
                CreditOutstanding = 500,
                Role = "User",
                Password = "password",
                Login = "john.doe"
            };
            Customers s2 = new Customers
            {
                CustomerID = 1024,
                FirstName = "Jane",
                LastName = "Doe",
                DateOfBirth = new DateTime(1992, 2, 2),
                Email = "jane.doe@example.com",
                PhoneNumber = "0987654321",
                CreditLimit = 1500,
                CreditOutstanding = 700,
                Role = "User",
                Password = "password123",
                Login = "jane.doe"
            };
            Customers s3 = new Customers
            {
                CustomerID = 1024,
                FirstName = "Alice",
                LastName = "Smith",
                DateOfBirth = new DateTime(1995, 3, 3),
                Email = "alice.smith@example.com",
                PhoneNumber = "5555555555",
                CreditLimit = 2000,
                CreditOutstanding = 1000,
                Role = "User",
                Password = "alicepass",
                Login = "alice.smith"
            };
            Customers s4 = new Customers
            {
                CustomerID = 1024,
                FirstName = "Bob",
                LastName = "Johnson",
                DateOfBirth = new DateTime(1988, 4, 4),
                Email = "bob.johnson@example.com",
                PhoneNumber = "4444444444",
                CreditLimit = 2500,
                CreditOutstanding = 1500,
                Role = "Admin",
                Password = "bobpass",
                Login = "bob.johnson"
            };

            context.Customers1.Add(s1);
            context.Customers1.Add(s2);
            context.Customers1.Add(s3);
            context.Customers1.Add(s4);

            Credits c1 = new Credits
            {
                Name = "Credit1",
                CreditDate = DateTime.Now,
                Customers = new List<Customers> { s1, s2, s3, s4 }
            };
            Credits c2 = new Credits
            {
                Name = "Credit2",
                CreditDate = DateTime.Now,
                Customers = new List<Customers> { s1, s2 }
            };
            Credits c3 = new Credits
            {
                Name = "Credit3",
                CreditDate = DateTime.Now,
                Customers = new List<Customers> { s3, s4 }
            };

            context.Credits.Add(c1);
            context.Credits.Add(c2);
            context.Credits.Add(c3);

            base.Seed(context);
        }
    }
}
