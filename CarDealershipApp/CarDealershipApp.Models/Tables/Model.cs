using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealershipApp.Models.Tables
{
    public class Model
    {
        public int ModelID { get; set; }
        [Required]
        public int MakeID { get; set; }
        [Required]
        public string ModelName { get; set; }
        public string MakeName { get; set; }
        public DateTime DateAdded { get; set; }
        public string UserEmail { get; set; }
    }
}
