using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly2.Models;
using System.Data.Entity;
using Vidly2.ViewModels;

namespace Vidly2.Controllers
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
        
        // GET: Customer
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c=>c.MembershipType).ToList();
            if (customers == null)
                return HttpNotFound();

            return View(customers);
        }

        //[Route("customer/filter/{id:regex(\\d{1}):range(1,2)}")]
        public ActionResult GetCustomerById(int id)
        {
            Customer customer = _context.Customers.Include(c => c.MembershipType).Where(x => x.Id == id).SingleOrDefault();
            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
                    
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("CustomerForm", viewModel);

            }

             
            if(customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                Customer customerInDb = _context.Customers.Single(x => x.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.DOB = customer.DOB;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", customer);
        }

        
        public ActionResult Edit(int id)
        {
            Customer customer = _context.Customers.Include(c => c.MembershipType).Where(x => x.Id == id).SingleOrDefault();
            if (customer == null)
                customer = new Customer();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }
    }
    
}