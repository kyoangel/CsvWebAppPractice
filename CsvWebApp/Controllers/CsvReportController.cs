using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CsvWebApp.Controllers
{
    public class CsvReportController : Controller
    {
        // GET: CsvReport
        public ActionResult Report(string csvFile1, string csvFile2)
        {
            //Please prepare two csv files into CsvFiles Folder

            //Please use Server.Map("CsvFiles/" + csvFile1); to read/get file
            //Please use Server.Map("CsvFiles/" + csvFile2); to read/get file


            //please implement convert csvFile1 to your define object List1

            //please implement convert csvFile2 to your define object List2

            //please create query to join List1 & List2 and filter to List3

            //please return List3 to view, then dynamic convert List3 to HTML Table in Report.cshtml View
            return View();
        }
    }
}