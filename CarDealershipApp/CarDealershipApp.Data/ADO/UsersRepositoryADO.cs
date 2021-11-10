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
    public class UsersRepositoryADO
    {
        public List<UserWithRoleName> GetAll()
        {
            List<UserWithRoleName> users = new List<UserWithRoleName>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("UsersSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        UserWithRoleName currentRow = new UserWithRoleName();
                        currentRow.FirstName = dr["FirstName"].ToString();
                        currentRow.LastName = dr["LastName"].ToString();
                        currentRow.Email = dr["Email"].ToString();
                        currentRow.Role = dr["Name"].ToString();
                        currentRow.Id = dr["Id"].ToString();
                        users.Add(currentRow);
                    }
                }
            }
            return users;
        }
    }
}
