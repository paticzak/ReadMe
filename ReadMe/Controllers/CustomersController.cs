using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReadMe.Models;
using ReadMe.ViewModels;

namespace ReadMe.Controllers
{
    public class CustomersController : Controller
    {
        // DbContext to access the database:
        private ApplicationDbContext _context;


        //initialize this private field int he contructor
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {           
            _context.Dispose();
        }

        public ActionResult CustomerForm()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes
            };
            return View(viewModel);
        }

        [HttpPost] // if my action modify data it should never be accesible by HttpGet
        public ActionResult Create(Customer customer)
        {
            _context.Customers.Add(customer); // it's not written to the database, it's just in a memory
            _context.SaveChanges(); // this written changes to database

            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id); // get the customers with id from the database

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);
        }

        // GET: /Users/
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            return View(customers);
        }

        // GET: /Users/Details/id
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
 
             if (customer == null)
                 return HttpNotFound();
 
             return View(customer);
         
        }
    }
}