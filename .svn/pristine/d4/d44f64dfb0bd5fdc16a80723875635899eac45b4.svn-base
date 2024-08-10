using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAutomation.EntitiesServices.EntitiesManager.StoredProcedures
{
    public class sp_Line_Model_Activation
    {
        public sp_Line_Model_Activation()
        {
            this._dbContext = new DB.dbRT1_SADataContext();
        }

        private readonly DB.dbRT1_SADataContext _dbContext;

        public void SP_Line_Model_Activation(string model, string line, string status)
        {
            try
            {
                this._dbContext.sp_Line_Model_Activation(model, line, status);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
