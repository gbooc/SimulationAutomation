using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAutomation.EntitiesServices.EntitiesManager.StoredProcedures
{
    public class sp_Get_Summary_PO_Uploaded
    {
        public sp_Get_Summary_PO_Uploaded()
        {
            this._dbContext = new DB.dbRT1_SADataContext();
        }
        private readonly DB.dbRT1_SADataContext _dbContext;

        public List<DB.sp_get_summary_po_uploadedResult> SP_Get_CustomerOrder_Summary()
        {
            try
            {
                var data = this._dbContext.sp_get_summary_po_uploaded().ToList();
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
