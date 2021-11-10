using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealershipApp.Models.Tables
{
    public class Sale
    {
        public int SaleID { get; set; }
        public int VehicleID { get; set; }
    
        public int StateID { get; set; }

        public int PurchaseTypeID { get; set; }
   
        public string User { get; set; }
    
        public string UserID { get; set; }
     
        public int Vin { get; set; }
        [Required]
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }
        [Required]
        public string CustomerAddress1 { get; set; }
        public string CustomerAddress2 { get; set; }
        public string CustomerAddress { get; set; }
        [Required]
        public string CustomerCity { get; set; }
        [Required]
        public string CustomerZipcode { get; set; }
        public decimal PurchasePrice { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}
