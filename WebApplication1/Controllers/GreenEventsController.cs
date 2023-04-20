using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DATA;
using WebApplication1.DTO;
using NLog;
namespace WebApplication1.Controllers
{
    public class GreenEventsController : ApiController
    {
        
        private static Logger logger = LogManager.GetCurrentClassLogger();

        
        [HttpGet]
        [Route("api/GreenEvents/get")]
        public IHttpActionResult Get()
        {
            igroup196DbContext1 db = new igroup196DbContext1();
            try
            {
                var events = db.GreenEvents.Select(x => new GreenEventsDTO()
                {
                    eventSerialNum = x.eventSerialNum,
                    event_name = x.event_name,
                    event_address = x.event_address,
                    event_startdate = x.event_startdate,
                    event_enddate = x.event_enddate,
                    isEventActive = x.isEventActive,
                    employee_id = x.employee_id,
                    clientNumber=x.clientNumber,
                    event_notes=x.event_notes
                    
                });

                return Ok(events);
            }
            catch (Exception)
            {
                logger.Error("Cant fetch Event Data");
                return BadRequest("Cant upload Event List");
            }



        }

        // POST: api/GreenEvents
        [HttpPost]
        [Route("api/GreenEvents/post")]
        public IHttpActionResult Post([FromBody] GreenEventsDTO events) 
        {
            igroup196DbContext1 db = new igroup196DbContext1();
            try
            {

                var newEvent = new GreenEvents
                {

                    eventSerialNum = events.eventSerialNum,
                    event_name = events.event_name,
                    event_address = events.event_address,
                    event_startdate = events.event_startdate,
                    event_enddate = events.event_enddate,
                    isEventActive = events.isEventActive,
                    employee_id = events.employee_id,
                    event_notes=events.event_notes,
                    clientNumber=events.clientNumber
                    



                };
                db.GreenEvents.Add(newEvent);
                db.SaveChanges();
                logger.Info("New Event Added");
                return Ok("New Event Added");
            }
            catch (Exception)
            {
                logger.Error("Cant Upload Event");
                return BadRequest("Cant Add New Event");
            }


        }


        // PUT: api/GreenEvents/5
        [HttpPut]
        [Route("api/GreenEvents/put")]
        public IHttpActionResult Put([FromBody] GreenEventsDTO events) 
        {
            igroup196DbContext1 db = new igroup196DbContext1();
            GreenEvents events1 = db.GreenEvents.Where(x => x.eventSerialNum == events.eventSerialNum).FirstOrDefault();
            try
            {
                if (events1!=null)
                {
                    events1.eventSerialNum = events.eventSerialNum;
                    events1.event_name = events.event_name;
                    events1.event_address = events.event_address;
                    events1.event_startdate = events.event_startdate;
                    events1.event_enddate = events.event_enddate;
                    events1.isEventActive = events.isEventActive;
                    events1.employee_id = events.employee_id;
                    events1.clientNumber = events.clientNumber;
                    events1.event_notes = events.event_notes;
                    db.SaveChanges();
                    logger.Info($"Event {events.eventSerialNum} Updated");
                    return Ok("Event Updated");
                }

                else
                {
                    logger.Error("Event search failure");
                    return BadRequest("Event Number Not Found");
                }
            }
            catch (Exception)
            {
                logger.Warn("Execption updating events");
                return BadRequest("cant Update Event");
            }







        }

        // DELETE: api/GreenEvents/5
        [HttpDelete]
        [Route("api/GreenEvents/delete")]
        public IHttpActionResult Delete([FromBody] GreenEventsDTO events) 
        {
            igroup196DbContext1 db = new igroup196DbContext1();
            var eventD = db.GreenEvents.FirstOrDefault(x => x.eventSerialNum == events.eventSerialNum);
            if (eventD!=null)
            {
                db.GreenEvents.Remove(eventD);
                db.SaveChanges();
                logger.Info($"Event {events.eventSerialNum} deleted");
                return Ok("Event deleted");
            }
            else
            {
                logger.Error("Failure Deleting Event");
                return BadRequest("event Not Found Didnt Delete");
            }


        }
    }
}
