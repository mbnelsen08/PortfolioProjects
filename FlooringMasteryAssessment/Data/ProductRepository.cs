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
    public class ProductRepository : IProduct
    {
        private string _filePath = @"C:\Data\FlooringMastery\Products.txt";
        private List<Product> data;
        private Product convertRowToObject(string[] rows)
        {
            Product product = new Product();

            product.ProductType = rows[0];
            product.CostPerSquareFoot = decimal.Parse(rows[1]);
            product.LaborCostPerSquareFoot = decimal.Parse(rows[2]);

            return product;
        }
        public List<Product> LoadProducts()
        {
            data = new List<Product>();
            string[] rows = File.ReadAllLines(_filePath);

            for (var i = 1; i < rows.Length; i++)
            {
                string[] columns = rows[i].Split(',');
                Product product = convertRowToObject(columns);
                data.Add(product);
            }
            return data;
        }
    }
}
