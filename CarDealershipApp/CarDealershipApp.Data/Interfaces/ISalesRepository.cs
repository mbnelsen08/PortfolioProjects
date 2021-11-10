using CarDealershipApp.Models.Queries;
using CarDealershipApp.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealershipApp.Data.Interfaces
{
    public interface ISalesRepository
    {
        void Add(Sale sale);
        List<SalesReportItem> Search(string userID, DateTime minDate, DateTime maxDate);
    }
}
