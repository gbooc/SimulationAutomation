using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAutomation.Models.Reports
{
    public class DeliveryDate : BaseModel
    {
        public string factorycode { get; set; }
        public string itemnumber { get; set; }
        public string date { get; set; }
        public int quantity { get; set; }
    }

    public class DeliveryDateList : LogModel
    {
        public List<DeliveryDate> _List { get; set; }
        public DeliveryDateList()
        {
            this._List = new List<DeliveryDate>();
        }
    }
}
