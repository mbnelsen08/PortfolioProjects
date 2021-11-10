using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealershipApp.Models.Tables
{
    public class Vehicle
    {
        public int VehicleID { get; set; }
        public int MakeID { get; set; }
        public string MakeName { get; set; }
        public int ModelID { get; set; }
        public string ModelName { get; set; }
        public int ExteriorColorID { get; set; }
        public string ExteriorColor { get; set; }
        public int InteriorColorID { get; set; }
        public string InteriorColor { get; set; }
        public int BodyStyleID { get; set; }
        public string Style { get; set; }
        public int TransmissionID { get; set; }
        public string Type { get; set; }
        public int Year { get; set; }
        public int Mileage { get; set; }
        public int Vin { get; set; }
        public decimal Msrp { get; set; }
        public decimal SalePrice { get; set; }
        public string Description { get; set; }
        public string ImageFileName { get; set; }
        public bool NewOld { get; set; }
        public bool Featured { get; set; }
        public bool Sold { get; set; }
    }
}
