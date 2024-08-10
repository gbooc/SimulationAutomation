using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAutomation.EntitiesServices.EntitiesManager.Tables
{
    public class ModelLeadTime_SetupManager
    {
        public ModelLeadTime_SetupManager()
        {
         //   this._dbContext = new DB.dbRT1_SADataContext();
        }

        //private readonly DB.dbRT1_SADataContext _dbContext;

        //public List<DB.model_leadtime> tbl_model_leadtime()
        //{
        //    try
        //    {
        //        var data = this._dbContext.model_leadtimes.ToList();
        //        return data;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        //public DB.model_leadtime FindById(int leadtimeId)
        //{
        //    try
        //    {
        //        return this.tbl_model_leadtime()
        //                   .Where(x => x.lead_time_id == leadtimeId)
        //                   .FirstOrDefault();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        //public Models.Maintenance.ModelLeadtimeModel SaveModelLeadtime(Models.Maintenance.ModelLeadtimeModel leadtime)
        //{
        //    Models.Maintenance.ModelLeadtimeModel result = new Models.Maintenance.ModelLeadtimeModel();

        //    try
        //    {
        //        DB.model_leadtime tbl_model_leadtime = new DB.model_leadtime();

        //        //capacity setup
        //        tbl_model_leadtime.description = leadtime.description;
        //        tbl_model_leadtime.duration = leadtime.duration;
        //        tbl_model_leadtime.model_id = leadtime.model_id;
        //        tbl_model_leadtime.model_name = leadtime.model_name;
        //        tbl_model_leadtime.sequence = leadtime.sequence;

        //        //Logs
        //        //tbl_capacity_setup.Action = capacity.Action;
        //        //tbl_capacity_setup.DateCreated = capacity.DateCreated;
        //        //tbl_capacity_setup.UserLog = capacity.UserLog;

        //        this._dbContext.model_leadtimes.InsertOnSubmit(tbl_model_leadtime);
        //        this._dbContext.SubmitChanges();

        //    }
        //    catch (SystemException ex)
        //    {
        //        result.Error = "Duplicates entry";
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Error = ex.ToString();
        //    }

        //    return result;
        //}

        //public void DeleteModelLeadtime(int leadtime)
        //{
        //    try
        //    {
        //        DB.model_leadtime leadtime_setup = this.FindById(leadtime);
        //        this._dbContext.model_leadtimes.DeleteOnSubmit(leadtime_setup);
        //        this._dbContext.SubmitChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        //public void UpdateModelLeadtime(Models.Maintenance.ModelLeadtimeModel leadtime)
        //{
        //    try
        //    {
        //        DB.model_leadtime tbl_model_leadtime = this.FindById(leadtime.leadtime_id);

        //        tbl_model_leadtime.description = leadtime.description;
        //        tbl_model_leadtime.duration = leadtime.duration;
        //        tbl_model_leadtime.model_id = leadtime.model_id;
        //        tbl_model_leadtime.model_name = leadtime.model_name;
        //        tbl_model_leadtime.sequence = leadtime.sequence;

        //        this._dbContext.SubmitChanges();

        //    }
        //    catch
        //    {

        //    }
        //}

    }
}
