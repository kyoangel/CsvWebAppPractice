using CsvWebApp.Models;
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
            if (csvFile1 == null)
            {
                csvFile1 = "sample1.csv";
            }

            if (csvFile2 == null)
            {
                csvFile2 = "sample2.csv";
            }

            csvFile1 = Server.MapPath("~/CsvFiles/" + csvFile1);
            csvFile2 = Server.MapPath("~/CsvFiles/" + csvFile2);

            var csvReader = new CsvReader();
            List<Customer> customerList = csvReader.ReadFile<Customer>(csvFile1);
            List<Shipper> shipperList = csvReader.ReadFile<Shipper>(csvFile2);

            var q1 = from tb1 in customerList
                     join tb2 in shipperList on tb1.CustomerID equals tb2.CustomerID
                     orderby tb1.CustomerName
                     select new ResultEntity
                     {
                         CustomerId = tb1.CustomerID,
                         CustomerName = tb1.CustomerName,
                         OrderDate = tb2.OrderDate
                     };

            var viewModel = new ReportViewModel();
            viewModel.Result = q1.ToList();

            return View(viewModel);
        }
    }
}