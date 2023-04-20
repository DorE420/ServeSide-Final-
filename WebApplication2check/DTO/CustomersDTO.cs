using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2check.DTO
{
    public class CustomersDTO
    {
        public int clientNumber; //Primary key
        public string clientName;
        public string clientAddress;
        public string clientEmail;
        public string clientFirstName;
        public string clientLastName;
        public string clientPhoneNum;
        public string representiveEmail;
        public bool? isClientActive;
    }
}