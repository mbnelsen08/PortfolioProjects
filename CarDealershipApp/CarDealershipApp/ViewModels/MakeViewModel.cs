using CarDealershipApp.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealershipApp.ViewModels
{
    public class MakeViewModel
    {
        public List<Make> Makes { get; set; }
        public Make MakeToAdd { get; set; }
    }
}