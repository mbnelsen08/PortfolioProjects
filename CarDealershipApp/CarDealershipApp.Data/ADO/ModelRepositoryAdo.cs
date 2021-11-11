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
    public class ModelRepositoryAdo : IModelRepository
    {
        public void Add(Model model)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ModelInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@ModelID", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                DateTime date = DateTime.Now;

                cmd.Parameters.Add(param);
                cmd.Parameters.AddWithValue("@ModelName", model.ModelName);
                cmd.Parameters.AddWithValue("@MakeID", model.MakeID);
                cmd.Parameters.AddWithValue("@UserEmail", model.UserEmail);
                cmd.Parameters.AddWithValue("@DateAdded", date);

                cn.Open();

                cmd.ExecuteNonQuery();

                model.ModelID = (int)param.Value;


            }
        }

        public List<Model> GetAll()
        {
            List<Model> models = new List<Model>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ModelsSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Model currentRow = new Model();
                        currentRow.ModelID = (int)dr["ModelID"];
                        currentRow.MakeID = (int)dr["MakeID"];
                        currentRow.ModelName = dr["ModelName"].ToString();
                        currentRow.UserEmail = dr["UserEmail"].ToString();
                        currentRow.MakeName = dr["MakeName"].ToString();
                        currentRow.DateAdded = (DateTime)dr["DateAdded"];

                        models.Add(currentRow);
                    }
                }
            }
            return models;
        }
    }
}
