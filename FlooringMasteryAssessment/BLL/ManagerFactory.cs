using Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class ManagerFactory
    {
        public static Manager Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "Test":
                    return new Manager(new MockOrderRepo(),new MockProductRepo(), new MockTaxesRepo());
                case "Prod":
                    return new Manager(new OrderRepository(), new ProductRepository(), new TaxesRepository());
                default:
                    throw new Exception("Mode value in App.Config is not valid.");
            }
        }
    }
}
