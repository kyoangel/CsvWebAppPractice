using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CsvWebApp.Models
{
    public class ResultEntity
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public DateTime OrderDate { get; set; }
    }
}