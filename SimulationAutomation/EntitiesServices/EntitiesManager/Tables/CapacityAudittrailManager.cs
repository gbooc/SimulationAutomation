using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAutomation.EntitiesServices.EntitiesManager.Tables
{
    public class CapacityAudittrailManager
    {
        public CapacityAudittrailManager()
        {
            this._dbContext = new DB.dbRT1_SADataContext();
        }

        private readonly DB.dbRT1_SADataContext _dbContext;
        
        public List<DB.CapacityAudittrail> CapacityAuditTrail()
        {
            try
            {
                var data = this._dbContext.CapacityAudittrails.ToList();
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void SaveCapacityAuditTrail(Models.Maintenance.CapacityModel.CapacityAuditTrail capacityAuditTrailModel)
        {
            try
            {
                DB.CapacityAudittrail capacityAudittrail = new DB.CapacityAudittrail();
                capacityAudittrail.model = capacityAuditTrailModel.model;
                capacityAudittrail.WorkScheme = capacityAuditTrailModel.WorkScheme;
                capacityAudittrail.from = capacityAuditTrailModel.from;
                capacityAudittrail.to = capacityAuditTrailModel.to;
                capacityAudittrail.reason = capacityAuditTrailModel.reason;
                capacityAudittrail.incharge = capacityAuditTrailModel.incharge;
                this._dbContext.CapacityAudittrails.InsertOnSubmit(capacityAudittrail);
                this._dbContext.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
