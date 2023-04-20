using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DATA;
using WebApplication2check.DTO;
using NLog;
namespace WebApplication2check.Controllers
{
    public class CustomersController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();


        // GET: api/Customers/5
        [HttpGet]
        [Route("api/customers/get")]
        public IHttpActionResult Get()
        {
            igroup196DbContext1 db = new igroup196DbContext1();
            try
            {
                var customers = db.Customers.Select(x => new CustomersDTO()
                {
                    clientNumber = x.clientNumber,
                    clientName = x.clientName,
                    clientAddress = x.clientAddress,
                    clientEmail = x.clientEmail,
                    clientFirstName = x.clientFirstName,
                    clientLastName = x.clientLastName,
                    clientPhoneNum = x.clientPhoneNum,
                    representiveEmail = x.representiveEmail





                });

                return Ok(customers);

            }
            catch (Exception)
            {
                logger.Error("Cant Connect with DataBase ");
                return BadRequest("Cant upload Customers List");
            }




        }

        // POST: api/Customers
        [HttpPost]
        [Route("api/customers/post")]
        public IHttpActionResult Post([FromBody] CustomersDTO cus)
        {
            igroup196DbContext1 db = new igroup196DbContext1();
            try
            {

                var newCustomer = new Customers
                {

                    clientNumber = cus.clientNumber,
                    clientName = cus.clientName,
                    clientAddress = cus.clientAddress,
                    clientEmail = cus.clientEmail,
                    clientFirstName = cus.clientFirstName,
                    clientLastName = cus.clientLastName,
                    clientPhoneNum = cus.clientPhoneNum,
                    isClientActive = cus.isClientActive,

                    representiveEmail = cus.representiveEmail




                };
                db.Customers.Add(newCustomer);
                db.SaveChanges();
                logger.Info("New Customer Added");
                return Ok("new Customer added");

            }
            catch (Exception)
            {
                logger.Error("Cant Upload Costumer");
                return BadRequest("Cant Add New Customer");
            }


        }

        // PUT: api/Customers/5
        [HttpPut]
        [Route("api/customers/put")]
        public IHttpActionResult Put([FromBody] CustomersDTO cus)
        {
            igroup196DbContext1 db = new igroup196DbContext1();
            Customers customer = db.Customers.Where(x => x.clientNumber == cus.clientNumber).FirstOrDefault();
            try
            {
                if (customer != null)
                {
                    customer.clientNumber = cus.clientNumber;
                    customer.clientName = cus.clientName;
                    customer.clientAddress = cus.clientAddress;
                    customer.clientEmail = cus.clientEmail;
                    customer.clientFirstName = cus.clientFirstName;
                    customer.clientLastName = cus.clientLastName;
                    customer.clientPhoneNum = cus.clientPhoneNum;
                    customer.isClientActive = cus.isClientActive;
                    customer.representiveEmail = cus.representiveEmail;
                    db.SaveChanges();
                    logger.Info("Customer Updated");
                    return Ok("Customer Updated");
                }
                else
                {
                    logger.Error("Error Updating Costumer");
                    return BadRequest("Costumer Not found");
                }

            }
            catch (Exception)
            {
                logger.Error("exception updating Customer");
                return BadRequest("cant Update Customer");
            }




        }

        // DELETE: api/Customers/5

        [HttpDelete]
        [Route("api/customers/delete")]
        public IHttpActionResult Delete([FromBody] CustomersDTO cus)
        {
            igroup196DbContext1 db = new igroup196DbContext1();
            var customerD = db.Customers.FirstOrDefault(x => x.clientNumber == cus.clientNumber);
            if (customerD != null)
            {
                db.Customers.Remove(customerD);
                db.SaveChanges();
                logger.Info("Customer Deleted");
                return Ok("Customer Deleted");
            }
            else
            {
                logger.Error("Error Deleting Costumer");
                return BadRequest("customer Not Found");
            }

        }


    }
}
