using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAutomation.Models.Maintenance
{
    public class RinksItemNo
    {
        public string CGITCH { get; set; }
    }
    public class RinksItemNoList : BaseModel
    {
        public List<RinksItemNo> _List { get; set; }

        public RinksItemNoList()
        {
            this._List = new List<RinksItemNo>();
        }
    }
}
