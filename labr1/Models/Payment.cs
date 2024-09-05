using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace labr1.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }

        public int CustomerID { get; set; }
        public decimal PaymentAmount { get; set; }

        public DateTime PaymentDate { get; set; }

    }
}