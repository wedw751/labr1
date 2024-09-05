using labr1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace labr1.Controllers
{
    public class HomeController : Controller
    {
        BankContext db = new BankContext();

        public ActionResult Index()
            { return View(db.Customers1); }
    }
}