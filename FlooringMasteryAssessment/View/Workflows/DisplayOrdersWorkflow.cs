using BLL;
using FlooringMaster.Models.Models;
using FlooringMaster.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View.Workflows
{
    public class DisplayOrdersWorkflow
    {
        public void Execute()
        {

            Manager manager = ManagerFactory.Create();
            UserIO userIO = new UserIO();
            Console.Clear();
            Console.WriteLine("Lookup Orders");
            Console.WriteLine("-----------------------");

            DateTime date = userIO.ReadDateTime("Enter a date(MM/DD/YYYY)",false);

            DisplayResponse response = new DisplayResponse();
            response = manager.DisplayOrders(date);

            if(response.Success)
            {
                foreach(var order in response.orders)
                {
                    ConsoleIO.DisplayOrder(order,response.date);
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine(response.Message);
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
    }
}
