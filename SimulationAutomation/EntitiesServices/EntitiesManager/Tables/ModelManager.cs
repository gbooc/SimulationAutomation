using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAutomation.EntitiesServices.EntitiesManager.Tables
{
    public class ModelManager
    {
        public ModelManager()
        {
            this._dbContext = new DB.dbRT1_SADataContext();
        }

        private readonly DB.dbRT1_SADataContext _dbContext;

        public List<DB.model> tbl_Model()
        {
            try
            {
                var data = this._dbContext.models.ToList();
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DB.model FindById(int modelId)
        {
            try
            {
                return this.tbl_Model()
                           .Where(x => x.model_id == modelId)
                           .FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Models.Maintenance.RinksModel SaveModel(Models.Maintenance.RinksModel model)
        {
            Models.Maintenance.RinksModel result = new Models.Maintenance.RinksModel();

            try
            {
                DB.model tbl_Model = new DB.model();

               //Models
                tbl_Model.rinks_no = model.RinksNo;
                tbl_Model.tat = model.TAT;
                //tbl_Model.destination = model.Destination;
                //tbl_Model.elt = model.ELT;
                //tbl_Model.Customer_distination = model.CustomerName;
                //tbl_Model.customer_name = "";
                //Logs

                this._dbContext.models.InsertOnSubmit(tbl_Model);
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

        public void DeleteModel(int modelId)
        {
            try
            {
                DB.model model = this.FindById(modelId);
                this._dbContext.models.DeleteOnSubmit(model);
                this._dbContext.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateModel(Models.Maintenance.RinksModel model)
        {
            try
            {
                DB.model tbl_capacity_setup = this.FindById(model.ModelID);
                tbl_capacity_setup.rinks_no = model.RinksNo;
                tbl_capacity_setup.tat = model.TAT;
                this._dbContext.SubmitChanges();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateProductionLeadTime(Models.Maintenance.RinksModel model)
        {
            try
            {
                DB.model tbl_capacity_setup = this.FindById(model.ModelID);
                tbl_capacity_setup.Production_LT = model.ProductionLT;
                this._dbContext.SubmitChanges();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    } 
}
