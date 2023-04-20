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
    public class InventoryItemsController : ApiController
    {
        igroup196DbContext1 db = new igroup196DbContext1();

        // GET: api/InventoryItems
        private static Logger logger = LogManager.GetCurrentClassLogger();
        [HttpGet]
        [Route("api/inventoryItems/get")]
        public IHttpActionResult Get()
        {


            try
            {
                var inventoryItems1 = db.InventoryItems.Select(x => new InventoryItemsDTO()
                {
                    itemSerialNum = x.itemSerialNum,
                    itemName = x.itemName,
                    itemDescription = x.itemDescription,
                    itemAmount = x.itemAmount,
                    employee_id = x.employee_id,
                    itemPicture = x.itemPicture




                });
                return Ok(inventoryItems1);
            }
            catch (Exception)
            {
                logger.Error("Problem loading inventory Data");
                return BadRequest("Error");

            }






        }




        // POST: api/InventoryItems

        [HttpPost]
        [Route("api/inventoryItems/post")]
        public IHttpActionResult Post([FromBody] InventoryItemsDTO items)
        {
            igroup196DbContext1 db = new igroup196DbContext1();


            try
            {
                var newItem = new InventoryItems
                {
                    employee_id = items.employee_id,
                    itemSerialNum = items.itemSerialNum,
                    itemAmount = items.itemAmount,
                    itemDescription = items.itemDescription,
                    itemName = items.itemName,
                    itemPicture = items.itemPicture





                };

                db.InventoryItems.Add(newItem);
                db.SaveChanges();
                logger.Info("New Item Added");

                return Ok("New Item Added");
            }
            catch (Exception)
            {
                logger.Error("Cant Upload New Item");
                return BadRequest("Error");
            }


        }


        // PUT: api/InventoryItems/5
        [HttpPut]
        [Route("api/inventoryItems/put")]
        public IHttpActionResult Put([FromBody] InventoryItemsDTO items)
        {
            igroup196DbContext1 db = new igroup196DbContext1();

            InventoryItems mlay = db.InventoryItems.Where(x => x.itemSerialNum == items.itemSerialNum).FirstOrDefault();
            try
            {
                if (mlay != null)
                {
                    mlay.itemName = items.itemName;
                    mlay.itemDescription = items.itemDescription;
                    mlay.itemAmount = items.itemAmount;
                    mlay.itemPicture = items.itemPicture;
                    db.SaveChanges();

                }
                return Ok("ok");
            }
            catch (Exception)
            {

                return BadRequest("Error");
            }


        }

        // DELETE: api/InventoryItems/5
        [HttpDelete]
        [Route("api/inventoryItems/delete")]
        public IHttpActionResult Delete([FromBody] InventoryItemsDTO item)
        {
            igroup196DbContext1 db = new igroup196DbContext1();
            var itemD = db.InventoryItems.FirstOrDefault(x => x.itemSerialNum == item.itemSerialNum);
            if (itemD != null)
            {
                db.InventoryItems.Remove(itemD);
                db.SaveChanges();
                return Ok("Item deleted");

            }
            else
            {
                return BadRequest("Error");
            }

        }
    }
}
