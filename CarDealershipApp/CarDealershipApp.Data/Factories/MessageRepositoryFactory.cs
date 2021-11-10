using CarDealershipApp.Data.ADO;
using CarDealershipApp.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealershipApp.Data.Factories
{
    public static class MessageRepositoryFactory
    {
        public static IMessageRepository GetRepository()
        {
            switch (Settings.GetRepositoryType())
            {
                case "Ado":
                    return new MessageRepositoryAdo();
                default:
                    throw new Exception("Could not find valid message repository.");
            }
        }
    }
}
