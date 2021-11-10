using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.Workflows;

namespace View
{
    public static class Menu
    {
        public static void Start()
        {

            while (true)
            {
                Console.Clear();
                Console.WriteLine("************************");
                Console.WriteLine("* Flooring Program");
                Console.WriteLine("************************");
                Console.WriteLine("* 1. Display Orders");
                Console.WriteLine("* 2. Add an Order");
                Console.WriteLine("* 3. Remove an Order");
                Console.WriteLine("* 4. Edit an Order");

                Console.WriteLine("\nQ to Quit");
                Console.Write("\nEnter Selection: ");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        Console.Clear();
                        DisplayOrdersWorkflow displayWorkflow = new DisplayOrdersWorkflow();
                        displayWorkflow.Execute();
                        break;
                    case "2":
                        Console.Clear();
                        AddOrderWorkflow addWorkflow = new AddOrderWorkflow();
                        addWorkflow.Execute();
                        Console.ReadKey();
                        break;
                    case "3":
                        Console.Clear();
                        RemoveOrderWorkflow removeWorkflow = new RemoveOrderWorkflow();
                        removeWorkflow.Execute();
                        Console.ReadKey();
                        break;
                    case "4":
                        Console.Clear();
                        EditOrderWorkflow editWorkflow = new EditOrderWorkflow();
                        editWorkflow.Execute();
                        Console.ReadKey();
                        break;
                    case "Q":
                        return;
                }
            }
        }
    }
}
