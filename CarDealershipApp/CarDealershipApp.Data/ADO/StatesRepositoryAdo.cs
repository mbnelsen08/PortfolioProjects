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
    public class StatesRepositoryAdo : IStatesRepository
    {
        public List<State> GetAll()
        {
            List<State> states = new List<State>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("StatesSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        State currentRow = new State();
                        currentRow.StateID = (int)dr["StateID"];
                        currentRow.StateAbv = dr["StateAbv"].ToString();

                        states.Add(currentRow);
                    }
                }
            }
            return states;
        }
    }
}
