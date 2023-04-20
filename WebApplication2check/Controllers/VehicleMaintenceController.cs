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
    public class VehicleMaintenanceController : ApiController
    {
        // POST: api/VehicleMaintenance
        private static Logger logger = LogManager.GetCurrentClassLogger();
        [HttpPost]
        [Route("api/vehicleMaintenance/add")]
        public IHttpActionResult Post([FromBody] VehicleMaintenceDTO vecmain)
        {
            igroup196DbContext1 db = new igroup196DbContext1();
            try
            {
                var maintenceList = db.VehicleMaintenance.Where(x => x.VehicleList.licensePlateNum == vecmain.vehicle_id).Select(x => new VehicleMaintenceDTO()
                {
                    maintenance_id = x.maintenance_id,
                    maintenance_date = x.maintenance_date,
                    maintenance_description = x.maintenance_description,
                    garageName = x.garageName,
                    vehicle_id = x.vehicle_id_fk


                });


                return Ok(maintenceList);

            }

            catch (Exception)
            {

                return BadRequest("Cant Get Vehicle Maintenance list, Wrong Vehicle Number");
            }




        }



        [HttpPost]
        [Route("api/vehicleAdd/post")]
        public IHttpActionResult Post([FromBody] VehicleMaintenance main)
        {
            igroup196DbContext1 db = new igroup196DbContext1();
            try
            {
                var newTipul = new VehicleMaintenance
                {
                   
                    maintenance_id=main.maintenance_id,
                    maintenance_date=main.maintenance_date,
                    maintenance_description=main.maintenance_description,
                    garageName=main.garageName,
                    vehicle_id_fk=main.vehicle_id_fk

                };
                db.VehicleMaintenance.Add(newTipul);
                db.SaveChanges();
                logger.Info("New maintence service Added");
                return Ok("Added New maintence service");
            }
            catch (Exception)
            {
                logger.Error("cant add new maintence service");
                return BadRequest("Cant Add maintence service");
            }



        }



        [HttpDelete]
        [Route("api/vehicleList/delete")]
        public IHttpActionResult Delete([FromBody] VehicleMaintenceDTO vec)
        {
            igroup196DbContext1 db = new igroup196DbContext1();

            var mainenceD = db.VehicleMaintenance.FirstOrDefault(x => x.maintenance_id == vec.maintenance_id);
            if (mainenceD != null)
            {
                db.VehicleMaintenance.Remove(mainenceD);
                db.SaveChanges();
                logger.Info($"Vehicle {vec.maintenance_id} deleted");
                return Ok("vehicle Deleted");


            }
            else
            {
                logger.Error("Cant delete in maintence API");
                return BadRequest("Vehicle Not Found Didnt Delete");
            }


        }


    }
}
