using CarDealershipApp.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealershipApp.Data.Interfaces
{
    public interface ISpecialRepository
    {
        List<Special> GetAll();
        void Add(Special special);
        void Delete(int specialID);
    }
}
