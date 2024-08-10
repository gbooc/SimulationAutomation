using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAutomation.EntitiesServices.EntitiesManager.Tables
{
    public class ImportFormatPositions
    {
        public ImportFormatPositions()
        {
            this._dbContext = new DB.dbRT1_SADataContext();
        }

        private readonly DB.dbRT1_SADataContext _dbContext;

        public List<DB.tbl_format_position> tbl_format_position()
        {
            try
            {
                var data = this._dbContext.tbl_format_positions.ToList();
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public DB.tbl_format_position FindById(int modelId)
        {
            try
            {
                return this.tbl_format_position()
                           .Where(x => x.format_id == modelId)
                           .FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Models.Maintenance.POFormatRows SavePOFormatDetails(Models.Maintenance.POFormatRows model)
        {
            Models.Maintenance.POFormatRows result = new Models.Maintenance.POFormatRows();

            try
            {
                DB.tbl_format_position Tbl_format_position = new DB.tbl_format_position();

                Tbl_format_position.format_id = model.FormatID;
                Tbl_format_position.model_name = model.ModelName;
                Tbl_format_position.po_number = model.PONumber;
                Tbl_format_position.qty = model.QTY;
                Tbl_format_position.etd = model.ETD;

                this._dbContext.tbl_format_positions.InsertOnSubmit(Tbl_format_position);
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


        public void DeletePOFormatDetails(int modelId)
        {
            try
            {
                DB.tbl_format_position model = this.FindById(modelId);
                this._dbContext.tbl_format_positions.DeleteOnSubmit(model);
                this._dbContext.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdatePOFormatDetails(Models.Maintenance.POFormatRows model)
        {
            try
            {
                DB.tbl_format_position Tbl_format_position = new DB.tbl_format_position();

                Tbl_format_position.format_id = model.FormatID;
                Tbl_format_position.model_name = model.ModelName;
                Tbl_format_position.po_number = model.PONumber;
                Tbl_format_position.qty = model.QTY;
                Tbl_format_position.etd = model.ETD;

                this._dbContext.SubmitChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
