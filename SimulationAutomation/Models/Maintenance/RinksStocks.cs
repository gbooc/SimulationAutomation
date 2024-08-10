using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAutomation.Models.Maintenance
{
    public class RinksStocks : LogModel
    {
        public string itemno { get; set; }
        public decimal stocks { get; set; }
    }

    public class RT1Simulation
    {
        public string date { get; set; }
        public string itemno { get; set; }
        public string inputquantity { get; set; }
    }

    public class ParentItem
    {
        public string item { get; set; }
        public string quantity { get; set; }
        public string suffix { get; set; }
        public string subparent { get; set; }
    }

    public class RinksstocksList : BaseModel
    {
        public List<RinksStocks> _List { get; set; }
        public RinksstocksList()
        {
            this._List = new List<RinksStocks>();
        }
    }

    public class rt1SimulationList : BaseModel
    {
        public List<RT1Simulation> _List { get; set; }
        public rt1SimulationList()
        {
            this._List = new List<RT1Simulation>();
        }
    }

    public class ParentItemList : BaseModel
    {
        public List<ParentItem> _List { get; set; }
        public ParentItemList()
        {
            this._List = new List<ParentItem>();
        }
    }
}
