using CarDealershipApp.Models.Queries;
using CarDealershipApp.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealershipApp.ViewModels
{
    public class HomeViewModel
    {
        public List<FeaturedVehicleItem> Vehicles { get; set; }
        public List<Special> Specials { get; set; }
    }
}