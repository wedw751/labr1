using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace labr1.Models
{
    public class BankContext : DbContext
    {
        internal object Bankapp;

        public DbSet<Customers> Customers1 { get; set; }

        public DbSet<Payment> Payments { get; set; }
    }
}