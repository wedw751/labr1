using labr1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace labr1.Controllers
{
    public class HomeController : Controller
    {
        BankContext db = new BankContext();

        public ActionResult Index(string credit, string login, string sortOrder)
        {
            var customers = db.Customers1.AsQueryable();

            // Фільтрація за кредитом
            if (!string.IsNullOrEmpty(credit))
            {
                customers = customers.Where(c => c.Credits.Any(cr => cr.Name == credit));
            }

            // Фільтрація за логіном
            if (!string.IsNullOrEmpty(login))
            {
                customers = customers.Where(c => c.Login == login);
            }

            // Сортування за непогашеним кредитом
            switch (sortOrder)
            {
                case "asc":
                    customers = customers.OrderBy(c => c.CreditOutstanding);
                    break;
                case "desc":
                    customers = customers.OrderByDescending(c => c.CreditOutstanding);
                    break;
                default:
                    break;
            }

            // Підготовка моделі для представлення
            var model = new CustomerListViewModel
            {
                Customers = customers.ToList(),
                Credits = new SelectList(db.Credits.ToList(), "Name", "Name"),
                Login = new SelectList(db.Customers1.ToList(), "Login", "Login")
            };

            return View(model);
        }



        public ActionResult Details(int CustomerId = 0)
        {
            Customers customers = db.Customers1.Find(CustomerId);

            if (customers == null)
            {
                return HttpNotFound();
            }
            return View(customers);
        }

        public ActionResult Filter(string credit, string login)
        {
            var customers = db.Customers1.AsQueryable();

            if (!string.IsNullOrEmpty(credit))
            {
                customers = customers.Where(c => c.Credits.Any(cr => cr.Name == credit));
            }

            if (!string.IsNullOrEmpty(login))
            {
                customers = customers.Where(c => c.Login == login);
            }

            return View("Index", customers.ToList());
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
                ViewBag.Credits = db.Credits.ToList();
                return View(customers);
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult EditClient(Customers customers, int[] selectedCredits)
        {
            Customers newcustomers = db.Customers1.Find(customers.CustomerID);
            newcustomers.FirstName = customers.FirstName;
            newcustomers.LastName = customers.LastName;

            newcustomers.Credits.Clear();
            if(selectedCredits != null)
            {
                foreach (var c in db.Credits.Where(co=>selectedCredits.Contains(co.CreditId)))
                {
                    newcustomers.Credits.Add(c);
                }
            }

            db.Entry(newcustomers).State = EntityState.Modified;
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
