using CarDealershipApp.Data.ADO;
using CarDealershipApp.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealershipApp.Data.Factories
{
    public static class ExteriorColorRepositoryFactory
    {
        public static IExteriorColorRepository GetRepository()
        {
            switch (Settings.GetRepositoryType())
            {
                case "Ado":
                    return new ExteriorColorRepositoryAdo();
                default:
                    throw new Exception("Could not find valid exterior color repository.");
            }


        }
    }
}
