using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAutomation.EntitiesServices.EntitiesManager.Tables
{
    public class CapacityManager
    {
        public CapacityManager()
        {
            this._dbContext = new DB.dbRT1_SADataContext();
        }

        private readonly DB.dbRT1_SADataContext _dbContext;

        public List<DB.Capacity> Capacity()
        {
            try
            {
                var data = this._dbContext.Capacities.ToList();
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DB.Capacity FindById(int iNDEX)
        {
            try
            {
                return this.Capacity()
                           .Where(x => x.INDEX == iNDEX)
                           .FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void SaveCapacity(DB.Capacity capacity)
        {
            try
            {
                this._dbContext.Capacities.InsertOnSubmit(capacity);
                this._dbContext.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateCapacity(DB.Capacity capacity)
        {
            try
            {
                var updateCapacity = this.Capacity()
                                         .Where(x => x.CODE.Equals(capacity.CODE)
                                                  && x.WorkScheme.Equals(capacity.WorkScheme)
                                                  && x.Model.Equals(capacity.Model)
                                                  && x.Line.Equals(capacity.Line))
                                         .FirstOrDefault();

                updateCapacity.Capacity1 = capacity.Capacity1;
                updateCapacity.Status = capacity.Status;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        //public Models.Maintenance.RinksModel SaveModel(Models.Maintenance.RinksModel model)
        //{
        //    Models.Maintenance.RinksModel result = new Models.Maintenance.RinksModel();

        //    try
        //    {
        //        DB.model tbl_Model = new DB.model();

        //       //Models
        //        tbl_Model.rinks_no = model.RinksNo;
        //        tbl_Model.tat = model.TAT;
        //        tbl_Model.destination = model.Destination;
        //        tbl_Model.elt = model.ELT;
        //        tbl_Model.Customer_distination = model.CustomerName;
        //        tbl_Model.customer_name = "";
        //        //Logs

        //        this._dbContext.models.InsertOnSubmit(tbl_Model);
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

        public void DeleteModel(int iNDEX)
        {
            try
            {
                DB.Capacity capacity = this.FindById(iNDEX);
                this._dbContext.Capacities.DeleteOnSubmit(capacity);
                this._dbContext.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //public void UpdateModel(Models.Maintenance.RinksModel model)
        //{
        //    try
        //    {
        //        DB.model tbl_capacity_setup = this.FindById(model.ModelID);

        //        tbl_capacity_setup.destination = model.Destination;
        //        tbl_capacity_setup.elt = model.ELT;
        //        tbl_capacity_setup.rinks_no = model.RinksNo;
        //        tbl_capacity_setup.tat = model.TAT;

        //        this._dbContext.SubmitChanges();

        //    }
        //    catch
        //    {

        //    }
        //}
    }
}
