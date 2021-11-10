using CarDealershipApp.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealershipApp.ViewModels
{
    public class ModelViewModel
    {
        public List<Model> Models { get; set; }
        public Model ModelToAdd { get; set; }
    }
}