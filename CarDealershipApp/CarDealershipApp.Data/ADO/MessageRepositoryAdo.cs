using CarDealershipApp.Data.Interfaces;
using CarDealershipApp.Models.Tables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealershipApp.Data.ADO
{
    public class MessageRepositoryAdo : IMessageRepository
    {
        public void Add(Message message)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("MessageInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@MessageID", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);
                cmd.Parameters.AddWithValue("@Name", message.Name);
                cmd.Parameters.AddWithValue("@MessageText", message.MessageText);

                if(message.Phone == null)
                {
                    cmd.Parameters.AddWithValue("@Phone", SqlString.Null);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Phone", message.Phone);
                }

                if (message.Email == null)
                {
                    cmd.Parameters.AddWithValue("@Email", SqlString.Null);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Email", message.Email);
                }


                cn.Open();

                cmd.ExecuteNonQuery();

                message.MessageID = (int)param.Value;


            }
        }
    }
}
