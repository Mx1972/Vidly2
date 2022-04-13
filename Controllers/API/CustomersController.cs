using AutoMapper;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using Vidly2.DTOs;
using Vidly2.Models;

namespace Vidly2.Controllers.API
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult GetCustomers()
        {
            if (_context.Customers.Count() == 0)
            {   
                return NotFound();
            }

            var customersDtos = _context.Customers
                .Include(c => c.MembershipType)
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);

            return Ok(customersDtos);
        }


        [HttpGet]
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c=>c.Id == id);

            if (customer == null)
                return NotFound();
            
            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }

        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;

            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }

        [HttpPut]
        public IHttpActionResult UpdateCustomer(CustomerDto customerdto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == customerdto.Id);

            if (customerInDb == null)
                return NotFound();


            Mapper.Map<CustomerDto, Customer>(customerdto, customerInDb);
           
            return Ok(_context.SaveChanges());

        }


        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {       
            try
            {
                if (!ModelState.IsValid || id <= 0)
                    return BadRequest("Invalid Customer Id, Customer Not Deleted");

                var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

                if (customerInDb == null)
                    return NotFound();

                _context.Customers.Remove(customerInDb);
                _context.SaveChanges();

                return Ok("Customer with id: " + customerInDb.Id + " and Name: " + customerInDb.Name + " was deleted successfuly");
            }
            catch (Exception)
            {
                return InternalServerError();
            }

        }
    }
}
