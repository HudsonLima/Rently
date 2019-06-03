using Rently.Models;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rently.ViewModels;

namespace Rently.Controllers
{
    public class CustomersController : Controller
    {

        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        public ActionResult Index()
        {
            try
            {
                var customers = _context.Customers.Include(c => c.MembershipType).ToList();
                return View(customers);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult Details(int id)
        {
            
            var customer = _context.Customers
                                  .Include(c => c.MembershipType)
                                  .SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MemberShipTypes = membershipTypes
            };

            return View("CustomerForm",viewModel);
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {

            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MemberShipTypes = _context.MembershipTypes.ToList()
                };
            return View("CustomerForm", viewModel);
            }

            if(customer.Id == 0)
            { 
            _context.Customers.Add(customer);
            
            }
            else
            {
                var cursomerInDB = _context.Customers.Single(c => c.Id == customer.Id);

                cursomerInDB.Name = customer.Name;
                cursomerInDB.Birthdate = customer.Birthdate;
                cursomerInDB.MembershipTypeId = customer.MembershipTypeId;
                cursomerInDB.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;                
            }

            _context.SaveChanges();

            return RedirectToAction("Index","Customers");
        }

        public ActionResult Edit(int Id)
        {

            var customer = _context.Customers.SingleOrDefault(c => c.Id == Id);

            if (customer == null)
                return HttpNotFound();


            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MemberShipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }
    }
}