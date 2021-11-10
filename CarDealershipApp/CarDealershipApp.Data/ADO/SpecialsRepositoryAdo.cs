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
    public class SpecialsRepositoryAdo : ISpecialRepository
    {
        public void Add(Special special)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SpecialInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@SpecialID", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                DateTime date = DateTime.Now;

                cmd.Parameters.Add(param);
                cmd.Parameters.AddWithValue("@Title", special.Title);
                cmd.Parameters.AddWithValue("@Description", special.Description);

                cn.Open();

                cmd.ExecuteNonQuery();

                special.SpecialID = (int)param.Value;
            }
        }

        public void Delete(int specialID)
        {
            throw new NotImplementedException();
        }

        public List<Special> GetAll()
        {
            List<Special> specials = new List<Special>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SpecialsSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Special currentRow = new Special();
                        currentRow.SpecialID = (int)dr["SpecialID"];
                        currentRow.Title = dr["Title"].ToString();
                        currentRow.Description = dr["Description"].ToString();

                        specials.Add(currentRow);
                    }
                }
            }
            return specials;
        }
    }
}
