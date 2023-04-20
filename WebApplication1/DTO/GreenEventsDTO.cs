using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.DTO
{
    public class GreenEventsDTO
    {
        public int eventSerialNum;
        public string event_name;
        public string event_address;
        public DateTime? event_startdate;
        public DateTime? event_enddate;
        public bool? isEventActive;
        public string event_notes;
        public int? employee_id;
        public int? clientNumber;
    }
}