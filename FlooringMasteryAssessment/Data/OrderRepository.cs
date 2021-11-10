using FlooringMaster.Models.Interfaces;
using FlooringMaster.Models.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class OrderRepository : IOrder
    {
        private string _filePath;
        private List<Order> data;
        private string CreateFilePath(string filePath)
        {
            string path = $@"C:\Data\FlooringMastery\{filePath}.txt";
            return path;
        }
        private Order convertRowToObject(string[] rows)
        {
            Order order = new Order();

            order.OrderNumber = int.Parse(rows[0]);
            order.CustomerName = rows[1];
            order.State = rows[2];
            order.TaxRate = decimal.Parse(rows[3]);
            order.ProductType = rows[4];
            order.Area = decimal.Parse(rows[5]);
            order.CostPerSquareFoot = decimal.Parse(rows[6]);
            order.LaborCostPerSquareFoot = decimal.Parse(rows[7]);
            order.MaterialCost = decimal.Parse(rows[8]);
            order.LaborCost = decimal.Parse(rows[9]);
            order.Tax = decimal.Parse(rows[10]);
            order.Total = decimal.Parse(rows[11]);

            return order;
        }

        private string convertObjectToRow(Order order)
        {
            return $"{order.OrderNumber}|{order.CustomerName}|{order.State}|{order.TaxRate}|{order.ProductType}|{order.Area}|{order.CostPerSquareFoot}|{order.LaborCostPerSquareFoot}|{order.MaterialCost}|{order.LaborCost}|{order.Tax}|{order.Total}";
        }
        private void LoadAllFromFile(string filePath)
        {
            data = new List<Order>();
            _filePath = CreateFilePath(filePath);
            string[] rows = File.ReadAllLines(_filePath);

            for (var i = 1; i < rows.Length; i++)
            {
                string[] columns = rows[i].Split('|');
                Order order = convertRowToObject(columns);
                data.Add(order);
            }
        }

        private void SaveAllToFile()
        {
            string[] rows = new string[data.Count];

            for (var i = 0; i < rows.Length; i++)
            {
                string orderToAdd = convertObjectToRow(data[i]);
                rows[i] = orderToAdd;

            }
            File.Delete(_filePath);

            using (StreamWriter writer = new StreamWriter(_filePath))
            {
                writer.WriteLine("OrderNumber|CustomerName|State|TaxRate|ProductType|Area|CostPerSquareFoot|LaborCostPerSquareFoot|MaterialCost|LaborCost|Tax|Total");
                for (var i = 0; i < rows.Length; i++)
                {
                    writer.WriteLine(rows[i]);
                }
            }
            if (data.Count < 1)
            {
                File.Delete(_filePath);
            }
        }

        public void AddOrder(Order OrderToAdd, string filePath)
        {
            LoadAllFromFile(filePath);
            data.Add(OrderToAdd);
            SaveAllToFile();
        }

        public bool CheckFileExists(string filePath)
        {
            _filePath = CreateFilePath(filePath);
            bool yesNo = false;
            yesNo = File.Exists(_filePath);
            return yesNo;
        }

        public bool CheckOrderExists(int OrderNumber, string filePath)
        {
            bool yesNo = false;
            LoadAllFromFile(filePath);
            foreach (var order in data)
            {
                if (order.OrderNumber == OrderNumber)
                {
                    yesNo = true;
                }
            }
            return yesNo;
        }
        public void CreateNewFile(string filePath)
        {
            _filePath = CreateFilePath(filePath);
            File.Create(_filePath).Close();
        }

        public List<Order> DisplayOrders(string filePath)
        {
            data = new List<Order>();
            _filePath = CreateFilePath(filePath);
            string[] rows = File.ReadAllLines(_filePath);

            for (var i = 1; i < rows.Length; i++)
            {
                string[] columns = rows[i].Split('|');
                Order order = convertRowToObject(columns);
                data.Add(order);
            }
            return data;
        }

        public void EditOrder(Order UpdatedOrder, int OrderNumber, string filePath)
        {
            LoadAllFromFile(filePath);
            foreach (var order in data)
            {
                if (OrderNumber == order.OrderNumber)
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
            SaveAllToFile();
        }

        public Order LoadOrder(int OrderNumber, string filePath)
        {
            Order myOrder = new Order();
            LoadAllFromFile(filePath);
            foreach (var order in data)
            {
                if (order.OrderNumber == OrderNumber)
                {
                    myOrder = order;
                }
            }
            return myOrder;

        }

        public void RemoveOrder(int OrderNumber, string filePath)
        {
            LoadAllFromFile(filePath);
            Order orderToRemove = data.Where(order => order.OrderNumber == OrderNumber).FirstOrDefault();
            data.Remove(orderToRemove);
            SaveAllToFile();

        }
    }
}
