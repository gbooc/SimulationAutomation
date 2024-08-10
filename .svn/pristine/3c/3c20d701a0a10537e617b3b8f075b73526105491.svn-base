using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAutomation.EntitiesServices.EntitiesManager.Views
{
    public class view_MCPSTP_ItemNo
    {
        public view_MCPSTP_ItemNo()
        {
            this._dbContext = new DB.dbRT1_SADataContext(); 
        }
        private readonly DB.dbRT1_SADataContext _dbContext;

        public List<DB.view_MCPSTP_ItemNo> MCPCDP()
        {
            try
            {
                var data = this._dbContext.view_MCPSTP_ItemNos.ToList();
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
