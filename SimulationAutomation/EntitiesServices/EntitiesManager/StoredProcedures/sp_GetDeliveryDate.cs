using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAutomation.EntitiesServices.EntitiesManager.StoredProcedures
{
    class sp_GetDeliveryDate
    {
        public sp_GetDeliveryDate()
        {
            this._dbContext =  new DB.dbRT1_SADataContext();
        }

        private readonly DB.dbRT1_SADataContext _dbContext;

        public List<DB.sp_GetDeliveryDateResult> sp_deliverydate(string type)
        {
            try
            {
                var data = this._dbContext.sp_GetDeliveryDate(type).ToList();
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
