using CarDealershipApp.Data.Factories;
using CarDealershipApp.Models.Queries;
using CarDealershipApp.Models.Tables;
using CarDealershipApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealershipApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        { 
            var model = new HomeViewModel();
            model.Vehicles = VehicleRepositoryFactory.GetRepository().GetFeatured();
            model.Specials = SpecialsRepositoryFactory.GetRepository().GetAll();

            return View(model);
        }

        public ActionResult Contact(int? Vin )
        {
            ViewBag.Message = "Send us a message.";
            var model = new Message();
            if(Vin != null)
            { 
                model.MessageText = "I'm interested in the vehicle with Vin # " + Vin.ToString() + ".";
            }
            return View(model);
        }

        public ActionResult Specials()
        {
            var model = new HomeViewModel();
            model.Specials = SpecialsRepositoryFactory.GetRepository().GetAll();

            return View(model);
        }

        [HttpPost]
        public ActionResult AddMessage(Message message)
        {
            var repo = MessageRepositoryFactory.GetRepository();

            if(message.Phone == null && message.Email == null)
            {
                ModelState.AddModelError("", "Please enter either a phone number or email address.");
            }

            if (ModelState.IsValid)
            {
                repo.Add(message);

                return RedirectToAction("Index");
            }
            else
            {
                return View("Contact", message);
            }
            
        }
    }
}