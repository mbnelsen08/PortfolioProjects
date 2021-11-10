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
    public class EditOrderWorkflow
    {
        public void Execute()
        {
            Manager manager = ManagerFactory.Create();
            UserIO userIO = new UserIO();
            List<Product> products = new List<Product>();
            products = manager.LoadProducts();

            DateTime orderDate;
            Order orderToUpdate = new Order();
            Order order = new Order();
            Product productToOrder = new Product();
            Taxes stateTaxes = new Taxes();
            string customerName = "";
            string stateAbv;
            string productType;
            decimal area;
            int OrderNumber;

            Console.Clear();
            Console.WriteLine("Edit Order");
            Console.WriteLine("-----------------------");

            bool validDate = false;
            do
            {
                orderDate = userIO.ReadDateTime("Order date: ", false);
                if (manager.CheckFileExists(orderDate))
                {
                    validDate = true;
                }
                if(validDate == false)
                {
                    Console.WriteLine("No orders exists for that date.");
                }
            } while (validDate == false);

            bool validOrder = false;
            do
            {
                OrderNumber = userIO.ReadInt("Enter an order number: ", 1, 100);
                if(manager.CheckOrderExists(OrderNumber, orderDate))
                {
                    validOrder = true;
                }
                if(validOrder == false)
                {
                    Console.WriteLine("No orders with that order number exists on that date.");
                }
            } while (validOrder == false);

            order = manager.LoadOrderByID(OrderNumber, orderDate);

            Console.Clear();
            Console.WriteLine($"Current Customer Name: {order.CustomerName}");
            customerName = userIO.ReadString("Update name (press enter to leave as current name): ", true);
            if(customerName == "")
            {
                orderToUpdate.CustomerName = order.CustomerName;
            }
            if(customerName != "")
            {
                orderToUpdate.CustomerName = customerName;
            }

            Console.Clear();
            bool validState = false;
            do
            {
                Console.WriteLine($"Current Customer State: {order.State}");
                stateAbv = userIO.ReadString("Update state (press enter to leave as current state or enter new state abbreviation): ", true);
                validState = manager.CheckValidState(stateAbv);
                if (stateAbv == "")
                {
                    validState = true;
                    orderToUpdate.State = order.State;
                    orderToUpdate.TaxRate = order.TaxRate;
                }
                if(validState == false)
                {
                    Console.Clear();
                    Console.WriteLine("Not a valid abbreviation for a state we currently sell in.");
                }
            } while (validState == false);
            if(stateAbv != "")
            {
                orderToUpdate.State = stateAbv;
                stateTaxes = manager.GetTaxesByStateAbv(stateAbv);
                orderToUpdate.TaxRate = stateTaxes.TaxRate;
            }

            Console.Clear();
            bool validProduct = false;
            do
            {
                Console.WriteLine("Products");
                foreach (var product in products)
                {
                    Console.WriteLine("*******************************");
                    Console.WriteLine(product.ProductType);
                    Console.WriteLine($"Cost per square foot: {product.CostPerSquareFoot}");
                    Console.WriteLine($"Labor cost per square foot: {product.LaborCostPerSquareFoot}");
                    Console.WriteLine("*******************************");
                }
                Console.WriteLine();
                Console.WriteLine($"Current Product is {order.ProductType}.");
                Console.WriteLine("Update product (press enter to leave as current product or enter new product): ");

                productType = Console.ReadLine();
                validProduct = manager.CheckValidProduct(productType);
                if (productType == "")
                {
                    validProduct = true;
                    orderToUpdate.ProductType = order.ProductType;
                    orderToUpdate.LaborCostPerSquareFoot = order.LaborCostPerSquareFoot;
                    orderToUpdate.CostPerSquareFoot = order.CostPerSquareFoot;
                }
                if(validProduct==false)
                {
                    Console.Clear();
                    Console.WriteLine("Not a valid product type.");
                }
            } while (validProduct == false);
            if (productType != "")
            {
                orderToUpdate.ProductType = productType;
                productToOrder = manager.GetProductByType(productType);
                orderToUpdate.CostPerSquareFoot = productToOrder.CostPerSquareFoot;
                orderToUpdate.LaborCostPerSquareFoot = productToOrder.LaborCostPerSquareFoot;
            }

            Console.Clear();
            string areaString;
            bool validArea = false;
            do
            {
                
                Console.WriteLine($"Current area on the order is {order.Area}.");
                Console.WriteLine("Update product (press enter to leave as current product or enter new product): ");
                areaString = Console.ReadLine();
                if(areaString == "")
                {
                    validArea = true;
                    orderToUpdate.Area = order.Area;
                }
                if (Decimal.TryParse(areaString, out area))
                {
                    if (area > 0)
                    {
                        validArea = true;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Value must be greater than 0.");
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Not a valid area size.");
                }

            } while (validArea == false);
            if (areaString != "")
            {
                orderToUpdate.Area = area;
            }

            orderToUpdate = manager.CalculateNewOrder(orderToUpdate);
            orderToUpdate.OrderNumber = OrderNumber;

            Console.Clear();
            EditResponse response = new EditResponse();
            ConsoleIO.DisplayOrder(orderToUpdate, orderDate);
            if (userIO.ReadYesNo("Update order? (Yes or No): "))
            {
                response = manager.EditOrder(OrderNumber, orderDate, orderToUpdate);
            }

            if (response.Success)
            {
                Console.WriteLine("Order editted successfully.");
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
    }
}
