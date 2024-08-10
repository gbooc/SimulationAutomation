using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAutomation.Models.Maintenance
{
    public class CapacityModel
    {
        public class Capacity : LogModel
        {
            public virtual int INDEX { get; set; }
            public virtual string CODE { get; set; }
            public virtual string WorkScheme { get; set; }
            public virtual string Model { get; set; }
            public virtual string Line { get; set; }
            public virtual string tat { get; set; }
            public virtual Nullable<int> CapacityValue { get; set; }
            public virtual string Status { get; set; }
        }

        public class ModelCapacity
        {
            public virtual string rinks_no { get; set; }
            public virtual string tat { get; set; }
            public virtual string Line_A { get; set; }
            public virtual Nullable<int> CODE_HOURS_A_A { get; set; }
            public virtual Nullable<int> CODE_HOURS_B_A { get; set; }
            public virtual Nullable<int> CODE_HOURS_C_A { get; set; }
            public virtual Nullable<int> CODE_HOURS_D_A { get; set; }
            public virtual Nullable<int> CODE_HOURS_E_A { get; set; }

            public virtual string Line_B { get; set; }
            public virtual Nullable<int> CODE_HOURS_A_B { get; set; }
            public virtual Nullable<int> CODE_HOURS_B_B { get; set; }
            public virtual Nullable<int> CODE_HOURS_C_B { get; set; }
            public virtual Nullable<int> CODE_HOURS_D_B { get; set; }
            public virtual Nullable<int> CODE_HOURS_E_B { get; set; }

            public virtual string STATUS { get; set; }
        }

        public class ModelCapacityList : BaseModel
        {
            public List<ModelCapacity> _List { get; set; }
            public ModelCapacityList()
            {
                this._List = new List<ModelCapacity>();
            }
        }

        public class CapacityAuditTrail : LogModel
        {
            public virtual int id { get; set; }
            public virtual string model { get; set; }
            public virtual string WorkScheme { get; set; }
            public virtual int from { get; set; }
            public virtual int to { get; set; }
            public virtual string reason { get; set; }
            public virtual Nullable<DateTime> dateupdated { get; set; }
            public virtual string incharge { get; set; }
        }

        public class CapacityAuditTrailList : BaseModel
        {
            public List<CapacityAuditTrail> _List { get; set; }

            public CapacityAuditTrailList()
            {
                this._List = new List<CapacityAuditTrail>();
            }
        }
    }
}