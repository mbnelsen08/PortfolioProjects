using CarDealershipApp.Data.ADO;
using CarDealershipApp.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealershipApp.Data.Factories
{
    public static class SalesRepositoryFactory
    {
        public static ISalesRepository GetRepository()
        {
            switch (Settings.GetRepositoryType())
            {
                case "Ado":
                    return new SalesRepositoryAdo();
                default:
                    throw new Exception("Could not find valid sales repository.");
            }


        }
    }
}
