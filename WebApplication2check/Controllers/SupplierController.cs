﻿using System;
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
    public class SupplierController : ApiController
    {
        // GET: api/Supplier
        private static Logger logger = LogManager.GetCurrentClassLogger();

        // GET: api/Supplier/5

        [HttpGet]
        [Route("api/supplier/get")]
        public IHttpActionResult Get()
        {
            igroup196DbContext1 db = new igroup196DbContext1();

            try
            {
                var suppliers = db.Supplier.Select(x => new SupplierDTO()
                {
                    businessNumber = x.businessNumber,
                    companyAddress = x.companyAddress,
                    companyEmail = x.companyEmail,
                    repName = x.repName,
                    repLastName = x.repLastName,
                    repEmailAddress = x.repEmailAddress,
                    StartWorkDate = x.StartWorkDate,
                    isSupplierActive = x.isSupplierActive,
                    employee_id = x.employee_id




                });
                return Ok(suppliers);
            }
            catch (Exception)
            {
                logger.Error("Cant load suppliers");
                return BadRequest("Error");
                

            }






        }


        // POST: api/Supplier
        [HttpPost]
        [Route("api/supplier/post")]
        public IHttpActionResult Post([FromBody] SupplierDTO sup)
        {
            igroup196DbContext1 db = new igroup196DbContext1();
            try
            {
                var newSupplier = new Supplier
                {
                    businessNumber = sup.businessNumber,
                    companyAddress = sup.companyAddress,
                    companyEmail = sup.companyEmail,
                    repName = sup.repName,
                    repLastName = sup.repLastName,
                    repEmailAddress = sup.repEmailAddress,
                    StartWorkDate = sup.StartWorkDate,
                    isSupplierActive = sup.isSupplierActive,
                    employee_id = sup.employee_id

                };

                db.Supplier.Add(newSupplier);
                db.SaveChanges();
                logger.Info("new supplier added");
                return Ok("ok");


            }
            catch (Exception)
            {
                logger.Error("cant add supplier");
                return BadRequest("Error");
            }





        }

        // PUT: api/Supplier/5
        public void Put(int id, [FromBody] string value)
        {
        }
        [HttpPut]
        [Route("api/supplier/put")]
        public IHttpActionResult Put([FromBody] SupplierDTO sup)
        {
            igroup196DbContext1 db = new igroup196DbContext1();
            Supplier sup1 = db.Supplier.Where(x => x.businessNumber == sup.businessNumber).FirstOrDefault();
            try
            {
                if (sup1 != null)
                {
                    sup1.businessNumber = sup.businessNumber;
                    sup1.companyAddress = sup.companyAddress;
                    sup1.companyEmail = sup.companyEmail;
                    sup1.repName = sup.repName;
                    sup1.repLastName = sup.repLastName;
                    sup1.repEmailAddress = sup.repEmailAddress;
                    sup1.StartWorkDate = sup.StartWorkDate;
                    sup1.isSupplierActive = sup.isSupplierActive;
                    sup1.employee_id = sup.employee_id;

                    db.SaveChanges();
                    logger.Info($"supplier {sup.businessNumber} updated");
                    return Ok("supplier updated");
                }
                else
                {
                    logger.Error("cant update supplier");
                    return BadRequest("supplier not found cant update");
                    
                }
                
            }
            catch (Exception)
            {

                return BadRequest("cant update");
            }




        }
        // DELETE: api/Supplier/5
        [HttpDelete]
        [Route("api/supplier/delete")]
        public IHttpActionResult Delete([FromBody] SupplierDTO sup)
        {
            igroup196DbContext1 db = new igroup196DbContext1();
            var supplierD = db.Supplier.FirstOrDefault(x => x.businessNumber == sup.businessNumber);
            if (supplierD != null)
            {
                db.Supplier.Remove(supplierD);
                db.SaveChanges();
                logger.Info($"supplier {sup.businessNumber} deleted");
                return Ok("supplier deleted");

            }
            else
            {
                logger.Error("supplier not deleted");
                return BadRequest("Error not deleted");
                
            }

        }
    }
}
