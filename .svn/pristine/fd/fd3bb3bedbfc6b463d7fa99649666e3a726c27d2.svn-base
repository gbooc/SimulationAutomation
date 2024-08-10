using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAutomation.EntitiesServices.EntitiesManager.StoredProcedures
{
    class sp_Report_Simulation_for_POBalance
    {
        public sp_Report_Simulation_for_POBalance()
        {
            this._dbContext = new DB.dbRT1_SADataContext();
        }
        private readonly DB.dbRT1_SADataContext _dbContext;

        public List<DB.sp_Report_Simulation_for_POBalanceResult> SP_Report_Simulation_for_POBalance(int version)
        {
            try
            {
                return this._dbContext.sp_Report_Simulation_for_POBalance(version).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
