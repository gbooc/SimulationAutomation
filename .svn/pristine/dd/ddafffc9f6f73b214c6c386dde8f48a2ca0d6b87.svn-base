using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAutomation.EntitiesServices.EntitiesManager.StoredProcedures
{
    public class sp_Get_Customer_Order
    {
        public sp_Get_Customer_Order()
        {
            this._dbContext = new DB.dbRT1_SADataContext();
        }
        private readonly DB.dbRT1_SADataContext _dbContext;

        public List<DB.sp_get_customer_orderResult> SP_Get_CUSTOMERORDER(string MonthUploaded)
        {
            try
            {
                var data = this._dbContext.sp_get_customer_order(MonthUploaded).ToList();
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
