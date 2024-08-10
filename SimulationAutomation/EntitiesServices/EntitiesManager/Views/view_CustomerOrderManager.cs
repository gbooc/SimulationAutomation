using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAutomation.EntitiesServices.EntitiesManager.Views
{
    public class view_CustomerOrderManager
    {
        public view_CustomerOrderManager()
        {
            this._dbContext = new DB.dbRT1_SADataContext(); 
        }
        private readonly DB.dbRT1_SADataContext _dbContext;

        public List<DB.vw_customer_order> view_customer_order()
        {
            try
            {
                var data = this._dbContext.vw_customer_orders.ToList();
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
