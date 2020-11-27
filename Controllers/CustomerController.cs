using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Moviess.Models;
using Moviess.ViewModels;
using System.Data.Entity;

namespace Moviess.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            return View(customers);
        }


        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }


        public ViewResult New()
        {
            var membershiptypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel()
            {
                customer = new Customer(),
                MembershipTypes = membershiptypes
            };
            return View("CustomerForm", viewModel);
        }



        public ActionResult Edit (int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        //public RedirectToRouteResult Save(Customer customer)
        public ActionResult Save(Customer customer)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }

            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                

                customerInDb.Name = customer.Name;
                customerInDb.Add = customer.Add;
                customerInDb.City = customer.City;
                customerInDb.Zip = customer.Zip;
                customerInDb.Phone = customer.Phone;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeID = customer.MembershipTypeID;
                customerInDb.IsSubscribed = customer.IsSubscribed;

            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customer");
         }


        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer {Id = 1, Name = "Donald Trump", Add = "1600 Pennsylvania Avenua NW", City
                = "Washington", State = "DC", Phone = 2024561111, Zip = 20500},

                new Customer {Id = 2, Name = "Kyle Haun", Add = "1475 County Road 643", City
                = "Mountain Home", State = "AR", Phone = 8704211291, Zip = 72653},

                new Customer {Id = 3, Name = "Elvis Presley", Add = "3764 Elvis Presley Boulevard", City
                = "Memphis", State = "TN", Phone = 9013323322, Zip = 38116},

            };
        }


    }
}