using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2check.DTO
{
    public class InventoryItemsDTO
    {
        public int itemSerialNum;
        public string itemName;
        public string itemDescription;
        public int? itemAmount;
        public int? employee_id;
        public string itemPicture;
    }
}