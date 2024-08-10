using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAutomation.Controllers.Maintenance
{
    public class ShippingLeadTimeController
    {
        private EntitiesServices.EntitiesManager.Tables.ShippingLeadTime_SetupManager _shippingleadtimeSetup = new EntitiesServices.EntitiesManager.Tables.ShippingLeadTime_SetupManager();

        public Models.Maintenance.ShippingLeadTimeModel GetShippingLeadTime()
        {
            Models.Maintenance.ShippingLeadTimeModel result = new Models.Maintenance.ShippingLeadTimeModel();

            try
            {
                result = new EntitiesServices.EntitiesManager
                                                                 .Tables
                                                                 .ShippingLeadTime_SetupManager()
                                                                 .tbl_shipping_leadtime()
                                                                 .Select(x => new Models.Maintenance.ShippingLeadTimeModel
                                                                 {
                                                                     packing_hkg_air = x.packing_hkg_air,
                                                                     packing_shan_air = x.packing_shan_air,
                                                                     packing_jp_air = x.packing_jp_air,

                                                                     pickup_hkg_air = x.pickup_hkg_air,
                                                                     pickup_shan_air = x.pickup_shan_air,
                                                                     pickup_jp_air = x.pickup_jp_air,

                                                                     cargo_hkg_air = x.cargo_hkg_air,
                                                                     cargo_shan_air = x.cargo_shan_air,
                                                                     cargo_jp_air = x.cargo_jp_air,


                                                                     leadtime_hkg_air = x.leadtime_hkg_air,
                                                                     leadtime_shan_air = x.leadtime_shan_air,
                                                                     leadtime_jp_air = x.leadtime_jp_air,

                                                                     etd_hkg_air = x.etd_hkg_air,
                                                                     etd_shan_air = x.etd_shan_air,
                                                                     etd_jp_air = x.etd_jp_air,

                                                                     // Sea
                                                                     packing_hkg_sea = x.packing_hkg_sea,
                                                                     packing_shan_sea = x.packing_shan_sea,
                                                                     packing_jp_sea = x.packing_jp_sea,

                                                                     confirmation_hkg_sea = x.confirmation_hkg_sea,
                                                                     confirmation_shan_sea = x.confirmation_shan_sea,
                                                                     confirmation_jp_sea = x.confirmation_jp_sea,

                                                                     pickup_hkg_sea = x.pickup_hkg_sea,
                                                                     pickup_shan_sea = x.pickup_shan_sea,
                                                                     pickup_jp_sea = x.pickup_jp_sea,

                                                                     cutoff_hkg_sea = x.cutoff_hkg_sea,
                                                                     cutoff_shan_sea = x.cutoff_shan_sea,
                                                                     cutoff_jp_sea = x.cutoff_jp_sea,

                                                                     cargo_hkg_sea = x.cargo_hkg_sea,
                                                                     cargo_shan_sea = x.cargo_shan_sea,
                                                                     cargo_jp_sea = x.cargo_jp_sea,

                                                                     leadtime_hkg_sea = x.leadtime_hkg_sea,
                                                                     leadtime_shan_sea = x.leadtime_shan_sea,
                                                                     leadtime_jp_sea = x.leadtime_jp_sea,

                                                                     etd_hkg_sea = x.etd_hkg_sea,
                                                                     etd_shan_sea = x.etd_shan_sea,
                                                                     etd_jp_sea = x.etd_jp_sea
                                                                 }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                result.Error = ex.Message;
            }
            return result;
        }

        public void DeleteShippingLeadtime(int id)
        {
            _shippingleadtimeSetup.DeleteShippingLeadTime(id);
        }

        public void InsertLeadtime(Models.Maintenance.ShippingLeadTimeModel leadtime)
        {
            _shippingleadtimeSetup.SaveCapacitySetup(leadtime);
        }

        public void UpdateShippingLeadtime(Models.Maintenance.ShippingLeadTimeModel leadtime)
        {
            _shippingleadtimeSetup.UpdateShippineLeadTime(leadtime);
        }

    }
}
