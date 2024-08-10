                       using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SimulationAutomation.Views.Maintenance
{
    public partial class frmMGLNPComparison : Form
    {
        public frmMGLNPComparison()
        {
            InitializeComponent();

            this.dtpFrom.Format = DateTimePickerFormat.Custom;
            this.dtpFrom.CustomFormat = "MMMM yyyy";
            this.dtpFrom.ShowUpDown = true;

            this.dtpTo.Format = DateTimePickerFormat.Custom;
            this.dtpTo.CustomFormat = "MMMM yyyy";
            this.dtpTo.ShowUpDown = true;

            this._customerOrderList = new Models.Maintenance.CustomerOrderList();
            this._customerOrderModel = new Models.Maintenance.CustomerOrderModel();
            this._customerOrderController = new Controllers.Maintenance.CustomerOrderController();
            this._listComparison = new List<DataGridViewRow>();
        }

        private Models.Maintenance.CustomerOrderList _customerOrderList;
        private Models.Maintenance.CustomerOrderModel _customerOrderModel;
        private Controllers.Maintenance.CustomerOrderController _customerOrderController;
        private List<DataGridViewRow> _listComparison;
        private DataTable _datatable;

        private void frmMGLNPComparison_Load(object sender, EventArgs e)
        {
        }
        private void btnComparison_Click(object sender, EventArgs e)
        {
            int From = Convert.ToInt32(this.dtpFrom.Value.ToString("yyyyMM"));
            int To = Convert.ToInt32(this.dtpTo.Value.ToString("yyyyMM"));

             _datatable = _customerOrderController.GetMGPLNPvsPO(From,To);
            dgvMGLNP_RINKS.DataSource = _datatable;

            dgvMGLNP_RINKS.Columns["model"].Frozen = true;
            dgvMGLNP_RINKS.Columns["suffix"].Frozen = true;
        }
        private void dgvMGLNP_RINKS_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var ColumnCount = dgvMGLNP_RINKS.ColumnCount;

            for (int i = 0; i < dgvMGLNP_RINKS.Rows.Count - 1; i++)
            {
                for (int col = 2; col < (ColumnCount - 2); col++)
                {
                    if (!String.IsNullOrEmpty(dgvMGLNP_RINKS.Rows[i].Cells[col].Value.ToString()))
                    {

                        var Qty = Convert.ToInt32(dgvMGLNP_RINKS.Rows[i].Cells[col].Value.ToString());
                        if (Qty < 0)
                            dgvMGLNP_RINKS.Rows[i].Cells[col].Style.ForeColor = Color.Red;
                    }
                }
            }


            //foreach (DataGridViewRow rows in dgvMGLNP_RINKS.Rows)
            //{
            //    try
            //    {

            //        int Qty;
            //        string Value = rows.Cells[col].Value.ToString();
            //        bool IsNumeric = int.TryParse(Value, out Qty);

            //        if (IsNumeric && Qty < 0)
            //            rows.Cells[col].Style.ForeColor = Color.Red;
            //    }
            //    catch
            //    {

            //    }
            //    col++;

            //}
          
        }
    }
}
