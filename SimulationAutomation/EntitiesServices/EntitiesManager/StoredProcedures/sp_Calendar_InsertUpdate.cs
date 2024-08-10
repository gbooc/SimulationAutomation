using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAutomation.EntitiesServices.EntitiesManager.StoredProcedures
{
    public class sp_Calendar_InsertUpdate
    {
        public sp_Calendar_InsertUpdate()
        {
            this._dbContext = new DB.dbRT1_SADataContext();
        }

        private readonly DB.dbRT1_SADataContext _dbContext;

        public void SP_Calendar_InsertUpdate(string type, DateTime date, string dayName, string shiftACode, string shiftAWorkScheme, Nullable<decimal> shiftAHours, string shiftBCode, string shiftBWorkScheme, Nullable<decimal> shiftBHours, string shiftCCode, string shiftCWorkScheme, Nullable<decimal> shiftCHours, string status, string action, string userLog)
        {
            try
            {
                this._dbContext.sp_Calendar_InsertUpdate(type, date.Date, dayName, shiftACode, shiftAWorkScheme, shiftAHours, shiftBCode, shiftBWorkScheme, shiftBHours, shiftCCode, shiftCWorkScheme, shiftCHours, status, action, userLog);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
