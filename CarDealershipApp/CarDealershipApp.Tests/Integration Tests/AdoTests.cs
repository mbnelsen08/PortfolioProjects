using CarDealershipApp.Data.ADO;
using CarDealershipApp.Models.Queries;
using CarDealershipApp.Models.Tables;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealershipApp.Tests.Integration_Tests
{
    [TestFixture]
    public class AdoTests
    {
        [SetUp]
        public void Init()
        {
            using(var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "DBReset";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Connection = cn;
                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        [Test]
        public void CanLoadStates()
        {
            var repo = new StatesRepositoryAdo();

            var states = repo.GetAll();

            Assert.AreEqual(5, states.Count);
            Assert.AreEqual(1, states[0].StateID);
            Assert.AreEqual("SD", states[0].StateAbv);
        }

        [Test]
        public void CanLoadBodyStyle()
        {
            var repo = new BodyStyleRepositoryAdo();

            var styles = repo.GetAll();

            Assert.AreEqual(5, styles.Count);
            Assert.AreEqual(1, styles[0].BodyStyleID);
            Assert.AreEqual("SUV", styles[0].Style);
        }

        [Test]
        public void CanLoadExteriorColor()
        {
            var repo = new ExteriorColorRepositoryAdo();

            var colors = repo.GetAll();

            Assert.AreEqual(5, colors.Count);
            Assert.AreEqual(1, colors[0].ExteriorColorID);
            Assert.AreEqual("Black", colors[0].ExteriorColor);
        }

        [Test]
        public void CanLoadInteriorColor()
        {
            var repo = new InteriorColorRepositoryAdo();

            var colors = repo.GetAll();

            Assert.AreEqual(5, colors.Count);
            Assert.AreEqual(1, colors[0].InteriorColorID);
            Assert.AreEqual("Black", colors[0].InteriorColor);
        }

        [Test]
        public void CanLoadTransmission()
        {
            var repo = new TransmissionRepositoryAdo();

            var tranmissions = repo.GetAll();

            Assert.AreEqual(2, tranmissions.Count);
            Assert.AreEqual(1, tranmissions[0].TransmissionID);
            Assert.AreEqual("Manual", tranmissions[0].Type);
        }

        [Test]
        public void CanLoadMakes()
        {
            var repo = new MakeRepositoryAdo();

            var makes = repo.GetAll();

            Assert.AreEqual(5, makes.Count);
            Assert.AreEqual(1, makes[0].MakeID);
            Assert.AreEqual("Ford", makes[0].MakeName);
        }

        [Test]
        public void CanLoadModels()
        {
            var repo = new ModelRepositoryAdo();

            var models = repo.GetAll();

            Assert.AreEqual(5, models.Count);
            Assert.AreEqual(1, models[0].ModelID);
            Assert.AreEqual("Corolla", models[0].ModelName);
        }

        [Test]
        public void CanLoadVehicles()
        {
            var repo = new VehicleRepositoryAdo();

            var models = repo.GetAll();

            Assert.AreEqual(5, models.Count);
            Assert.AreEqual(1, models[0].ModelID);
            Assert.AreEqual("Corolla", models[0].ModelName);
        }

        [Test]
        public void CanGetVehicleByID()
        {
            var repo = new VehicleRepositoryAdo();

            var models = repo.GetVehicleByID(1);

            Assert.AreEqual(5, models.MakeID);
            Assert.AreEqual(1, models.ModelID);
            Assert.AreEqual("Corolla", models.ModelName);
        }

        [Test]
        public void CanGetVehicleByIDIsNull()
        {
            var repo = new VehicleRepositoryAdo();

            var models = repo.GetVehicleByID(100);

            Assert.IsNull(models);
        }

        [Test]
        public void CanInsertVehicle()
        {
            var repo = new VehicleRepositoryAdo();
            Vehicle vehicleToAdd = new Vehicle();

            vehicleToAdd.BodyStyleID = 4;
            vehicleToAdd.Description = "Added car";
            vehicleToAdd.ExteriorColorID = 3;
            vehicleToAdd.Featured = true;
            vehicleToAdd.ImageFileName = "placeholder.png";
            vehicleToAdd.InteriorColorID = 2;
            vehicleToAdd.MakeID = 3;
            vehicleToAdd.Mileage = 500;
            vehicleToAdd.ModelID = 3;
            vehicleToAdd.Msrp = 40000M;
            vehicleToAdd.NewOld = true;
            vehicleToAdd.SalePrice = 50000M;
            vehicleToAdd.Sold = false;
            vehicleToAdd.TransmissionID = 1;
            vehicleToAdd.Vin = 1234567890;
            vehicleToAdd.Year = 2021;

            repo.Add(vehicleToAdd);

            Assert.AreEqual(6, vehicleToAdd.VehicleID);
        }

        [Test]
        public void CanUpdateVehicle()
        {
            var repo = new VehicleRepositoryAdo();
            Vehicle vehicleToAdd = new Vehicle();

            vehicleToAdd.BodyStyleID = 4;
            vehicleToAdd.Description = "Added car";
            vehicleToAdd.ExteriorColorID = 3;
            vehicleToAdd.Featured = true;
            vehicleToAdd.ImageFileName = "placeholder.png";
            vehicleToAdd.InteriorColorID = 2;
            vehicleToAdd.MakeID = 3;
            vehicleToAdd.Mileage = 500;
            vehicleToAdd.ModelID = 3;
            vehicleToAdd.Msrp = 40000M;
            vehicleToAdd.NewOld = true;
            vehicleToAdd.SalePrice = 50000M;
            vehicleToAdd.Sold = false;
            vehicleToAdd.TransmissionID = 1;
            vehicleToAdd.Vin = 1234567890;
            vehicleToAdd.Year = 2021;

            repo.Add(vehicleToAdd);

            vehicleToAdd.BodyStyleID = 5;
            vehicleToAdd.Description = "Updated car";
            vehicleToAdd.ExteriorColorID = 4;
            vehicleToAdd.Featured = true;
            vehicleToAdd.ImageFileName = "placeholder.png";
            vehicleToAdd.InteriorColorID = 4;
            vehicleToAdd.MakeID = 2;
            vehicleToAdd.Mileage = 1200;
            vehicleToAdd.ModelID = 4;
            vehicleToAdd.Msrp = 50000M;
            vehicleToAdd.NewOld = true;
            vehicleToAdd.SalePrice = 45000M;
            vehicleToAdd.Sold = false;
            vehicleToAdd.TransmissionID = 2;
            vehicleToAdd.Vin = 1234567890;
            vehicleToAdd.Year = 2017;

            repo.Update(vehicleToAdd);

            Vehicle updatedVehicle = repo.GetVehicleByID(6);

            Assert.AreEqual(50000M, updatedVehicle.Msrp);
            Assert.AreEqual(2017, updatedVehicle.Year);
        }

        [Test]
        public void CanDeleteVehicle()
        {
            var repo = new VehicleRepositoryAdo();

            repo.Delete(1);
            var models = repo.GetAll();
            Assert.AreEqual(4, models.Count);
        }

        [Test]
        public void CanSearchVehicles()
        {
            var repo = new VehicleRepositoryAdo();

            string searchText = "";
            decimal minPrice = 0M;
            decimal maxPrice = 40000M;
            int minYear = 2010;
            int maxYear = 2030;

            var models = repo.SearchSales(searchText, minPrice, maxPrice, minYear, maxYear);

            Assert.AreEqual(5, models.Count);
        }

        

        [Test]
        public void CanSearchSales()
        {
            var repo = new SalesRepositoryAdo();

            string userID = "";
            DateTime minDate = new DateTime(1754, 01, 01);
            DateTime maxDate = new DateTime(2030, 01, 01);


            List<SalesReportItem> sales = new List<SalesReportItem>();

            sales = repo.Search(userID, minDate, maxDate);

            Assert.AreEqual(2, sales.Count);
            Assert.AreEqual(sales[0].TotalVehicles, 4);
            Assert.AreEqual(sales[0].TotalSales, 48000M);
        }

        [Test]
        public void CanGetFeaturedVehicles()
        {
            var repo = new VehicleRepositoryAdo();
            List<FeaturedVehicleItem> vehicles = new List<FeaturedVehicleItem>();

            vehicles = repo.GetFeatured();

            Assert.AreEqual(2, vehicles.Count);
            Assert.AreEqual("Nissan", vehicles[0].MakeName);
        }

        [Test]
        public void CanGetInventoryReport()
        {
            var repo = new VehicleRepositoryAdo();
            List<InventoryReportItem> report = new List<InventoryReportItem>();

            report = repo.GetInventoryReport();

            Assert.AreEqual(3, report.Count);
            Assert.AreEqual(report[0].MakeName, "Nissan");
            Assert.AreEqual(report[0].NewOld, true);
        }
    }
}

