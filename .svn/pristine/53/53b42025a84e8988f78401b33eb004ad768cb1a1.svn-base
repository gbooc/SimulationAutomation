using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAutomation.Models.Maintenance
{
    public class ModelLeadtimeModel : LogModel
    {
        public virtual int leadtime_id { get; set; }
        public virtual int model_id { get; set; }
        public virtual string model_name { get; set; }
        public virtual int sequence { get; set; }
        public virtual string description { get; set; }
        public virtual string duration { get; set; }

        public virtual int rinks_id { get; set; }
        public virtual string rinks_no { get; set; }
        public virtual string elt { get; set; }
        public virtual string tat { get; set; }
    }

    public class ModelLeadTimeList : BaseModel
    {
        public List<Models.Maintenance.ModelLeadtimeModel> _List { get; set; }

        public ModelLeadTimeList()
        {
            this._List = new List<Models.Maintenance.ModelLeadtimeModel>();
        }
    }
}
