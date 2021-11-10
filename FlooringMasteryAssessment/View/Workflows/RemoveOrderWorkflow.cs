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
    public class RemoveOrderWorkflow
    {
        public void Execute()
        {
            Manager manager = ManagerFactory.Create();
            UserIO userIO = new UserIO();
            List<Order> daysOrders = new List<Order>();
            RemoveResponse removeResponse = new RemoveResponse();
            Order orderToRemove = new Order();
            Console.Clear();
            Console.WriteLine("Remove Order");
            Console.WriteLine("-----------------------");

            DateTime date = userIO.ReadDateTime("Enter a date(MM/DD/YYYY): ", false);
            int OrderNumber = userIO.ReadInt("Enter an order number: ", 1, 100);

            daysOrders = manager.LoadOrders(date);
            orderToRemove = daysOrders.Where(order => order.OrderNumber == OrderNumber).FirstOrDefault();
            ConsoleIO.DisplayOrder(orderToRemove,date);
            bool yesNo = userIO.ReadYesNo("Remove Order? (yes or no): ");

            if(yesNo)
            {
                removeResponse = manager.RemoveOrder(date, OrderNumber);
                Console.WriteLine("Order Removed");
            }
            else
            {
                Console.WriteLine(removeResponse.Message);
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
    }
}
