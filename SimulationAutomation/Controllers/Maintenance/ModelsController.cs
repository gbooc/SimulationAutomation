using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAutomation.Controllers.Maintenance
{
    public class ModelsController
    {
        private EntitiesServices.EntitiesManager.Tables.ModelManager _modelSetup = new EntitiesServices.EntitiesManager.Tables.ModelManager();

        public Models.Maintenance.RinksModelList GetAllModels()
        {
            Models.Maintenance.RinksModelList result = new Models.Maintenance.RinksModelList();

            try
            {
                result._List = new EntitiesServices.EntitiesManager
                                                                   .Tables
                                                                   .ModelManager()
                                                                   .tbl_Model()
                                                                   .Select(x => new Models.Maintenance.RinksModel
                                                                   {
                                                                       ModelID = x.model_id,
                                                                       //  Destination = x.destination,
                                                                       //   ELT = x.elt,
                                                                       RinksNo = x.rinks_no,
                                                                       TAT = x.tat,
                                                                       ProductionLT = x.Production_LT,
                                                                       ShipmentLT = x.Shipment_LT
                                                                   }).ToList();
            }
            catch (Exception ex)
            {
                result.Error = ex.Message;
            }

            return result;
        }

        public Models.Maintenance.RinksModelList CheckUploadedModel()
        {
            Models.Maintenance.RinksModelList result = new Models.Maintenance.RinksModelList();

            try
            {
                result._List = new EntitiesServices.EntitiesManager
                                                                   .StoredProcedures
                                                                   .sp_Get_MFSODP()
                                                                   .SP_Get_MFSODP()
                                                                   .Select(x => new Models.Maintenance.RinksModel
                                                                   {
                                                                       RinksNo = x.FAIT,
                                                                       PONumber = x.FANOOC,
                                                                       Qty = Convert.ToInt32(x.FAQROC) == 0 ? x.FAQOCT : x.FAQROC,
                                                                       DateDelivery = x.FAYDLD,
                                                                       Suffix = x.FASD
                                                                   }).ToList();
            }
            catch (Exception ex)
            {
                result.Error = ex.Message;
            }

            return result;
        }


        public void DeleteModel(int modelId)
        {
            _modelSetup.DeleteModel(modelId);
        }

        public void AddModel(Models.Maintenance.RinksModel model)
        {
            _modelSetup.SaveModel(model);
        }

        public void UpdateModel(Models.Maintenance.RinksModel model)
        {
            _modelSetup.UpdateModel(model);
        }

        public void UpdateProductionLeadTime(Models.Maintenance.RinksModel model)
        {
            _modelSetup.UpdateProductionLeadTime(model);
        }
    }
}
