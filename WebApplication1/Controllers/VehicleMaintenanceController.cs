using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DATA;
using WebApplication1.DTO;
namespace WebApplication1.Controllers
{
    public class VehicleMaintenanceController : ApiController
    {
        // POST: api/VehicleMaintenance
        [HttpPost]
        [Route("api/vehicleMaintenance/post")]
        public IHttpActionResult Post([FromBody] VehicleMaintenceDTO vecmain)
        {
            igroup196DbContext1 db = new igroup196DbContext1();
            try
            {
                var maintenceList = db.VehicleMaintenance.Where(x => x.VehicleList.licensePlateNum == vecmain.vehicle_id).Select(x=> new VehicleMaintenceDTO()
                {
                   maintenance_id=x.maintenance_id,
                    maintenance_date=x.maintenance_date,
                    maintenance_description=x.maintenance_description,
                    garageName=x.garageName,
                    vehicle_id=x.vehicle_id_fk


                });


                return Ok(maintenceList);

            }
            catch (Exception)
            {

                return BadRequest("Cant Get Vehicle Maintenance list, Wrong Vehicle Number");
            }




        }

        
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/VehicleMaintenance/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/VehicleMaintenance/5
        public void Delete(int id)
        {
        }
    }
}
