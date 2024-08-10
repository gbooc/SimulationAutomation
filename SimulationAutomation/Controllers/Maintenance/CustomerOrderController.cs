using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAutomation.Controllers.Maintenance
{
    public class CustomerOrderController
    {
        private EntitiesServices.EntitiesManager.Tables.CustomerOrder_SetupManager _customerOrder = new EntitiesServices.EntitiesManager.Tables.CustomerOrder_SetupManager();


        #region Customer Order transaction

        public Models.Maintenance.CustomerOrderList GetCustomerOrder(string MonthUpload)
        {
            Models.Maintenance.CustomerOrderList result = new Models.Maintenance.CustomerOrderList();

            try
            {
                result._List = new EntitiesServices.EntitiesManager
                                                                .StoredProcedures
                                                                .sp_Get_Customer_Order()
                                                                .SP_Get_CUSTOMERORDER(MonthUpload)
                                                                .Select(x => new Models.Maintenance.CustomerOrderModel
                                                                {
                                                                    customer_order_id = x.customer_order_id,
                                                                    rins_po_no = x.rins_po_no,
                                                                    po_qty = x.po_qty,
                                                                    etd = x.etd,
                                                                    eta_fukuoka = x.eta_destination,
                                                                    eta_customer = x.eta_customer,
                                                                    date_uploaded = x.date_uploaded.ToString("yyyyy-MM-dd"),
                                                                    version = x.version,
                                                                    destination = x.destination,
                                                                    CustomerDestination = x.customer_destination,
                                                                    month_uploaded_into = x.month_uploaded_into,
                                                                    rinks_no = x.model_name,
                                                                    remarks = x.remarks,
                                                                    TAT = x.tat,

                                                                    MFSODP_PO = x.mPO,
                                                                    MFSODP_QTY = Convert.ToInt32(x.mQTY),
                                                                    MFSODP_ETD = x.mETD.ToString()
                                                                }).ToList();

            }
            catch (Exception ex)
            {
                result.Error = ex.Message;
            }

            return result;
        }

        public List<Models.Maintenance.CustomerOrderModel> AllVersion()
        {
            List<Models.Maintenance.CustomerOrderModel> versions = new EntitiesServices.EntitiesManager
                                                                 .Views
                                                                 .view_CustomerOrderManager()
                                                                 .view_customer_order()
                                                                 .Select(x => new Models.Maintenance.CustomerOrderModel
                                                                 {
                                                                     version = x.version
                                                                 })
                                                                 .OrderByDescending(x => x.version)
                                                                 .ToList();
            return versions;
        }

        public List<int> GetAllVersions(string monthUploadedInto, string destination)
        {
            List<int> result = new List<int>();

            try
            {
                result = new EntitiesServices.EntitiesManager
                                                             .Views
                                                             .view_CustomerOrderManager()
                                                             .view_customer_order()
                                                             .Where(x => x.month_uploaded_into == monthUploadedInto
                                                                && x.destination == destination)
                                                             .Select(x => x.version)
                                                             .ToList();
            }
            catch (Exception ex)
            {

            }
            return result;
        }
        public Models.Maintenance.CustomerOrderModel GetLatestUpload()
        {
            Models.Maintenance.CustomerOrderModel Result = new Models.Maintenance.CustomerOrderModel();

            try
            {
                Result = new EntitiesServices.EntitiesManager
                                                             .Views
                                                             .view_CustomerOrderManager()
                                                             .view_customer_order()
                                                             .Select(x => new Models.Maintenance.CustomerOrderModel
                                                             {
                                                                 date_uploaded = x.date_uploaded.ToString("yyyyy-MM-dd"),
                                                                 destination = x.destination
                                                             })
                                                             .OrderByDescending(x => x.date_uploaded)
                                                             .FirstOrDefault();
            }
            catch (Exception ex)
            {

            }
            return Result;
        }
        public List<Models.Maintenance.CustomerOrderModel> GetAllUploadedPO()
        {
            List<Models.Maintenance.CustomerOrderModel> Result = new List<Models.Maintenance.CustomerOrderModel>();

            try
            {
                Result = new EntitiesServices.EntitiesManager
                                                             .StoredProcedures
                                                             .sp_Get_Summary_PO_Uploaded()
                                                             .SP_Get_CustomerOrder_Summary()
                                                             .Select(x => new Models.Maintenance.CustomerOrderModel
                                                             {
                                                                 month_uploaded_into = x.month_uploaded_into,
                                                                 date_uploaded = x.date_uploaded.ToString("yyyyy-MM-dd"),
                                                                 ModelCount = x.numofuploaded
                                                             })
                                                             .OrderByDescending(x => x.month_uploaded_into)
                                                             .ToList();
            }
            catch (Exception ex)
            {

            }
            return Result;
        }

        public DataTable GetMGPLNPvsPO(int From, int To)
        {
            try
            {
                var test =  new EntitiesServices.EntitiesManager.StoredProcedures.sp_Compute_MGPLNPvsPOManager().sp_Compute_MGPLNPvsPO(From,To);
                return test;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }



        public bool IsExist(string ModelName, string PONumber, int QTY, DateTime ETD)
        {
            var Result = new EntitiesServices.EntitiesManager
                                             .Tables.CustomerOrder_SetupManager()
                                             .tbl_customer_order()
                                             .Where(x => x.model_name.Trim() == ModelName &&
                                                         x.rins_po_no == PONumber &&
                                                         x.po_qty == QTY &&
                                                         x.etd == ETD)
                                            .FirstOrDefault();

            return Result == null ? false : true;

        }

        #region Delete | Update | Insert

        public Models.Maintenance.CustomerOrderModel InsertCustomerOrder(Models.Maintenance.CustomerOrderModel customerOrder)
        {
            Models.Maintenance.CustomerOrderModel result = new Models.Maintenance.CustomerOrderModel();

            result = _customerOrder.SaveCustomerOrder(customerOrder);

            return result;
        }

        public void DeleteCustomerOrder(int CustomerID)
        {
            _customerOrder.DeleteCustomerOrder(CustomerID);
        }

        #endregion

        #endregion

        #region PO Upload

        public Models.Maintenance.POFormatRows POFormationDetails(int FormatID)
        {
            Models.Maintenance.POFormatRows result = new Models.Maintenance.POFormatRows();

            try
            {
                result = new EntitiesServices.EntitiesManager
                                                                .Tables
                                                                .ImportFormatPositions()
                                                                .tbl_format_position()
                                                                .Where(x => x.format_id == FormatID)
                                                                .Select(x => new Models.Maintenance.POFormatRows
                                                                {
                                                                    FormatID = x.format_id,
                                                                    ModelName = x.model_name,
                                                                    PONumber = x.po_number,
                                                                    QTY = x.qty,
                                                                    ETD = x.etd
                                                                }).FirstOrDefault();

            }
            catch (Exception ex)
            {
                result.Error = ex.Message;
            }

            return result;
        }

        public List<Models.Maintenance.POImportFormat> POFormat()
        {
            return new EntitiesServices.EntitiesManager
                                                        .Tables
                                                        .ImportFormat()
                                                        .tbl_PO_import_format()
                                                        .Select(x => new Models.Maintenance.POImportFormat
                                                        {
                                                            FormatID = x.format_id,
                                                            Country = x.country,
                                                            CustomerName = x.customer_name,
                                                            ModelName = x.model_name,
                                                            Destination = x.destination
                                                        }).ToList();
                                                        
        }

        #endregion
    }
}
