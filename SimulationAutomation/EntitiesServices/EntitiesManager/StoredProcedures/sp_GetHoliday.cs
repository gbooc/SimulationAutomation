using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAutomation.EntitiesServices.EntitiesManager.StoredProcedures
{
    public class sp_GetHoliday
    {
        public sp_GetHoliday()
        {
            this._dbContext = new DB.dbRT1_SADataContext();
        }

        private readonly DB.dbRT1_SADataContext _dbContext;


        public List<DB.sp_GetHolidayResult> SP_getHoliday(DateTime from, DateTime to)
        {
            try
            {
                var data = this._dbContext.sp_GetHoliday(from.Date, to.Date).ToList();
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
