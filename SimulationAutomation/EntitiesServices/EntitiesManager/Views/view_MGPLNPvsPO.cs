using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAutomation.EntitiesServices.EntitiesManager.Views
{
    public class view_MGPLNPvsPOManager
    {
        public view_MGPLNPvsPOManager()
        {
            this._dbContext = new DB.dbRT1_SADataContext(); 
        }
        private readonly DB.dbRT1_SADataContext _dbContext;

        public List<DB.MGPLNPvsPO> view_compute_MGPLNPvsPOResult()
        {
            try
            {
                var data = this._dbContext.MGPLNPvsPOs.ToList();
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
