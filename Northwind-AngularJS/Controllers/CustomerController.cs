using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Northwind_AngularJS.Models;

namespace Northwind_AngularJS.Controllers
{
    public class CustomerController : ApiController
    {
        private NorthwindEntities db = new NorthwindEntities();

        // GET api/Customer
        public IEnumerable<Customer> GetCustomers()
        {
            return db.Customers.AsEnumerable();
        }

        // GET api/Customer/5
        public Customer GetCustomer(string id)
        {
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return customer;
        }

        // PUT api/Customer/5
        public HttpResponseMessage PutCustomer(string id, Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != customer.CustomerID)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(customer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/Customer
        public HttpResponseMessage PostCustomer(Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, customer);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = customer.CustomerID }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Customer/5
        public HttpResponseMessage DeleteCustomer(string id)
        {
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Customers.Remove(customer);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, customer);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}