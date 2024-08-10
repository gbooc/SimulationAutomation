using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAutomation.EntitiesServices.EntitiesManager.StoredProcedures
{
    public class sp_Monthly_PO_Uploaded
    {
        public sp_Monthly_PO_Uploaded()
        {
            this._dbContext = new DB.dbRT1_SADataContext();
        }
        
        private readonly DB.dbRT1_SADataContext _dbContext;

        public DataTable SP_Get_MonthlyPOUploaded(string DateUploaded)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(DB.dbConnection._DB_CONNECT))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_monthly_po_uploaded", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@dateuploaded", DateUploaded);
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
        public DataTable SP_Get_TotalUploaded(string DateUploaded1,string DateUploaded2)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(DB.dbConnection._DB_CONNECT))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_monthly_uploaded_total", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@dateuploaded", DateUploaded1);
                    cmd.Parameters.AddWithValue("@dateuploaded2", DateUploaded2);
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
