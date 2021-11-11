using CarDealershipApp.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealershipApp.ViewModels
{
    public class SpecialsAdminViewModel
    {
        public List<Special> Specials { get; set; }
        public Special SpecialToAdd { get; set; }
    }
}