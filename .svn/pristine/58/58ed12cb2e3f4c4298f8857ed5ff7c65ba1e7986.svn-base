using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAutomation.Controllers.Reports
{
    public class PerformanceReportController
    {
        public PerformanceReportController()
        {
            
        }

        public DataTable GetPerformanceReport(int yearMonthFrom, int yearMonthTo)
        {
            try
            {
                return new EntitiesServices.EntitiesManager.StoredProcedures.sp_GetPerformanceReport().GetPerformanceReport(yearMonthFrom, yearMonthTo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
