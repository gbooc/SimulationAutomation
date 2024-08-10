using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAutomation.EntitiesServices.EntitiesManager.Tables
{
    public class ShippingLeadTime_SetupManager
    {
        public ShippingLeadTime_SetupManager()
        {
            this._dbContext = new DB.dbRT1_SADataContext();
        }

        private readonly DB.dbRT1_SADataContext _dbContext;

        public List<DB.shipping_leadtime> tbl_shipping_leadtime()
        {
            try
            {
                var data = this._dbContext.shipping_leadtimes.ToList();
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DB.shipping_leadtime FindById(int leadtimeId)
        {
            try
            {
                return this.tbl_shipping_leadtime()
                           .Where(x => x.id == leadtimeId)
                           .FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Models.Maintenance.ShippingLeadTimeModel SaveCapacitySetup(Models.Maintenance.ShippingLeadTimeModel leadtime)
        {
            Models.Maintenance.ShippingLeadTimeModel result = new Models.Maintenance.ShippingLeadTimeModel();

            try
            {
                DB.shipping_leadtime tbl_shipping_leadtime = new DB.shipping_leadtime();

                //leadtime
                tbl_shipping_leadtime.packing_hkg_air = leadtime.packing_hkg_air;
                tbl_shipping_leadtime.packing_shan_air = leadtime.packing_shan_air;
                tbl_shipping_leadtime.packing_jp_air = leadtime.packing_jp_air;

                tbl_shipping_leadtime.pickup_hkg_air = leadtime.pickup_hkg_air;
                tbl_shipping_leadtime.pickup_shan_air = leadtime.pickup_shan_air;
                tbl_shipping_leadtime.pickup_jp_air = leadtime.pickup_jp_air;

                tbl_shipping_leadtime.cargo_hkg_air = leadtime.cargo_hkg_air;
                tbl_shipping_leadtime.cargo_shan_air = leadtime.cargo_shan_air;
                tbl_shipping_leadtime.cargo_jp_air = leadtime.cargo_jp_air;


                tbl_shipping_leadtime.leadtime_hkg_air = leadtime.leadtime_hkg_air;
                tbl_shipping_leadtime.leadtime_shan_air = leadtime.leadtime_shan_air;
                tbl_shipping_leadtime.leadtime_jp_air = leadtime.leadtime_jp_air;

                tbl_shipping_leadtime.etd_hkg_air = leadtime.etd_hkg_air;
                tbl_shipping_leadtime.etd_shan_air = leadtime.etd_shan_air;
                tbl_shipping_leadtime.etd_jp_air = leadtime.etd_jp_air;

                // Sea
                tbl_shipping_leadtime.packing_hkg_sea = leadtime.packing_hkg_sea;
                tbl_shipping_leadtime.packing_shan_sea = leadtime.packing_shan_sea;
                tbl_shipping_leadtime.packing_jp_sea = leadtime.packing_jp_sea;

                tbl_shipping_leadtime.confirmation_hkg_sea = leadtime.confirmation_hkg_sea;
                tbl_shipping_leadtime.confirmation_shan_sea = leadtime.confirmation_shan_sea;
                tbl_shipping_leadtime.confirmation_jp_sea = leadtime.confirmation_jp_sea;

                tbl_shipping_leadtime.pickup_hkg_sea = leadtime.pickup_hkg_sea;
                tbl_shipping_leadtime.pickup_shan_sea = leadtime.pickup_shan_sea;
                tbl_shipping_leadtime.pickup_jp_sea = leadtime.pickup_jp_sea;

                tbl_shipping_leadtime.cutoff_hkg_sea = leadtime.cutoff_hkg_sea;
                tbl_shipping_leadtime.cutoff_shan_sea = leadtime.cutoff_shan_sea;
                tbl_shipping_leadtime.cutoff_jp_sea = leadtime.cutoff_jp_sea;

                tbl_shipping_leadtime.cargo_hkg_sea = leadtime.cargo_hkg_sea;
                tbl_shipping_leadtime.cargo_shan_sea = leadtime.cargo_shan_sea;
                tbl_shipping_leadtime.cargo_jp_sea = leadtime.cargo_jp_sea;

                tbl_shipping_leadtime.leadtime_hkg_sea = leadtime.leadtime_hkg_sea;
                tbl_shipping_leadtime.leadtime_shan_sea = leadtime.leadtime_shan_sea;
                tbl_shipping_leadtime.leadtime_jp_sea = leadtime.leadtime_jp_sea;

                tbl_shipping_leadtime.etd_hkg_sea = leadtime.etd_hkg_sea;
                tbl_shipping_leadtime.etd_shan_sea = leadtime.etd_shan_sea;
                tbl_shipping_leadtime.etd_jp_sea = leadtime.etd_jp_sea;



                //Logs
                //tbl_capacity_setup.Action = capacity.Action;
                //tbl_capacity_setup.DateCreated = capacity.DateCreated;
                //tbl_capacity_setup.UserLog = capacity.UserLog;

                this._dbContext.shipping_leadtimes.InsertOnSubmit(tbl_shipping_leadtime);
                this._dbContext.SubmitChanges();

            }
            catch (SystemException ex)
            {
                result.Error = "Duplicates entry";
            }
            catch (Exception ex)
            {
                result.Error = ex.ToString();
            }

            return result;
        }

        public void DeleteShippingLeadTime(int id)
        {
            try
            {
                DB.shipping_leadtime shipping_leadtime = this.FindById(id);
                this._dbContext.shipping_leadtimes.DeleteOnSubmit(shipping_leadtime);
                this._dbContext.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void UpdateShippineLeadTime(Models.Maintenance.ShippingLeadTimeModel leadtime)
        {
            try
            {
                DB.shipping_leadtime tbl_shipping_leadtime = this.FindById(leadtime.shipping_leadtime_Id);

                //capacity setup
                //leadtime
                tbl_shipping_leadtime.packing_hkg_air = leadtime.packing_hkg_air;
                tbl_shipping_leadtime.packing_shan_air = leadtime.packing_shan_air;
                tbl_shipping_leadtime.packing_jp_air = leadtime.packing_jp_air;

                tbl_shipping_leadtime.pickup_hkg_air = leadtime.pickup_hkg_air;
                tbl_shipping_leadtime.pickup_shan_air = leadtime.pickup_shan_air;
                tbl_shipping_leadtime.pickup_jp_air = leadtime.pickup_jp_air;

                tbl_shipping_leadtime.cargo_hkg_air = leadtime.cargo_hkg_air;
                tbl_shipping_leadtime.cargo_shan_air = leadtime.cargo_shan_air;
                tbl_shipping_leadtime.cargo_jp_air = leadtime.cargo_jp_air;


                tbl_shipping_leadtime.leadtime_hkg_air = leadtime.leadtime_hkg_air;
                tbl_shipping_leadtime.leadtime_shan_air = leadtime.leadtime_shan_air;
                tbl_shipping_leadtime.leadtime_jp_air = leadtime.leadtime_jp_air;

                tbl_shipping_leadtime.etd_hkg_air = leadtime.etd_hkg_air;
                tbl_shipping_leadtime.etd_shan_air = leadtime.etd_shan_air;
                tbl_shipping_leadtime.etd_jp_air = leadtime.etd_jp_air;

                // Sea
                tbl_shipping_leadtime.packing_hkg_sea = leadtime.packing_hkg_sea;
                tbl_shipping_leadtime.packing_shan_sea = leadtime.packing_shan_sea;
                tbl_shipping_leadtime.packing_jp_sea = leadtime.packing_jp_sea;

                tbl_shipping_leadtime.confirmation_hkg_sea = leadtime.confirmation_hkg_sea;
                tbl_shipping_leadtime.confirmation_shan_sea = leadtime.confirmation_shan_sea;
                tbl_shipping_leadtime.confirmation_jp_sea = leadtime.confirmation_jp_sea;

                tbl_shipping_leadtime.pickup_hkg_sea = leadtime.pickup_hkg_sea;
                tbl_shipping_leadtime.pickup_shan_sea = leadtime.pickup_shan_sea;
                tbl_shipping_leadtime.pickup_jp_sea = leadtime.pickup_jp_sea;

                tbl_shipping_leadtime.cutoff_hkg_sea = leadtime.cutoff_hkg_sea;
                tbl_shipping_leadtime.cutoff_shan_sea = leadtime.cutoff_shan_sea;
                tbl_shipping_leadtime.cutoff_jp_sea = leadtime.cutoff_jp_sea;

                tbl_shipping_leadtime.cargo_hkg_sea = leadtime.cargo_hkg_sea;
                tbl_shipping_leadtime.cargo_shan_sea = leadtime.cargo_shan_sea;
                tbl_shipping_leadtime.cargo_jp_sea = leadtime.cargo_jp_sea;

                tbl_shipping_leadtime.leadtime_hkg_sea = leadtime.leadtime_hkg_sea;
                tbl_shipping_leadtime.leadtime_shan_sea = leadtime.leadtime_shan_sea;
                tbl_shipping_leadtime.leadtime_jp_sea = leadtime.leadtime_jp_sea;

                tbl_shipping_leadtime.etd_hkg_sea = leadtime.etd_hkg_sea;
                tbl_shipping_leadtime.etd_shan_sea = leadtime.etd_shan_sea;
                tbl_shipping_leadtime.etd_jp_sea = leadtime.etd_jp_sea;

                this._dbContext.SubmitChanges();

            }
            catch
            {

            }
        }

    }
}
