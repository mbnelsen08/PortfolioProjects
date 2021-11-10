using FlooringMaster.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMaster.Models.Responses
{
    public class DisplayResponse : Response
    {
        public List<Order> orders { get; set; }
        public DateTime date { get; set; }
    }
}
