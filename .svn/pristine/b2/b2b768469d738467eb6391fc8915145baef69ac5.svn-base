using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAutomation.Controllers.Reports
{
    public class POMonthlyUploadedController
    {
        public POMonthlyUploadedController()
        {

        }
        public DataTable GetComparisonDemand(string DateUploaded)
        {
          
            try
            {
                var Result = new EntitiesServices.EntitiesManager.StoredProcedures
                                                 .sp_Monthly_PO_Uploaded()
                                                 .SP_Get_MonthlyPOUploaded(DateUploaded);
                return Result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable GetTotalDemand(string DateUploaded1, string DateUploaded2)
        {

            try
            {
                var Result = new EntitiesServices.EntitiesManager.StoredProcedures
                                                 .sp_Monthly_PO_Uploaded()
                                                 .SP_Get_TotalUploaded(DateUploaded1,DateUploaded2);
                return Result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
