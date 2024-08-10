using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAutomation.EntitiesServices.EntitiesManager.StoredProcedures
{
    public class sp_GetPerformanceReport
    {
        public sp_GetPerformanceReport()
        {
        }

        public DataTable GetPerformanceReport(int yearMonthFrom, int yearMonthTo)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(DB.dbConnection._DB_CONNECT))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_GetPerformanceReport", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@yearMonthFrom", yearMonthFrom);
                    cmd.Parameters.AddWithValue("@yearMonthTo", yearMonthTo);
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
