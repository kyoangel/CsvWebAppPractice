using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CsvWebApp.Models
{
    public class Shipper
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime OrderDate { get; set; }
        public int ShipperID { get; set; }
    }
}