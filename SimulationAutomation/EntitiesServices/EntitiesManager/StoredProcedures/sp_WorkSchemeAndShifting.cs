using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAutomation.EntitiesServices.EntitiesManager.StoredProcedures
{
    class sp_WorkSchemeAndShifting
    {
        public sp_WorkSchemeAndShifting()
        {
            this._dbContext = new DB.dbRT1_SADataContext();
        }

        private readonly DB.dbRT1_SADataContext _dbContext;


        public List<DB.sp_WorkSchemeAndShiftingResult> SP_WorkSchemeAndShifting(string type)
        {
            try
            {
                var data = this._dbContext.sp_WorkSchemeAndShifting(type).ToList();
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
