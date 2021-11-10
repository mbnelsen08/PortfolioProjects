using CarDealershipApp.Data.Interfaces;
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
    public class MakeRepositoryAdo : IMakeRepository
    {
        public void Add(Make make)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("MakeInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@MakeID", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                DateTime date = DateTime.Now;

                cmd.Parameters.Add(param);
                cmd.Parameters.AddWithValue("@MakeName", make.MakeName);
                cmd.Parameters.AddWithValue("@UserEmail", make.UserEmail);
                cmd.Parameters.AddWithValue("@Date", date);

                cn.Open();

                cmd.ExecuteNonQuery();

                make.MakeID= (int)param.Value;


            }
        }

        public List<Make> GetAll()
        {
            List<Make> makes = new List<Make>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("MakesSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Make currentRow = new Make();
                        currentRow.MakeID = (int)dr["MakeID"];
                        currentRow.MakeName = dr["MakeName"].ToString();
                        currentRow.UserEmail = dr["UserEmail"].ToString();
                        currentRow.DateAdded = (DateTime)dr["DateAdded"];

                        makes.Add(currentRow);
                    }
                }
            }
            return makes;
        }
    }
}
