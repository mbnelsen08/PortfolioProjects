using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealershipApp.Models.Queries
{
    public class FeaturedVehicleItem
    {
        public int VehicleID { get; set; }
        public int MakeID { get; set; }
        public int ModelID { get; set; }
        public string MakeName { get; set; }
        public string ModelName { get; set; }
        public int Year { get; set; }
        public decimal SalePrice { get; set; }
        public bool Featured { get; set; }
        public string ImageFileName { get; set; }
    }
}
