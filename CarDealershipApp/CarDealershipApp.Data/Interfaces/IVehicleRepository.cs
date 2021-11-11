using CarDealershipApp.Models.Queries;
using CarDealershipApp.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealershipApp.Data.Interfaces
{
    public interface IVehicleRepository
    {
        List<Vehicle> GetAll();
        Vehicle GetVehicleByID(int vehicleID);
        List<FeaturedVehicleItem> GetFeatured();
        List<Vehicle> SearchSales(string searchText, decimal minPrice, decimal maxPrice, int minYear, int maxYear);
        List<Vehicle> SearchNew(string searchText, decimal minPrice, decimal maxPrice, int minYear, int maxYear);
        IEnumerable<Vehicle> SearchUsed(string searchText, decimal minPrice, decimal maxPrice, int minYear, int maxYear);
        void Add(Vehicle vehicle);
        void Update(Vehicle vehicle);
        void Delete(int vehicleID);
        void Purchase(int vehicleID);
        List<InventoryReportItem> GetInventoryReport();
    }
}
