using CarDealershipApp.Data.Factories;
using CarDealershipApp.Models;
using CarDealershipApp.Models.Tables;
using CarDealershipApp.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealershipApp.Controllers
{
    public class SalesController : Controller
    {

       
        // GET: Sales
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Purchase(int id)
        {
            var vehicleRepo = VehicleRepositoryFactory.GetRepository();
            var vehicle = vehicleRepo.GetVehicleByID(id);
            var model = new PurchaseViewModel();
            model.Vehicle = vehicle;
            var sale = new Sale();
            model.Sale = sale;
           
            return View(model);
        }
        [HttpPost]
        public ActionResult SavePurchase(PurchaseViewModel model)
        {
            var salesRepo = SalesRepositoryFactory.GetRepository();
            var vehicleRepo = VehicleRepositoryFactory.GetRepository();
            var vehicle = vehicleRepo.GetVehicleByID(model.Sale.VehicleID);
            model.Sale.UserID = User.Identity.GetUserId();
            model.Sale.User = User.Identity.GetUserName();
            model.Sale.CustomerAddress = model.Sale.CustomerAddress1 + model.Sale.CustomerAddress2;

            if (model.Sale.CustomerEmail == null && model.Sale.CustomerPhone == null)
            {
                ModelState.AddModelError("", "Please enter either a phone number or email address.");
            }

            int compareVal = decimal.Compare(model.Sale.PurchasePrice, vehicle.Msrp);
            decimal percent = decimal.Multiply(vehicle.SalePrice, (decimal)0.95);
            decimal compareVal2 = decimal.Compare(model.Sale.PurchasePrice, percent);

            if(compareVal > 0 || compareVal2<0)
            {
                ModelState.AddModelError("", "Price must be between " + percent.ToString("C") + " and " + vehicle.Msrp.ToString("C"));
            }
           

            if (ModelState.IsValid)
            {
                salesRepo.Add(model.Sale);
                vehicleRepo.Purchase(model.Sale.VehicleID);
                return RedirectToAction("Index");
            }
            else
            {
                model.Vehicle = vehicle;
                return View("Purchase", model);
            }
        }
    }
}