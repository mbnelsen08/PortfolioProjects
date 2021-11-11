using CarDealershipApp.Data.Factories;
using CarDealershipApp.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealershipApp.Controllers
{
    public class ReportsController : Controller
    {
        // GET: Report
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Inventory()
        {
            List<InventoryReportItem> report = new List<InventoryReportItem>();
            var repo = VehicleRepositoryFactory.GetRepository();
            report = repo.GetInventoryReport();

            return View(report);
        }

        public ActionResult Sales()
        {
            return View();
        }
    }
}