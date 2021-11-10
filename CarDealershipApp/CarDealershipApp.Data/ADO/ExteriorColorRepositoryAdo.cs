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
    public class ExteriorColorRepositoryAdo : IExteriorColorRepository
    {
        public List<ExteriorColorModel> GetAll()
        {
            List<ExteriorColorModel> colors = new List<ExteriorColorModel>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ExteriorColorSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ExteriorColorModel currentRow = new ExteriorColorModel();
                        currentRow.ExteriorColorID = (int)dr["ExteriorColorID"];
                        currentRow.ExteriorColor = dr["ExteriorColor"].ToString();

                        colors.Add(currentRow);
                    }
                }
            }
            return colors;
        }
    }
}
