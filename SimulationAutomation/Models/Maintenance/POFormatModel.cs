using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAutomation.Models.Maintenance
{
    public class POImportFormat : LogModel
    {
        public int FormatID { get; set; }
        public string CustomerName { get; set; }
        public string ModelName { get; set; }
        public string Country { get; set; }
        public bool IsActive { get; set; }
        public string Destination { get; set; }
    }

    public class POImportFormatList : BaseModel
    {
        public List<POImportFormat> _List { get; set; }

        public POImportFormatList()
        {
            this._List = new List<POImportFormat>();
        }
    }


    public class POFormatRows : LogModel
    {
        public int? FormatID { get; set; }
        public int? ModelName { get; set; }
        public int? PONumber { get; set; }
        public int? QTY { get; set; }
        public int? ETD { get; set; }
    }

    public class POFormatRowsList : BaseModel
    {
        public List<POFormatRows> _List { get; set; }

        public POFormatRowsList()
        {
            this._List = new List<POFormatRows>();
        }
    }

}
