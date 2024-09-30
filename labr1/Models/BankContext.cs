using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace labr1.Models
{
    public class BankContext : DbContext
    {

        public DbSet<Customers> Customers1 { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<Credits> Credits { get; set; }

        public BankContext() : base("DefaultConnection")

        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Credits>().HasMany(c => c.Customers)
                .WithMany(s => s.Credits)
                .Map(t => t.MapLeftKey("CreditId")
                .MapRightKey("StudentId")
                .ToTable("CustomerCredits"));
        }

    }

}