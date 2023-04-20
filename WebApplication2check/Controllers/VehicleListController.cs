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
    public class VehicleListController : ApiController
    {
        // GET: api/VehicleList

        private static Logger logger = LogManager.GetCurrentClassLogger();
        // GET: api/VehicleList/5
        [HttpGet]
        [Route("api/vehicleList/get")]
        public IHttpActionResult Get()
        {
            igroup196DbContext1 db = new igroup196DbContext1();
            try
            {
                var vehicles = db.VehicleList.Select(x => new VehicleListDTO()
                {
                    licensePlateNum = x.licensePlateNum,
                    vehicleType = x.vehicleType,
                    vehicleColor = x.vehicleColor,
                    licenseType = x.licenseType,
                    vehicleOwnership = x.vehicleOwnership,
                    manufacturingYear = x.manufacturingYear



                });


                return Ok(vehicles);

            }
            catch (Exception)
            {
                logger.Error("cant fetch car list");
                return BadRequest("cant get vehicle list");
            }




        }

        // POST: api/VehicleList
        [HttpPost]
        [Route("api/vehicleList/post")]
        public IHttpActionResult Post([FromBody] VehicleListDTO vec)
        {
            igroup196DbContext1 db = new igroup196DbContext1();
            try
            {
                var newVehicle = new VehicleList
                {
                    licensePlateNum = vec.licensePlateNum,
                    vehicleType = vec.vehicleType,
                    vehicleColor = vec.vehicleColor,
                    licenseType = vec.licenseType,
                    vehicleOwnership = vec.vehicleOwnership,
                    manufacturingYear = vec.manufacturingYear


                };
                db.VehicleList.Add(newVehicle);
                db.SaveChanges();
                logger.Info("New Vehicle Added");
                return Ok("Added New Vehicle");
            }
            catch (Exception)
            {
                logger.Error("cant add new vehicle");
                return BadRequest("Cant Add New Vehicle");
            }



        }
        // PUT: api/VehicleList/5
        [HttpPut]
        [Route("api/vehicleList/put")]
        public IHttpActionResult Put([FromBody] VehicleListDTO vec)
        {
            igroup196DbContext1 db = new igroup196DbContext1();
            VehicleList vec1 = db.VehicleList.Where(x => x.licensePlateNum == vec.licensePlateNum).FirstOrDefault();
            try
            {
                if (vec1 != null)
                {
                    vec1.licensePlateNum = vec.licensePlateNum;
                    vec1.vehicleType = vec.vehicleType;
                    vec1.vehicleColor = vec.vehicleColor;
                    vec1.licenseType = vec.licenseType;
                    vec1.vehicleOwnership = vec.vehicleOwnership;
                    vec1.manufacturingYear = vec.manufacturingYear;

                    db.SaveChanges();
                    logger.Info($"vehicle number {vec.licensePlateNum} updated");
                    return Ok("vehicle Updated");
                }
                else
                {
                    logger.Error("Cant update Vehicle");
                    return BadRequest("cant update vehicle");
                }
                
            }
            catch (Exception)
            {
                logger.Error("Exception in Vehicle API");
                return BadRequest("cant Update Vehicle");
            }





        }

        // DELETE: api/VehicleList/5
        [HttpDelete]
        [Route("api/vehicleList/delete")]
        public IHttpActionResult Delete([FromBody] VehicleListDTO vec)
        {
            igroup196DbContext1 db = new igroup196DbContext1();

            var vehicleD = db.VehicleList.FirstOrDefault(x => x.licensePlateNum == vec.licensePlateNum);
            if (vehicleD != null)
            {
                db.VehicleList.Remove(vehicleD);
                db.SaveChanges();
                logger.Info($"Vehicle {vec.licensePlateNum} deleted");
                return Ok("vehicle Deleted");
                

            }
            else
            {
                logger.Error("Cant delete in Vehicle API");
                return BadRequest("Vehicle Not Found Didnt Delete");
            }


        }
    }
}
