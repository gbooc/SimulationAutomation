using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAutomation.EntitiesServices.EntitiesManager.Views
{
    public class view_Simulate_InputeQuantity
    {

        public view_Simulate_InputeQuantity()
        {
            this._dbContext = new DB.dbRT1_SADataContext();
        }

        private readonly DB.dbRT1_SADataContext _dbContext;

        public List<DB.view_Simulate_InputQuantity> SimulatorInputeQty()
        {
            try
            {
                return this._dbContext.view_Simulate_InputQuantities.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
