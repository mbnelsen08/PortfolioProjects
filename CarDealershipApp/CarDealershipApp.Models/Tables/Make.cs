using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealershipApp.Models.Tables
{
    public class Make
    {
        public int MakeID { get; set; }
        [Required]
        public string MakeName { get; set; }
        public DateTime DateAdded { get; set; }
        public string UserEmail { get; set; }
    }
}
