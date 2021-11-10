using CarDealershipApp.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealershipApp.Data.Interfaces
{
    public interface IModelRepository
    {
        List<Model> GetAll();

        void Add(Model model);
    }
}
