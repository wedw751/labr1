using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace labr1.Models
{
    public class Customers
    {
        [Key]
        public int CustomerID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Email {  get; set; }

        public string PhoneNumber { get; set; }

        public decimal CreditLimit { get; set; }

        public decimal CreditOutstanding { get; set; }
    }
}