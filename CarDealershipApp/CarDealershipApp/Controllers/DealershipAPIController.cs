using CarDealershipApp.Data.Factories;
using CarDealershipApp.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarDealershipApp.Controllers
{
    public class DealershipAPIController : ApiController
    {
        [AcceptVerbs("GET")]
        [Route("inventory/searchused/{searchText}/{minPrice}/{maxPrice}/{minYear}/{maxYear}")]
        public IHttpActionResult SearchUsed(string searchText, decimal minPrice, decimal maxPrice, int minYear, int maxYear)
        {
            var repo = VehicleRepositoryFactory.GetRepository();
            List<Vehicle> vehicles = new List<Vehicle>();
            vehicles = repo.SearchUsed(searchText, minPrice, maxPrice, minYear, maxYear).ToList();

            if(vehicles == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(vehicles);
            }
        }

        [AcceptVerbs("GET")]
        [Route("inventory/searchnew/{searchText}/{minPrice}/{maxPrice}/{minYear}/{maxYear}")]
        public IHttpActionResult SearchNew(string searchText, decimal minPrice, decimal maxPrice, int minYear, int maxYear)
        {
            var repo = VehicleRepositoryFactory.GetRepository();
            List<Vehicle> vehicles = new List<Vehicle>();
            vehicles = repo.SearchNew(searchText, minPrice, maxPrice, minYear, maxYear);

            if (vehicles == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(vehicles);
            }
        }

        [AcceptVerbs("GET")]
        [Route("inventory/searchsales/{searchText}/{minPrice}/{maxPrice}/{minYear}/{maxYear}")]
        public IHttpActionResult SearchSales(string searchText, decimal minPrice, decimal maxPrice, int minYear, int maxYear)
        {
            var repo = VehicleRepositoryFactory.GetRepository();
            List<Vehicle> vehicles = new List<Vehicle>();
            vehicles = repo.SearchSales(searchText, minPrice, maxPrice, minYear, maxYear);

            if (vehicles == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(vehicles);
            }
        }
    }
}
