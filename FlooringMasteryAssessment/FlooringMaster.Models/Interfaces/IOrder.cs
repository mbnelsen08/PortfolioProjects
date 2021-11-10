using FlooringMaster.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMaster.Models.Interfaces
{
    public interface IOrder
    {
        Order LoadOrder(int OrderNumber, string filePath);
        void AddOrder(Order OrderToAdd, string filePath);
        void RemoveOrder(int OrderNumber, string filePath);
        void EditOrder(Order UpdatedOrder, int OrderNumber, string filePath);
        List<Order> DisplayOrders(string filePath);
        bool CheckFileExists(string filePath);
        bool CheckOrderExists(int OrderNumber, string filePath);
        void CreateNewFile(string filePath);

    };
}
