using FlooringMaster.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMaster.Models.Interfaces
{
    public interface ITaxes
    {
        List<Taxes> LoadTaxes();
    }
}
