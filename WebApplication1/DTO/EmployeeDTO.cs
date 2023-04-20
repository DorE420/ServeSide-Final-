using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.DTO
{
    public class EmployeeDTO
    {
        public int employee_id;
        public string employee_name;
        public string employee_familyname;
        public string employee_pw;
         public string employee_gender;
        public string employee_PhoneNumber;
        public string employee_email;
        public DateTime? employee_startDate;
          public  bool? isActive;
        public string employee_picture;
    }
}