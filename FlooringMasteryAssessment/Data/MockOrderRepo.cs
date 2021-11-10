using FlooringMaster.Models.Interfaces;
using FlooringMaster.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class MockOrderRepo : IOrder
    {
        
        private static List<Order> Orders_06012013 = new List<Order>() 
        { 
            new Order()  {
                OrderNumber = 1,
                CustomerName = "Wise",
                State = "OH",
                TaxRate = 6.25M,
                ProductType = "Wood",
                Area = 100.00M,
                CostPerSquareFoot = 5.15M,
                LaborCostPerSquareFoot = 4.45M,
                MaterialCost = 515.00M,
                LaborCost = 475.00M,
                Tax = 61.88M,
                Total = 1051.88M
            },
            new Order()
            {
                OrderNumber = 2,
                CustomerName = "Nelsen",
                State = "OH",
                TaxRate = 6.25M,
                ProductType = "Wood",
                Area = 100.00M,
                CostPerSquareFoot = 5.15M,
                LaborCostPerSquareFoot = 4.45M,
                MaterialCost = 515.00M,
                LaborCost = 475.00M,
                Tax = 61.88M,
                Total = 1051.88M
            }
        };
        private static List<Order> Orders_06012020 = new List<Order>() 
        {
            new Order()
            {
                 OrderNumber = 1,
            CustomerName = "Werling",
            State = "OH",
            TaxRate = 6.25M,
            ProductType = "Wood",
            Area = 100.00M,
            CostPerSquareFoot = 5.15M,
            LaborCostPerSquareFoot = 4.45M,
            MaterialCost = 515.00M,
            LaborCost = 475.00M,
            Tax = 61.88M,
            Total = 1051.88M
            }
        };

        private static Dictionary<string, List<Order>> DatedFiles = new Dictionary<string, List<Order>>() 
        {
            {"Orders_06012013", Orders_06012013 },
            {"Orders_06012020", Orders_06012020 }
        };

        public bool CheckFileExists(string filePath)
        {
            bool yesNo;
            yesNo = DatedFiles.ContainsKey(filePath);
            return yesNo;

        }

        public bool CheckOrderExists(int OrderNumber, string filePath)
        {
            bool yesNo = false;
            List<Order> orders = new List<Order>();
            orders = DatedFiles[filePath];

            foreach(var order in orders)
            {
                if(order.OrderNumber == OrderNumber)
                {
                    yesNo = true;
                }
            }
            return yesNo;
        }
        public void AddOrder(Order OrderToAdd, string filePath)

        {
            List<Order> orders = new List<Order>();
            orders = DatedFiles[filePath];
            orders.Add(OrderToAdd);
            DatedFiles[filePath] = orders;
        }

        public void CreateNewFile(string filePath)
        {
            List<Order> orders = new List<Order>();
            DatedFiles.Add(filePath, orders);
        }

        public void EditOrder(Order UpdatedOrder, int OrderNumber, string filePath)
        {
            List<Order> daysOrders = new List<Order>();

            daysOrders = DatedFiles[filePath];

            foreach(var order in daysOrders)
            {
                if(OrderNumber == order.OrderNumber)
                {
                    order.CustomerName = UpdatedOrder.CustomerName;
                    order.State = UpdatedOrder.State;
                    order.TaxRate = UpdatedOrder.TaxRate;
                    order.ProductType = UpdatedOrder.ProductType;
                    order.Area = UpdatedOrder.Area;
                    order.CostPerSquareFoot = UpdatedOrder.CostPerSquareFoot;
                    order.LaborCostPerSquareFoot = UpdatedOrder.LaborCostPerSquareFoot;
                    order.MaterialCost = UpdatedOrder.MaterialCost;
                    order.LaborCost = UpdatedOrder.LaborCost;
                    order.Tax = UpdatedOrder.Tax;
                    order.Total = UpdatedOrder.Total;
                }
            }

            DatedFiles[filePath] = daysOrders;

        }

        public Order LoadOrder(int OrderNumber, string filePath)
        {
            List<Order> orders = new List<Order>();
            Order myOrder = new Order();

            orders = DatedFiles[filePath];
            foreach(var order in orders)
            {
                if(order.OrderNumber == OrderNumber)
                {
                    myOrder = order;
                }
            }
            return myOrder;
        }

        public void RemoveOrder(int OrderNumber, string filePath)
        {
            List<Order> orders = new List<Order>();
            orders = DatedFiles[filePath];
            Order orderToRemove = orders.Where(order => order.OrderNumber == OrderNumber).FirstOrDefault();
            orders.Remove(orderToRemove);
        }
        public List<Order> DisplayOrders(string filePath)
        {
            List<Order> orders = new List<Order>();
            orders = DatedFiles[filePath];
            return orders;
        }
    }
}
