using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAutomation.EntitiesServices.EntitiesManager.StoredProcedures
{
    public class sp_Compute_MGPLNPvsPOManager
    {
        public sp_Compute_MGPLNPvsPOManager()
        {
            this._dbContext = new DB.dbRT1_SADataContext();
        }

        private readonly DB.dbRT1_SADataContext _dbContext;

        public DataTable sp_Compute_MGPLNPvsPO(int From, int To)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(DB.dbConnection._DB_CONNECT))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_compute_MGPLNPvsPO", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@from", From);
                    cmd.Parameters.AddWithValue("@to", To);

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
