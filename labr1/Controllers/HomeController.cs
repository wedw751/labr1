using labr1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace labr1.Controllers
{
    public class HomeController : Controller
    {
        BankContext db = new BankContext();

        public ActionResult Index()
        {
            return View(db.Customers1);
        }

        [HttpGet]
        public ActionResult Pay(int CustomerID)
        {
            ViewBag.CustomerID1 = CustomerID;
            return View();
        }
        [HttpPost]
        public ActionResult Pay(Payment payment)
        {

                payment.PaymentDate = DateTime.Now;
                db.Payments.Add(payment);
                db.SaveChanges();
                var customer = db.Customers1.Find(payment.CustomerID);
                if (customer != null)
                    {
                    customer.CreditOutstanding -= payment.PaymentAmount;
                    db.SaveChanges();
                    }
                return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditClient(int? CustomerId)
        {
            if (CustomerId == null)
            {
                return HttpNotFound();
            }
            Customers customers = db.Customers1.Find(CustomerId);
            if (customers != null)
            {
                return View(customers);
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult EditClient(Customers customers)
        {
            db.Entry(customers).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Customers customers)
        {
            db.Customers1.Add(customers);
            db.SaveChanges();

            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Delete(int CustomerId)
        {
            // Отримуємо клієнта за ID
            Customers customer = db.Customers1.Find(CustomerId);

            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int CustomerId)
        {
            Customers customer = db.Customers1.Find(CustomerId);

            if (customer != null)
            {
                db.Customers1.Remove(customer);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
