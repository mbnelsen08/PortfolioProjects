using CarDealershipApp.Data.ADO;
using CarDealershipApp.Data.Factories;
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
            if(model.FirstName != null && model.LastName != null && model.Email != null && model.RoleName != null && model.Password != null)
            {
                ModelState.AddModelError("", "Error occured. Check is user name already exists.");
            }
            
            return View(model);
        }

        [HttpGet]
        public ActionResult EditUser(string id)
        {
            var repo = new UsersRepositoryADO();
            List<UserWithRoleName> users = repo.GetAll();
            UserWithRoleName user = users.FirstOrDefault(m => m.Id == id);
            EditUserViewModel model = new EditUserViewModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                RoleName = user.Role,
                Id = user.Id
            };
            return View(model);
        }

        public ActionResult Makes()
        {
            var repo = MakeRepositoryFactory.GetRepository();
            List<Make> makes = repo.GetAll();
            MakeViewModel model = new MakeViewModel
            {
                Makes = makes
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult MakeInsert(MakeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Makes", "Admin");
            }
            model.MakeToAdd.UserEmail = User.Identity.GetUserName();
            var repo = MakeRepositoryFactory.GetRepository();

            repo.Add(model.MakeToAdd);

            return RedirectToAction("Makes", "Admin");
        }

        public ActionResult Models()
        {
            var MakesRepo = MakeRepositoryFactory.GetRepository();
            var makes = MakesRepo.GetAll();
            var ModelsRepo = ModelRepositoryFactory.GetRepository();
            var models = ModelsRepo.GetAll();
            List<SelectListItem> items = new List<SelectListItem>();

            foreach(var make in makes)
            {
                items.Add(new SelectListItem { Text = make.MakeName, Value = make.MakeID.ToString()});
            }

            ViewBag.Makes = items;
            ModelViewModel viewModel = new ModelViewModel();
            Model modelToAdd = new Model();
            viewModel.Models = models;
            viewModel.ModelToAdd = modelToAdd;

            return View(viewModel);
        }

        public ActionResult ModelInsert(ModelViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Models", "Admin");
            }
            model.ModelToAdd.UserEmail = User.Identity.GetUserName();
            var repo = ModelRepositoryFactory.GetRepository();

            repo.Add(model.ModelToAdd);
            return RedirectToAction("Models", "Admin");
        }

        public ActionResult Specials()
        {
            var repo = SpecialsRepositoryFactory.GetRepository();
            SpecialsAdminViewModel model = new SpecialsAdminViewModel();

            model.Specials = repo.GetAll();

            return View(model);
        }

        
        public ActionResult SpecialDelete(int id)
        {
            var repo = SpecialsRepositoryFactory.GetRepository();
            repo.Delete(id);
            return RedirectToAction("Specials", "Admin");
        }

        public ActionResult SpecialInsert(SpecialsAdminViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Specials", "Admin");
            }
            var repo = SpecialsRepositoryFactory.GetRepository();
            repo.Add(model.SpecialToAdd);
            return RedirectToAction("Specials", "Admin");
        }
    }
}