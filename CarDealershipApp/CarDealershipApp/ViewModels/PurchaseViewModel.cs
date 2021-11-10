using CarDealershipApp.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealershipApp.ViewModels
{
    public class PurchaseViewModel
    {
        public Vehicle Vehicle { get; set; }
        public Sale Sale { get; set; }
    }
}