using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAutomation.Models.Maintenance
{
    public class RinksModel : BaseModel
    {
        public virtual int ModelID { get; set; }
        public virtual string RinksNo { get; set; }
        public virtual string TAT { get; set; }
        public virtual string ELT { get; set; }
        public virtual string Destination { get; set; }
        public virtual decimal PackingQty { get; set; }
        public virtual decimal? Qty { get; set; }
        public virtual string CustomerName { get; set; }
        public virtual string PONumber { get; set; }
        public virtual int? DateDelivery { get; set; }
        public virtual string Suffix { get; set; }
        public virtual int? ProductionLT{ get; set; }
        public virtual int? ShipmentLT { get; set; }
    }
    public class RinksModelList : BaseModel
    {
        public List<RinksModel> _List { get; set; }

        public RinksModelList()
        {
            this._List = new List<RinksModel>();
        }
    }
}
