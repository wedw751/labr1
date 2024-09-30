using System.Collections.Generic;
using System.Web.Mvc;

namespace labr1.Models
{
    public class CustomerListViewModel
    {
        public IEnumerable<Customers> Customers { get; set; }
        public SelectList Credits { get; set; }
        public SelectList Login { get; set; }

        public decimal sortOrder { get; set; }
    }
}
