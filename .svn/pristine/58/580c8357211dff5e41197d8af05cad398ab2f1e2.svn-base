using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAutomation.EntitiesServices.EntitiesManager.StoredProcedures
{
    public class sp_RT1Simulation_Calendar
    {
        public sp_RT1Simulation_Calendar()
        {
            this._dbContext = new DB.dbRT1_SADataContext();
        }
        private readonly DB.dbRT1_SADataContext _dbContext;

        public List<DB.sp_RT1Simulation_CalendarResult> SP_RT1Simulation_Calendar()
        {
            try
            {
                return this._dbContext.sp_RT1Simulation_Calendar().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
