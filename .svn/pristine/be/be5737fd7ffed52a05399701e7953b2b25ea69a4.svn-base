using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAutomation.EntitiesServices.EntitiesManager.Tables
{
    public class CustomerOrder_SetupManager
    {
        public CustomerOrder_SetupManager()
        {
            this._dbContext = new DB.dbRT1_SADataContext();
        }

        private readonly DB.dbRT1_SADataContext _dbContext;

        public List<DB.customer_order> tbl_customer_order()
        {
            try
            {
                var data = this._dbContext.customer_orders.ToList();
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DB.customer_order FindById(int customerId)
        {
            try
            {
                return this.tbl_customer_order()
                           .Where(x => x.customer_order_id == customerId)
                           .FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Models.Maintenance.CustomerOrderModel SaveCustomerOrder(Models.Maintenance.CustomerOrderModel customerOrder)
        {
            Models.Maintenance.CustomerOrderModel result = new Models.Maintenance.CustomerOrderModel();

            try
            {
                DB.customer_order tbl_customer = new DB.customer_order();

                //customer order
                tbl_customer.date_uploaded = Convert.ToDateTime(customerOrder.date_uploaded);
                tbl_customer.destination   = customerOrder.destination;
                tbl_customer.destination_details = customerOrder.CustomerDestination;
                tbl_customer.eta_customer  = customerOrder.eta_customer;
                tbl_customer.eta_destination   = customerOrder.eta_fukuoka;
                tbl_customer.etd           = customerOrder.etd;
                tbl_customer.month_uploaded_into = customerOrder.month_uploaded_into;
                tbl_customer.po_qty        = customerOrder.po_qty;
                tbl_customer.rins_po_no    = customerOrder.rins_po_no;
                tbl_customer.version       = customerOrder.version;
                tbl_customer.model_name    = customerOrder.rinks_no;
                tbl_customer.remarks       = customerOrder.remarks;
                tbl_customer.mfosdp_po_no = customerOrder.MFSODP_PO;
                tbl_customer.mfsodp_etd = customerOrder.MFSODP_ETD;
                tbl_customer.mfosdp_qty = customerOrder.MFSODP_QTY;
                tbl_customer.suffix = customerOrder.Suffix;

                //Logs
                tbl_customer.Action = "Save Uploaded PO";
                tbl_customer.DateCreated = DateTime.Now;
                tbl_customer.UserLog = System.Environment.UserName;

                this._dbContext.customer_orders.InsertOnSubmit(tbl_customer);
                this._dbContext.SubmitChanges();

            }
            catch (SystemException ex)
            {
                result.Error = "Duplicates entry";
            }
            catch(Exception ex)
            {
                result.Error = ex.ToString(); 
            }

            return result;
        }

        public void DeleteCustomerOrder(int CustomerOrderID)
        {
            try
            {
                DB.customer_order customer_order = this.FindById(CustomerOrderID);
                this._dbContext.customer_orders.DeleteOnSubmit(customer_order);
                this._dbContext.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
