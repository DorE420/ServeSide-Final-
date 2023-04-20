using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2check.DTO
{
    public class SupplierDTO
    {
        public int businessNumber;
        public string companyAddress;
        public string companyEmail;
        public string repName;
        public string repLastName;
        public string repEmailAddress;
        public DateTime? StartWorkDate;
        public bool? isSupplierActive;
        public int? employee_id;
    }
}