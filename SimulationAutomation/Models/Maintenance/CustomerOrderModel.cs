using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAutomation.Models.Maintenance
{
    public class CustomerOrderModel : LogModel
    {
        public virtual int customer_order_id { get; set; }
        public int model_id { get; set; }
        public string rins_po_no { get; set; }
        public decimal po_qty { get; set; }
        public DateTime etd { get; set; }
        public DateTime? eta_fukuoka { get; set; }
        public DateTime? eta_customer { get; set; }
        public string date_uploaded { get; set; }
        public int version { get; set; }
        public string destination { get; set; }
        public string month_uploaded_into { get; set; }
        public string rinks_no { get; set; }
        public string remarks { get; set; }
        public string isFc { get; set; }
        public string TAT { get; set; }
        public string CustomerDestination { get; set; }
        public int? ModelCount { get; set; }
        public string Suffix { get; set; }
        public string ETDMMYY { get; set; }
        //Validation model
        public string RinksNo { get; set; }
        public string MFSODP_Rinks { get; set; }
        public string MFSODP_PO { get; set; }
        public int MFSODP_QTY { get; set; }
        public string MFSODP_ETD { get; set; }

    }
    public class CustomerOrderList : BaseModel
    {
        public List<CustomerOrderModel> _List { get; set; }

        public CustomerOrderList()
        {
            this._List = new List<CustomerOrderModel>();
        }
    }
}
