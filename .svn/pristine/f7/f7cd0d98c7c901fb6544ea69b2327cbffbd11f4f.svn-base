using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAutomation.EntitiesServices.EntitiesManager.StoredProcedures
{
    public class sp_GetSimulationData
    {
        public sp_GetSimulationData()
        {
        }

        public DataTable GetSimulationData(int version)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(DB.dbConnection._DB_CONNECT))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_GetSimulationData", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@version", version);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    con.Close();
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}