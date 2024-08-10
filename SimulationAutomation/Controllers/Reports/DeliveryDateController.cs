using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAutomation.Controllers.Reports
{
     public class DeliveryDateController
    {
         private EntitiesServices.EntitiesManager.StoredProcedures.sp_GetDeliveryDate _deliverydate = new EntitiesServices.EntitiesManager.StoredProcedures.sp_GetDeliveryDate();

         public Models.Reports.DeliveryDateList getlist(string type)
         {
              Models.Reports.DeliveryDateList result = new Models.Reports.DeliveryDateList();

              try
              {
                  result._List = new EntitiesServices.EntitiesManager.StoredProcedures.sp_GetDeliveryDate()
                                                                                      .sp_deliverydate(type)
                                                                                      .Select(x => new Models.Reports.DeliveryDate()
                                                                                      {
                                                                                          factorycode = x.ZBMP,
                                                                                          date = x.ZBYDLD.ToString(),
                                                                                          itemnumber = x.ZBIT,
                                                                                          quantity = Convert.ToInt32(x.ZBQOVR)

                                                                                      }).ToList();
              }
             catch(Exception ex)
              {
                  result.Error = ex.Message;
              }

              return result;
         }
    }
}
