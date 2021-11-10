using FlooringMaster.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View
{
    public class ConsoleIO
    {
        public static void DisplayOrder(Order order, DateTime date)
        {
            Console.WriteLine("*******************************");
            Console.WriteLine($"{order.OrderNumber} :: {date.ToShortDateString()}");
            Console.WriteLine($"{order.CustomerName}");
            Console.WriteLine($"{order.State}");
            Console.WriteLine($"Product : {order.ProductType}");
            Console.WriteLine($"Materials : ${order.MaterialCost}");
            Console.WriteLine($"Labor : ${order.LaborCost}");
            Console.WriteLine($"Tax : ${order.Tax}");
            Console.WriteLine($"Total : ${order.Total}");
            Console.WriteLine("*******************************");
        }
    }
}
