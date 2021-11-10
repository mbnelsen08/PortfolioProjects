using FlooringMaster.Models.Interfaces;
using FlooringMaster.Models.Models;
using FlooringMaster.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Manager
    {

        private IOrder _orderRepo;
        private IProduct _productRepo;
        private ITaxes _taxesRepo;

        public Manager(IOrder orderRepository, IProduct productRepository, ITaxes taxesRepository)
        {
            _orderRepo = orderRepository;
            _productRepo = productRepository;
            _taxesRepo = taxesRepository;
        }

        public List<Product> LoadProducts()
        {
            List<Product> products = new List<Product>();
            products = _productRepo.LoadProducts();
            return products;
        }

        public List<Taxes> LoadTaxes()
        {
            List<Taxes> taxes = new List<Taxes>();
            taxes = _taxesRepo.LoadTaxes();
            return taxes;
        }

        public List<Order> LoadOrders(DateTime date)
        {
            string filePath = ConvertDateToString(date);
            List<Order> orders = new List<Order>();
            orders = _orderRepo.DisplayOrders(filePath);
            return orders;
        }
        public string ConvertDateToString(DateTime dateTime)
        {
            string filePath;
            string day = dateTime.Day.ToString();
            string month = dateTime.Month.ToString();
            string year = dateTime.Year.ToString();

            if(day.Length==1)
            {
                day = $"0{day}";
            }
            if (month.Length == 1)
            {
                month = $"0{month}";
            }
            filePath = $"Orders_{month}{day}{year}";
            return filePath;
        }

        public Order LoadOrderByID(int OrderNumber, DateTime date)
        {
            Order myOrder = new Order();
            string filePath = ConvertDateToString(date);
            myOrder = _orderRepo.LoadOrder(OrderNumber, filePath);
            return myOrder;
        }

        public bool CheckOrderExists(int OrderNumber, DateTime date)
        {
            bool exists = false;
            string filePath = ConvertDateToString(date);
            exists = _orderRepo.CheckOrderExists(OrderNumber, filePath);
            return exists;
        }

        public bool CheckFileExists(DateTime date)
        {
            bool exists = false;
            string filePath = ConvertDateToString(date);
            exists = _orderRepo.CheckFileExists(filePath);
            return exists;
        }

        public Order CalculateNewOrder(Order oldOrder)
        {
            Order calculatedOrder = new Order();

            calculatedOrder.CustomerName = oldOrder.CustomerName;
            calculatedOrder.State = oldOrder.State;
            calculatedOrder.TaxRate = oldOrder.TaxRate;
            calculatedOrder.ProductType = oldOrder.ProductType;
            calculatedOrder.Area = oldOrder.Area;
            calculatedOrder.CostPerSquareFoot = oldOrder.CostPerSquareFoot;
            calculatedOrder.LaborCostPerSquareFoot = oldOrder.LaborCostPerSquareFoot;

            calculatedOrder.MaterialCost = Math.Round((calculatedOrder.Area * calculatedOrder.CostPerSquareFoot),2);
            calculatedOrder.LaborCost = Math.Round((calculatedOrder.Area * calculatedOrder.LaborCostPerSquareFoot),2);
            calculatedOrder.Tax = Math.Round((calculatedOrder.MaterialCost + calculatedOrder.LaborCost) * (calculatedOrder.TaxRate / 100M), 2);
            calculatedOrder.Total = (calculatedOrder.MaterialCost + calculatedOrder.LaborCost + calculatedOrder.Tax);

            return calculatedOrder;
        }
        public bool CheckValidState(string StateAbv)
        {
            bool isValid = false;
            List<Taxes> taxes = new List<Taxes>();
            taxes = _taxesRepo.LoadTaxes();

            if(StateAbv.Length == 2)
            {
                foreach (var state in taxes)
                {
                    if(state.StateAbbreviation == StateAbv)
                    {
                        isValid = true;
                    }
                }
            }
            return isValid;
        }
        public Taxes GetTaxesByStateAbv(string StateAbv)
        {
            Taxes tax = new Taxes();
            List<Taxes> taxes = new List<Taxes>();
            taxes = _taxesRepo.LoadTaxes();

            foreach(var state in taxes)
            {
                if(StateAbv == state.StateAbbreviation)
                {
                    tax = state;
                }
            }
            return tax;
        }
        public bool CheckValidProduct(string productType)
        {
            bool isValid = false;
            List<Product> products = new List<Product>();
            products = _productRepo.LoadProducts();

            foreach(var product in products)
            {
                if(productType.ToLower() == product.ProductType.ToLower())
                {
                    isValid = true;
                }
            }
            return isValid;
        }

        public Product GetProductByType(string productType)
        {
            Product myProduct = new Product();
            List<Product> products = new List<Product>();
            products = _productRepo.LoadProducts();

            foreach(var product in products)
            {
                if (productType.ToLower() == product.ProductType.ToLower())
                {
                    myProduct = product;
                }
            }
            return myProduct;
        }
        public DisplayResponse DisplayOrders(DateTime date)
        {
            string filePath = ConvertDateToString(date);
            List<Order> orders = new List<Order>();
            DisplayResponse response = new DisplayResponse();

            if (_orderRepo.CheckFileExists(filePath))
            {
                orders = _orderRepo.DisplayOrders(filePath);
                response.orders = orders;
                response.Success = true;
                response.date = date;
            }
            else
            {
                response.Success = false;
                response.Message = "No orders exists for that date.";
            }
            return response;
        }

        public RemoveResponse RemoveOrder(DateTime date, int OrderNumber)
        {
            string filePath = ConvertDateToString(date);
            RemoveResponse response = new RemoveResponse();
            if (_orderRepo.CheckFileExists(filePath))
            {
                if (_orderRepo.CheckOrderExists(OrderNumber, filePath))
                {
                    _orderRepo.RemoveOrder(OrderNumber, filePath);
                    response.Success = true;
                    response.date = date;
                }
                else
                {
                    response.Success = false;
                    response.Message = "Order does not exists on that date.";
                }
            }
            else
            {
                response.Success = false;
                response.Message = "No orders exists for that date.";
            }
            return response;
        }

        public AddResponse AddOrder(DateTime date, Order orderToAdd)
        {
            AddResponse response = new AddResponse();
            string filePath = ConvertDateToString(date);
            bool fileExists = _orderRepo.CheckFileExists(filePath);

            if(fileExists == false)
            {
                _orderRepo.CreateNewFile(filePath);
            }
            List<Order> orders = new List<Order>();
            orders = _orderRepo.DisplayOrders(filePath);
            int highNumber = 0;

            foreach (var order in orders)
            {
                if (order.OrderNumber > highNumber)
                {
                    highNumber = order.OrderNumber;
                }
            }
            orderToAdd.OrderNumber = highNumber + 1;
            _orderRepo.AddOrder(orderToAdd, filePath);
            response.Success = true;
            return response;
        }

        public EditResponse EditOrder(int OrderNumber, DateTime date, Order updatedOrder)
        {
            string filePath = ConvertDateToString(date);
            _orderRepo.EditOrder(updatedOrder, OrderNumber, filePath);
            EditResponse response = new EditResponse();

            response.Success = true;
            return response;
        }
    }
}
