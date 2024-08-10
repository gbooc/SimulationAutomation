using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAutomation.EntitiesServices.EntitiesManager.Views
{
    public class view_MJINVP
    {
        public view_MJINVP()
        {
            this._dbContext = new DB.dbRT1_SADataContext(); 
        }
        private readonly DB.dbRT1_SADataContext _dbContext;

        public List<DB.MJINVP> LISTMJINVP()
        {
            try
            {
                var data = this._dbContext.MJINVPs.ToList();
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
