using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CarDealershipApp.Models.Tables
{
    public class Message 
    {
        public int MessageID { get; set; }
        [Required(ErrorMessage ="Please enter your name.")]
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        [Required(ErrorMessage ="Please enter a message.")]
        public string MessageText { get; set; }

        
    }
}
