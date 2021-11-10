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
    public class InteriorColorRepositoryAdo : IInteriorColorRepository
    {
        public List<InteriorColorModel> GetAll()
        {
            List<InteriorColorModel> colors = new List<InteriorColorModel>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("InteriorColorSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        InteriorColorModel currentRow = new InteriorColorModel();
                        currentRow.InteriorColorID = (int)dr["InteriorColorID"];
                        currentRow.InteriorColor = dr["InteriorColor"].ToString();

                        colors.Add(currentRow);
                    }
                }
            }
            return colors;
        }
    }
}
