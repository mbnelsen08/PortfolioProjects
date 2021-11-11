namespace CarDealershipApp.Migrations
{
    using CarDealershipApp.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CarDealershipApp.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CarDealershipApp.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            // Load the user and role managers with our custom models
            var userMgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var roleMgr = new RoleManager<ApplicationRole>(new RoleStore<ApplicationRole>(context));

            // have we loaded roles already?
            if (roleMgr.RoleExists("admin@dealership.com") || roleMgr.RoleExists("sales@dealership.com") || roleMgr.RoleExists("disabled@dealership.com"))
                return;

            // create the admin role
            roleMgr.Create(new ApplicationRole() { Name = "admin" });
            roleMgr.Create(new ApplicationRole() { Name = "sales" });
            roleMgr.Create(new ApplicationRole() { Name = "disabled" });

            // create the default user
            var user = new ApplicationUser()
            {
                UserName = "admin@dealership.com",
                Email = "admin@dealership.com",
                LastName = "Admin",
                FirstName = "User",
                LockoutEnabled = true
            };

            var user2 = new ApplicationUser()
            {
                UserName = "sales@dealership.com",
                Email = "sales@dealership.com",
                LastName = "Sales",
                FirstName = "User",
                LockoutEnabled = true
            };

            var user3 = new ApplicationUser()
            {
                UserName = "disabled@dealership.com",
                Email = "disabled@dealership.com",
                LastName = "Disabled",
                FirstName = "User",
                LockoutEnabled = true,
                LockoutEndDateUtc = DateTime.Parse("1/1/2100")
            };

            // create the user with the manager class
            userMgr.Create(user, "Testing123@");
            userMgr.Create(user2, "Testing123@");
            userMgr.Create(user3, "Testing123@");

            // add the user to the admin role
            userMgr.AddToRole(user.Id, "admin");
            userMgr.AddToRole(user2.Id, "sales");
            userMgr.AddToRole(user3.Id, "disabled");
        }
    }
}
