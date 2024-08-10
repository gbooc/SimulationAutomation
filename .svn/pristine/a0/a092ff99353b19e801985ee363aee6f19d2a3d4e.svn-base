using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAutomation.EntitiesServices.EntitiesManager.StoredProcedures
{
    public class sp_Capacity_InsertUpdate
    {
        public sp_Capacity_InsertUpdate()
        {
            this._dbContext = new DB.dbRT1_SADataContext();
        }

        private readonly DB.dbRT1_SADataContext _dbContext;

        public void SP_Capacity_InsertUpdate(string code, string workScheme, string model, string line, string tat, Nullable<int> capacity, string status)
        {
            try
            {
                this._dbContext.sp_Capacity_InsertUpdate(code, workScheme, model, line, tat, capacity, status);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
