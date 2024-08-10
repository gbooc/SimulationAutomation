using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAutomation.Models.Maintenance
{
    public class ShippingLeadTimeModel : LogModel
    {
        public virtual int shipping_leadtime_Id { get; set; }
        // Air
        public virtual int packing_hkg_air { get; set; }
        public virtual int packing_shan_air { get; set; }
        public virtual int packing_jp_air { get; set; }

        public virtual int pickup_hkg_air { get; set; }
        public virtual int pickup_shan_air { get; set; }
        public virtual int pickup_jp_air { get; set; }

        public virtual int cargo_hkg_air { get; set; }
        public virtual int cargo_shan_air { get; set; }
        public virtual int cargo_jp_air { get; set; }

        public virtual int leadtime_hkg_air { get; set; }
        public virtual int leadtime_shan_air { get; set; }
        public virtual int leadtime_jp_air { get; set; }

        public virtual int etd_hkg_air { get; set; }
        public virtual int etd_shan_air { get; set; }
        public virtual int etd_jp_air { get; set; }

        // Sea
        public virtual int packing_hkg_sea { get; set; }
        public virtual int packing_shan_sea { get; set; }
        public virtual int packing_jp_sea { get; set; }

        public virtual int confirmation_hkg_sea { get; set; }
        public virtual int confirmation_shan_sea { get; set; }
        public virtual int confirmation_jp_sea { get; set; }

        public virtual int pickup_hkg_sea { get; set; }
        public virtual int pickup_shan_sea { get; set; }
        public virtual int pickup_jp_sea { get; set; }

        public virtual int cutoff_hkg_sea { get; set; }
        public virtual int cutoff_shan_sea { get; set; }
        public virtual int cutoff_jp_sea { get; set; }

        public virtual int cargo_hkg_sea { get; set; }
        public virtual int cargo_shan_sea { get; set; }
        public virtual int cargo_jp_sea { get; set; }

        public virtual int leadtime_hkg_sea { get; set; }
        public virtual int leadtime_shan_sea { get; set; }
        public virtual int leadtime_jp_sea { get; set; }

        public virtual int etd_hkg_sea { get; set; }
        public virtual int etd_shan_sea { get; set; }
        public virtual int etd_jp_sea { get; set; }
    }

    public class ShippingLeadTimeModelList : BaseModel
    {
        public List<ShippingLeadTimeModel> _List { get; set; }

        public ShippingLeadTimeModelList()
        {
            this._List = new List<ShippingLeadTimeModel>();
        }
    }
}