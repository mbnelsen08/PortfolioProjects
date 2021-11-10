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
    public class AddOrderWorkflow
    {
        public void Execute()
        {
            Manager manager = ManagerFactory.Create();
            UserIO userIO = new UserIO();
            List<Product> products = new List<Product>();
            products = manager.LoadProducts();

            DateTime orderDate;
            Order orderToAdd = new Order();
            Product productToOrder = new Product();
            Taxes stateTaxes = new Taxes();
            string customerName;
            string stateAbv;
            string productType;
            decimal area;

            Console.Clear();
            Console.WriteLine("Add Order");
            Console.WriteLine("-----------------------");

            orderDate = userIO.ReadDateTime("Order date: ", true);

            Console.Clear();
            customerName = userIO.ReadString("Customer Name: ", false);
            orderToAdd.CustomerName = customerName;

            Console.Clear();
            bool validState = false;
            do
            {
                stateAbv = userIO.ReadString("State Abbreviation (ex. PA): ", false).ToUpper();
                validState = manager.CheckValidState(stateAbv);
                if (validState == false)
                {
                    Console.WriteLine("Not a valid abbreviation for a state we currently sell in.");
                }
            } while (validState == false);

            stateTaxes = manager.GetTaxesByStateAbv(stateAbv);
            orderToAdd.State = stateTaxes.StateAbbreviation;
            orderToAdd.TaxRate = stateTaxes.TaxRate;

            Console.Clear();
            Console.WriteLine("Products");
            foreach(var product in products)
            {
                Console.WriteLine("*******************************");
                Console.WriteLine(product.ProductType);
                Console.WriteLine($"Cost per square foot: {product.CostPerSquareFoot}");
                Console.WriteLine($"Labor cost per square foot: {product.LaborCostPerSquareFoot}");
                Console.WriteLine("*******************************");
            }

            bool validProduct = false;
            do
            {
                productType = userIO.ReadString("Product type: ", false);
                validProduct = manager.CheckValidProduct(productType);
                if(validProduct == false)
                {
                    Console.WriteLine("Not a valid product type.");
                }
            } while (validProduct == false);
            productToOrder = manager.GetProductByType(productType);
            orderToAdd.ProductType = productToOrder.ProductType;
            orderToAdd.LaborCostPerSquareFoot = productToOrder.LaborCostPerSquareFoot;
            orderToAdd.CostPerSquareFoot = productToOrder.CostPerSquareFoot;

            Console.Clear();
            area = userIO.ReadInt("Area in square feet: ", 100, 10000);
            orderToAdd.Area = area;
            
            orderToAdd = manager.CalculateNewOrder(orderToAdd);

            Console.Clear();
            ConsoleIO.DisplayOrder(orderToAdd, orderDate);
            AddResponse response = new AddResponse();
            bool addYesNo = userIO.ReadYesNo("Submit order? (yes or no): ");
            if(addYesNo == true)
            {
                 response = manager.AddOrder(orderDate, orderToAdd);
            }

            if(response.Success)
            {
                Console.WriteLine("Order submitted successfully.");
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
    }
}
