using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2check.DTO
{
    public class VehicleMaintenceDTO
    {
        public int maintenance_id;
        public DateTime? maintenance_date;
        public string maintenance_description;
        public string garageName;
        public int? vehicle_id;
    }
}