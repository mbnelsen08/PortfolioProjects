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
    public class SalesRepositoryAdo : ISalesRepository
    {
        public void Add(Sale sale)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SaleInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@SaleID", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                DateTime date = DateTime.Now;

                cmd.Parameters.Add(param);
                cmd.Parameters.AddWithValue("@CustomerName", sale.CustomerName);
                cmd.Parameters.AddWithValue("@CustomerAddress", sale.CustomerAddress);
                cmd.Parameters.AddWithValue("@CustomerCity", sale.CustomerCity);
                cmd.Parameters.AddWithValue("@CustomerEmail", sale.CustomerEmail);
                cmd.Parameters.AddWithValue("@CustomerPhone", sale.CustomerPhone);
                cmd.Parameters.AddWithValue("@CustomerZipcode", sale.CustomerZipcode);
                cmd.Parameters.AddWithValue("@PurchasePrice", sale.PurchasePrice);
                cmd.Parameters.AddWithValue("@PurchaseTypeID", sale.PurchaseTypeID);
                cmd.Parameters.AddWithValue("@StateID", sale.StateID);
                cmd.Parameters.AddWithValue("@User", sale.User);
                cmd.Parameters.AddWithValue("@UserID", sale.UserID);
                cmd.Parameters.AddWithValue("@VehicleID", sale.VehicleID);
                cmd.Parameters.AddWithValue("@Vin", sale.Vin);
                cmd.Parameters.AddWithValue("@PurchaseDate", date);

                cn.Open();

                cmd.ExecuteNonQuery();

                sale.SaleID = (int)param.Value;
            }
        }

        public List<SalesReportItem> Search(string userID, DateTime minDate, DateTime maxDate)
        {
            List<SalesReportItem> sales = new List<SalesReportItem>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SalesSearch", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserID", userID);
                cmd.Parameters.AddWithValue("@MinDate", minDate);
                cmd.Parameters.AddWithValue("@MaxDate", maxDate);


                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        SalesReportItem report = new SalesReportItem();
                        report.User = dr["User"].ToString();
                        report.TotalVehicles = (int)dr["SalesPerUser"];
                        report.TotalSales = (decimal)dr["TotalSales"];

                        sales.Add(report);
                    }
                }
            }
            return sales;
        }
    }
}
