using CarDealershipApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealershipApp.ViewModels
{
    public class UsersAdminViewModel
    {
        public ApplicationUser User { get; set; }
        public string Role { get; set; }
    }
}