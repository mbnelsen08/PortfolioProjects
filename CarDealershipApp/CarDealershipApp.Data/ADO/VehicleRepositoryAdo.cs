using CarDealershipApp.Data.Interfaces;
using CarDealershipApp.Models.Queries;
using CarDealershipApp.Models.Tables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealershipApp.Data.ADO
{
    public class VehicleRepositoryAdo : IVehicleRepository
    {
        public void Add(Vehicle vehicle)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehicleInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@VehicleID",SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);
                cmd.Parameters.AddWithValue("@MakeID", vehicle.MakeID);
                cmd.Parameters.AddWithValue("@ModelID", vehicle.ModelID);
                cmd.Parameters.AddWithValue("@BodyStyleID", vehicle.BodyStyleID);
                cmd.Parameters.AddWithValue("@ExteriorColorID", vehicle.ExteriorColorID);
                cmd.Parameters.AddWithValue("@InteriorColorID", vehicle.InteriorColorID);
                cmd.Parameters.AddWithValue("@ImageFileName", vehicle.ImageFileName);
                cmd.Parameters.AddWithValue("@Description", vehicle.Description);
                cmd.Parameters.AddWithValue("@Featured", vehicle.Featured);
                cmd.Parameters.AddWithValue("@Mileage", vehicle.Mileage);
                cmd.Parameters.AddWithValue("@Msrp", vehicle.Msrp);
                cmd.Parameters.AddWithValue("@NewOld", vehicle.NewOld);
                cmd.Parameters.AddWithValue("@SalePrice", vehicle.SalePrice);
                cmd.Parameters.AddWithValue("@Sold", vehicle.Sold);
                cmd.Parameters.AddWithValue("@TransmissionID", vehicle.TransmissionID);
                cmd.Parameters.AddWithValue("@Vin", vehicle.Vin);
                cmd.Parameters.AddWithValue("@Year", vehicle.Year);

                cn.Open();

                cmd.ExecuteNonQuery();

                vehicle.VehicleID = (int)param.Value;


            }
        }

        public void Delete(int vehicleID)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehicleDelete", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@VehicleID", vehicleID);

                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public List<Vehicle> GetAll()
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehiclesSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Vehicle currentRow = new Vehicle();
                        currentRow.MakeID = (int)dr["MakeID"];
                        currentRow.ModelID = (int)dr["ModelID"];
                        currentRow.BodyStyleID = (int)dr["BodyStyleID"];
                        currentRow.ExteriorColorID  = (int)dr["ExteriorColorID"];
                        currentRow.InteriorColorID = (int)dr["ModelID"];
                        currentRow.VehicleID = (int)dr["VehicleID"];
                        currentRow.Vin = (int)dr["Vin"];
                        currentRow.Year = (int)dr["Year"];
                        currentRow.MakeName = dr["MakeName"].ToString();
                        currentRow.ModelName = dr["ModelName"].ToString();
                        currentRow.Style = dr["Style"].ToString();
                        currentRow.ExteriorColor = dr["ExteriorColor"].ToString();
                        currentRow.InteriorColor = dr["InteriorColor"].ToString();
                        currentRow.TransmissionID = (int)dr["TransmissionID"];
                        currentRow.Type = dr["Type"].ToString();
                        currentRow.Mileage = (int)dr["Mileage"];
                        currentRow.Msrp = (decimal)dr["Msrp"];
                        currentRow.SalePrice = (decimal)dr["SalePrice"];
                        currentRow.Featured = (bool)dr["Featured"];
                        currentRow.Sold = (bool)dr["Sold"];
                        currentRow.NewOld = (bool)dr["NewOld"];


                        if (dr["Description"] != DBNull.Value)
                        {
                            currentRow.Description = dr["Description"].ToString();
                        }

                        if (dr["ImageFileName"] != DBNull.Value)
                        {
                            currentRow.ImageFileName = dr["ImageFileName"].ToString();
                        }

                        vehicles.Add(currentRow);
                    }
                }
            }
            return vehicles;
        }

        public List<FeaturedVehicleItem> GetFeatured()
        {
            List<FeaturedVehicleItem> vehicles = new List<FeaturedVehicleItem>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehiclesSelectFeatured", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        FeaturedVehicleItem currentRow = new FeaturedVehicleItem();
                        currentRow.MakeID = (int)dr["MakeID"];
                        currentRow.ModelID = (int)dr["ModelID"];
                        currentRow.VehicleID = (int)dr["VehicleID"];
                        currentRow.Year = (int)dr["Year"];
                        currentRow.MakeName = dr["MakeName"].ToString();
                        currentRow.ModelName = dr["ModelName"].ToString();
                        currentRow.SalePrice = (decimal)dr["SalePrice"];
                        currentRow.Featured = (bool)dr["Featured"];

                        if (dr["ImageFileName"] != DBNull.Value)
                        {
                            currentRow.ImageFileName = dr["ImageFileName"].ToString();
                        }

                        vehicles.Add(currentRow);
                    }
                }
            }
            return vehicles;
        }

        public Vehicle GetVehicleByID(int vehicleID)
        {
            Vehicle vehicle = null;
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetVehicleByID", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@VehicleID", vehicleID);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        vehicle = new Vehicle();
                        vehicle.MakeID = (int)dr["MakeID"];
                        vehicle.ModelID = (int)dr["ModelID"];
                        vehicle.BodyStyleID = (int)dr["BodyStyleID"];
                        vehicle.ExteriorColorID = (int)dr["ExteriorColorID"];
                        vehicle.InteriorColorID = (int)dr["ModelID"];
                        vehicle.VehicleID = (int)dr["VehicleID"];
                        vehicle.Vin = (int)dr["Vin"];
                        vehicle.Year = (int)dr["Year"];
                        vehicle.MakeName = dr["MakeName"].ToString();
                        vehicle.ModelName = dr["ModelName"].ToString();
                        vehicle.Style = dr["Style"].ToString();
                        vehicle.ExteriorColor = dr["ExteriorColor"].ToString();
                        vehicle.InteriorColor = dr["InteriorColor"].ToString();
                        vehicle.TransmissionID = (int)dr["TransmissionID"];
                        vehicle.Type = dr["Type"].ToString();
                        vehicle.Mileage = (int)dr["Mileage"];
                        vehicle.Msrp = (decimal)dr["Msrp"];
                        vehicle.SalePrice = (decimal)dr["SalePrice"];
                        vehicle.Featured = (bool)dr["Featured"];
                        vehicle.Sold = (bool)dr["Sold"];
                        vehicle.NewOld = (bool)dr["NewOld"];


                        if (dr["Description"] != DBNull.Value)
                        {
                            vehicle.Description = dr["Description"].ToString();
                        }

                        if (dr["ImageFileName"] != DBNull.Value)
                        {
                            vehicle.ImageFileName = dr["ImageFileName"].ToString();
                        }
                    }
                }
            }
            return vehicle;
        }

        public List<Vehicle> SearchNew(string searchText, decimal minPrice, decimal maxPrice, int minYear, int maxYear)
        {
            if (searchText == "NoText")
            {
                searchText = "";
            }
            List<Vehicle> vehicles = new List<Vehicle>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehicleSearchNew", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@SearchText", searchText);
                cmd.Parameters.AddWithValue("@MinPrice", minPrice);
                cmd.Parameters.AddWithValue("@MaxPrice", maxPrice);
                cmd.Parameters.AddWithValue("@MinYear", minYear);
                cmd.Parameters.AddWithValue("@MaxYear", maxYear);


                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Vehicle vehicle = new Vehicle();
                        vehicle = new Vehicle();
                        vehicle.MakeID = (int)dr["MakeID"];
                        vehicle.ModelID = (int)dr["ModelID"];
                        vehicle.BodyStyleID = (int)dr["BodyStyleID"];
                        vehicle.ExteriorColorID = (int)dr["ExteriorColorID"];
                        vehicle.InteriorColorID = (int)dr["ModelID"];
                        vehicle.VehicleID = (int)dr["VehicleID"];
                        vehicle.Vin = (int)dr["Vin"];
                        vehicle.Year = (int)dr["Year"];
                        vehicle.MakeName = dr["MakeName"].ToString();
                        vehicle.ModelName = dr["ModelName"].ToString();
                        vehicle.Style = dr["Style"].ToString();
                        vehicle.ExteriorColor = dr["ExteriorColor"].ToString();
                        vehicle.InteriorColor = dr["InteriorColor"].ToString();
                        vehicle.TransmissionID = (int)dr["TransmissionID"];
                        vehicle.Type = dr["Type"].ToString();
                        vehicle.Mileage = (int)dr["Mileage"];
                        vehicle.Msrp = (decimal)dr["Msrp"];
                        vehicle.SalePrice = (decimal)dr["SalePrice"];
                        vehicle.Featured = (bool)dr["Featured"];
                        vehicle.Sold = (bool)dr["Sold"];
                        vehicle.NewOld = (bool)dr["NewOld"];


                        if (dr["Description"] != DBNull.Value)
                        {
                            vehicle.Description = dr["Description"].ToString();
                        }

                        if (dr["ImageFileName"] != DBNull.Value)
                        {
                            vehicle.ImageFileName = dr["ImageFileName"].ToString();
                        }

                        vehicles.Add(vehicle);
                    }
                }
            }
            return vehicles;
        }

        public List<Vehicle> SearchSales(string searchText, decimal minPrice, decimal maxPrice, int minYear, int maxYear)
        {
            if (searchText == "NoText")
            {
                searchText = "";
            }
            List<Vehicle> vehicles = new List<Vehicle>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehicleSearchSales", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@SearchText", searchText);
                cmd.Parameters.AddWithValue("@MinPrice", minPrice);
                cmd.Parameters.AddWithValue("@MaxPrice", maxPrice);
                cmd.Parameters.AddWithValue("@MinYear", minYear);
                cmd.Parameters.AddWithValue("@MaxYear", maxYear);


                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Vehicle vehicle = new Vehicle();
                        vehicle = new Vehicle();
                        vehicle.MakeID = (int)dr["MakeID"];
                        vehicle.ModelID = (int)dr["ModelID"];
                        vehicle.BodyStyleID = (int)dr["BodyStyleID"];
                        vehicle.ExteriorColorID = (int)dr["ExteriorColorID"];
                        vehicle.InteriorColorID = (int)dr["ModelID"];
                        vehicle.VehicleID = (int)dr["VehicleID"];
                        vehicle.Vin = (int)dr["Vin"];
                        vehicle.Year = (int)dr["Year"];
                        vehicle.MakeName = dr["MakeName"].ToString();
                        vehicle.ModelName = dr["ModelName"].ToString();
                        vehicle.Style = dr["Style"].ToString();
                        vehicle.ExteriorColor = dr["ExteriorColor"].ToString();
                        vehicle.InteriorColor = dr["InteriorColor"].ToString();
                        vehicle.TransmissionID = (int)dr["TransmissionID"];
                        vehicle.Type = dr["Type"].ToString();
                        vehicle.Mileage = (int)dr["Mileage"];
                        vehicle.Msrp = (decimal)dr["Msrp"];
                        vehicle.SalePrice = (decimal)dr["SalePrice"];
                        vehicle.Featured = (bool)dr["Featured"];
                        vehicle.Sold = (bool)dr["Sold"];
                        vehicle.NewOld = (bool)dr["NewOld"];


                        if (dr["Description"] != DBNull.Value)
                        {
                            vehicle.Description = dr["Description"].ToString();
                        }

                        if (dr["ImageFileName"] != DBNull.Value)
                        {
                            vehicle.ImageFileName = dr["ImageFileName"].ToString();
                        }

                        vehicles.Add(vehicle);
                    }
                }
            }
            return vehicles;
        }

        public IEnumerable<Vehicle> SearchUsed(string searchText, decimal minPrice, decimal maxPrice, int minYear, int maxYear)
        {

            if(searchText == "NoText")
            {
                searchText = "";
            }
            List<Vehicle> vehicles = new List<Vehicle>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehicleSearchUsed", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@SearchText", searchText);
                cmd.Parameters.AddWithValue("@MinPrice", minPrice);
                cmd.Parameters.AddWithValue("@MaxPrice", maxPrice);
                cmd.Parameters.AddWithValue("@MinYear", minYear);
                cmd.Parameters.AddWithValue("@MaxYear", maxYear);


                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Vehicle vehicle = new Vehicle();
                        vehicle = new Vehicle();
                        vehicle.MakeID = (int)dr["MakeID"];
                        vehicle.ModelID = (int)dr["ModelID"];
                        vehicle.BodyStyleID = (int)dr["BodyStyleID"];
                        vehicle.ExteriorColorID = (int)dr["ExteriorColorID"];
                        vehicle.InteriorColorID = (int)dr["ModelID"];
                        vehicle.VehicleID = (int)dr["VehicleID"];
                        vehicle.Vin = (int)dr["Vin"];
                        vehicle.Year = (int)dr["Year"];
                        vehicle.MakeName = dr["MakeName"].ToString();
                        vehicle.ModelName = dr["ModelName"].ToString();
                        vehicle.Style = dr["Style"].ToString();
                        vehicle.ExteriorColor = dr["ExteriorColor"].ToString();
                        vehicle.InteriorColor = dr["InteriorColor"].ToString();
                        vehicle.TransmissionID = (int)dr["TransmissionID"];
                        vehicle.Type = dr["Type"].ToString();
                        vehicle.Mileage = (int)dr["Mileage"];
                        vehicle.Msrp = (decimal)dr["Msrp"];
                        vehicle.SalePrice = (decimal)dr["SalePrice"];
                        vehicle.Featured = (bool)dr["Featured"];
                        vehicle.Sold = (bool)dr["Sold"];
                        vehicle.NewOld = (bool)dr["NewOld"];


                        if (dr["Description"] != DBNull.Value)
                        {
                            vehicle.Description = dr["Description"].ToString();
                        }

                        if (dr["ImageFileName"] != DBNull.Value)
                        {
                            vehicle.ImageFileName = dr["ImageFileName"].ToString();
                        }

                        vehicles.Add(vehicle);
                    }
                }
            }
            return vehicles;
        }

        public void Update(Vehicle vehicle)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehicleUpdate", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@VehicleID", vehicle.VehicleID);
                cmd.Parameters.AddWithValue("@MakeID", vehicle.MakeID);
                cmd.Parameters.AddWithValue("@ModelID", vehicle.ModelID);
                cmd.Parameters.AddWithValue("@BodyStyleID", vehicle.BodyStyleID);
                cmd.Parameters.AddWithValue("@ExteriorColorID", vehicle.ExteriorColorID);
                cmd.Parameters.AddWithValue("@InteriorColorID", vehicle.InteriorColorID);
                cmd.Parameters.AddWithValue("@ImageFileName", vehicle.ImageFileName);
                cmd.Parameters.AddWithValue("@Description", vehicle.Description);
                cmd.Parameters.AddWithValue("@Featured", vehicle.Featured);
                cmd.Parameters.AddWithValue("@Mileage", vehicle.Mileage);
                cmd.Parameters.AddWithValue("@Msrp", vehicle.Msrp);
                cmd.Parameters.AddWithValue("@NewOld", vehicle.NewOld);
                cmd.Parameters.AddWithValue("@SalePrice", vehicle.SalePrice);
                cmd.Parameters.AddWithValue("@Sold", vehicle.Sold);
                cmd.Parameters.AddWithValue("@TransmissionID", vehicle.TransmissionID);
                cmd.Parameters.AddWithValue("@Vin", vehicle.Vin);
                cmd.Parameters.AddWithValue("@Year", vehicle.Year);

                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public void Purchase(int vehicleID)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehiclePurchase", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@VehicleID", vehicleID);

                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }
            
    }
}
