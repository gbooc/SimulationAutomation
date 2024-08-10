using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAutomation.EntitiesServices.EntitiesManager.Tables
{
    public class ImportFormat
    {
        public ImportFormat()
        {
            this._dbContext = new DB.dbRT1_SADataContext();
        }

        private readonly DB.dbRT1_SADataContext _dbContext;

        public List<DB.tbl_PO_import_format> tbl_PO_import_format()
        {
            try
            {
                var data = this._dbContext.tbl_PO_import_formats.ToList();
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public DB.tbl_PO_import_format FindById(int modelId)
        {
            try
            {
                return this.tbl_PO_import_format()
                           .Where(x => x.format_id == modelId)
                           .FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Models.Maintenance.POImportFormat SavePOFormat(Models.Maintenance.POImportFormat model)
        {
            Models.Maintenance.POImportFormat result = new Models.Maintenance.POImportFormat();

            try
            {
                DB.tbl_PO_import_format Tbl_PO_import_format = new DB.tbl_PO_import_format();

                Tbl_PO_import_format.customer_name = model.CustomerName;
                Tbl_PO_import_format.model_name = model.ModelName;
                Tbl_PO_import_format.country = model.Country;
                Tbl_PO_import_format.is_active = model.IsActive;

                this._dbContext.tbl_PO_import_formats.InsertOnSubmit(Tbl_PO_import_format);
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


        public void DeletePOImportFormat(int modelId)
        {
            try
            {
                DB.tbl_PO_import_format model = this.FindById(modelId);
                this._dbContext.tbl_PO_import_formats.DeleteOnSubmit(model);
                this._dbContext.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdatePOImportFormat(Models.Maintenance.POImportFormat model)
        {
            try
            {
                DB.tbl_PO_import_format Tbl_PO_import_format = this.FindById(model.FormatID);

                Tbl_PO_import_format.customer_name = model.CustomerName;
                Tbl_PO_import_format.model_name = model.ModelName;
                Tbl_PO_import_format.country = model.Country;
                Tbl_PO_import_format.is_active = model.IsActive;

                this._dbContext.SubmitChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
