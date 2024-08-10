using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAutomation.EntitiesServices.EntitiesManager.Tables
{
    public class CriticalPartSimulator
    {
        public CriticalPartSimulator()
        {
            this._dbContext = new DB.dbRT1_SADataContext();
        }
        private readonly DB.dbRT1_SADataContext _dbContext;

        public List<DB.tbl_PartsSimulator> tbl_partsimulator()
        {
            try
            {
                var data = this._dbContext.tbl_PartsSimulators.ToList();
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



    }
}
