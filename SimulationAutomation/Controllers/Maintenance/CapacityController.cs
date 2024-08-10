using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAutomation.Controllers.Maintenance
{
    public class CapacityController
    {
        public CapacityController()
        {

        }

        public Models.Maintenance.CapacityModel.ModelCapacityList GetModelCapacity()
        {
            Models.Maintenance.CapacityModel.ModelCapacityList result = new Models.Maintenance.CapacityModel.ModelCapacityList();
            try
            {
                result._List = new EntitiesServices.EntitiesManager
                                           .StoredProcedures
                                           .sp_getCapacity()
                                           .SP_getCapacity()
                                           .Select(x => new Models.Maintenance.CapacityModel.ModelCapacity
                                           {
                                               rinks_no = x.rinks_no,
                                               tat = x.tat,
                                               Line_A = x.LINE_A,
                                               CODE_HOURS_A_A = x.CODE_HOURS_A_A,
                                               CODE_HOURS_B_A = x.CODE_HOURS_B_A,
                                               CODE_HOURS_C_A = x.CODE_HOURS_C_A,
                                               CODE_HOURS_D_A = x.CODE_HOURS_D_A,
                                               CODE_HOURS_E_A = x.CODE_HOURS_E_A,
                                               
                                               Line_B = x.LINE_B,
                                               CODE_HOURS_A_B = x.CODE_HOURS_A_B,
                                               CODE_HOURS_B_B = x.CODE_HOURS_B_B,
                                               CODE_HOURS_C_B = x.CODE_HOURS_C_B,
                                               CODE_HOURS_D_B = x.CODE_HOURS_D_B,
                                               CODE_HOURS_E_B = x.CODE_HOURS_E_B,
                                              // STATUS = x.STATUS
                                           }).ToList();
            }
            catch (Exception ex)
            {
                result.Error = ex.Message;
            }

            return result;
        }

        public void LineModelActivation(string model, string line, string status)
        {
            try
            {
                new EntitiesServices.EntitiesManager.StoredProcedures.sp_Line_Model_Activation().SP_Line_Model_Activation(model, line, status);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void InsertUpdateCapacity(string code, string workScheme, string model, string line,string tat, Nullable<int> capacity, string status)
        {
            try
            {
                new EntitiesServices.EntitiesManager.StoredProcedures.sp_Capacity_InsertUpdate().SP_Capacity_InsertUpdate(code, workScheme, model, line, tat, capacity, status);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void InsertCapacityAuditTrail(Models.Maintenance.CapacityModel.CapacityAuditTrail capacityAuditTrailModel)
        {
            try
            {
                new EntitiesServices.EntitiesManager.Tables.CapacityAudittrailManager().SaveCapacityAuditTrail(capacityAuditTrailModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Models.Maintenance.CapacityModel.CapacityAuditTrailList GetCapacityAuditTrail()
        {
            Models.Maintenance.CapacityModel.CapacityAuditTrailList result = new Models.Maintenance.CapacityModel.CapacityAuditTrailList();
            try
            {
                result._List = new EntitiesServices.EntitiesManager
                                           .Tables
                                           .CapacityAudittrailManager()
                                           .CapacityAuditTrail()
                                           .OrderByDescending(x => x.dateupdated)
                                           .Select(x => new Models.Maintenance.CapacityModel.CapacityAuditTrail
                                           {
                                               id = x.id,
                                               model = x.model,
                                               WorkScheme = x.WorkScheme,
                                               from = x.from,
                                               to = x.to,
                                               reason = x.reason,
                                               dateupdated = x.dateupdated,
                                               incharge = x.incharge
                                               //rinks_no = x.rinks_no,
                                               //tat = x.tat,
                                               //Line_A = x.LINE_A,
                                               //CODE_HOURS_A_A = x.CODE_HOURS_A_A,
                                               //CODE_HOURS_B_A = x.CODE_HOURS_B_A,
                                               //CODE_HOURS_C_A = x.CODE_HOURS_C_A,
                                               //CODE_HOURS_D_A = x.CODE_HOURS_D_A,
                                               //CODE_HOURS_E_A = x.CODE_HOURS_E_A,

                                               //Line_B = x.LINE_B,
                                               //CODE_HOURS_A_B = x.CODE_HOURS_A_B,
                                               //CODE_HOURS_B_B = x.CODE_HOURS_B_B,
                                               //CODE_HOURS_C_B = x.CODE_HOURS_C_B,
                                               //CODE_HOURS_D_B = x.CODE_HOURS_D_B,
                                               //CODE_HOURS_E_B = x.CODE_HOURS_E_B,
                                               // STATUS = x.STATUS
                                           }).ToList();
            }
            catch (Exception ex)
            {
                result.Error = ex.Message;
            }

            return result;
        }
    }
}