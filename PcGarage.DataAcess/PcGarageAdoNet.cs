using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;


namespace PcGarage.BusinessLogic
{
    public class PcGarageAdoNet
    {
        public SqlConnection OpenConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["PcGarageEntities"].ConnectionString;

            SqlConnection conn = new SqlConnection(connectionString);

                conn.Open();
                return conn;
            
            
        }

        public SqlParameter CreateParameterByValueAndName(object value, string name)
        {
            SqlParameter param = new SqlParameter();
            param.Value = value;
            param.ParameterName = name;

            return param;
        }
        public void CloseConnection(SqlConnection conn)
        {
            conn.Close();
        }


    }

    
}
