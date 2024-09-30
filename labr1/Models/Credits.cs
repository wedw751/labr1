using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace labr1.Models
{
    public class Credits
    {
        [Key]
        public int CreditId { get; set; }

        public string Name { get; set; }
        
        public virtual ICollection<Customers> Customers { get; set; }
        public Credits()
        {
            Customers = new List<Customers>();
        }
        public DateTime CreditDate { get; set; }

    }
}