using CarDealershipApp.Data.ADO;
using CarDealershipApp.Models;
using CarDealershipApp.Models.Tables;
using CarDealershipApp.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CarDealershipApp.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Vehicles()
        {
            return View();
        }

        public ActionResult Users()
        {

            var repo = new UsersRepositoryADO();
            List<UserWithRoleName> users = repo.GetAll();

            return View(users);
        }

        public ActionResult AddUser(RegisterViewModel model)
        {
            if(model.FirstName == null && model.LastName == null)
            {
                ModelState.Clear();
            }
            return View(model);
        }



        [HttpPost]
        public ActionResult EditUser(string id)
        {
            return View();
        }

        public ActionResult Makes()
        {
            return View();
        }

        public ActionResult Models()
        {
            return View();
        }

        public ActionResult Specials()
        {
            return View();
        }
    }
}