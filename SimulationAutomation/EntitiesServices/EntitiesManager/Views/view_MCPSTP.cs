using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAutomation.EntitiesServices.EntitiesManager.Views
{
    public class view_MCPSTP
    {
        public view_MCPSTP()
        {
            this._dbContext = new DB.dbRT1_SADataContext();
        }

        private readonly DB.dbRT1_SADataContext _dbContext;

        public List<DB.view_MCPSTP> listParentItem()
        {
            try
            {
                return this._dbContext.view_MCPSTPs.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
