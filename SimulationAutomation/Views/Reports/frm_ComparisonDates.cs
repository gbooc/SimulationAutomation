using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimulationAutomation.Views.Reports
{
    public partial class frm_ComparisonDates : Form
    {
        public frm_ComparisonDates()
        {
            InitializeComponent();
            this._customerOrderList = new Models.Maintenance.CustomerOrderList();
            this._demandController = new Controllers.Reports.POMonthlyUploadedController();
        }

        private Models.Maintenance.CustomerOrderList _customerOrderList;
        private Controllers.Reports.POMonthlyUploadedController _demandController;


        private int _countSelection = 0;
        List<int> SelectedDates = new List<int>();
        private DataTable _datatable;

        private void frm_ComparisonDates_Load(object sender, EventArgs e)
        {
            this.dtpMonthUploadedInto.Format = DateTimePickerFormat.Custom;
            this.dtpMonthUploadedInto.CustomFormat = "MMMM yyyy";
            this.dtpMonthUploadedInto.ShowUpDown = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.dgvComparisonDate.RowCount > 1)
                this.dgvComparisonDate.Rows.Clear();


            var list = new Controllers.Maintenance.CustomerOrderController()
                                                                          .GetAllUploadedPO()
                                                                          .Where(x => x.month_uploaded_into.ToUpper().Trim().Equals(this.dtpMonthUploadedInto.Text.ToUpper().Trim()))
                                                                          .ToList();
            foreach (var item in list)
            {
                this.dgvComparisonDate.Rows.Add(
                    Convert.ToDateTime(item.date_uploaded).ToString("yyyy-MM-dd"),
                    item.ModelCount
                    );
            }
            DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
            checkColumn.Name = "colSelected";
            checkColumn.HeaderText = "Select";
            checkColumn.Width = 50;
            checkColumn.ReadOnly = false;
            checkColumn.FillWeight = 10;
            dgvComparisonDate.Columns.Add(checkColumn);
        }

        private void dgvComparisonDate_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.RowIndex >= 0)
                this.dgvComparisonDate.CommitEdit(DataGridViewDataErrorContexts.Commit);

            //Check the value of cell
            if ((bool)this.dgvComparisonDate.CurrentCell.Value == true)
            {
                SelectedDates.Add(e.RowIndex);
                _countSelection++;
            }
            else
            {
                SelectedDates.Remove(e.RowIndex);
                _countSelection--;
            }

            if (_countSelection == 2)
            {
                DialogResult result = Util.MessageUtil.Confirm("Generate Report Now?", "Ok To Generate",
                                                      defaultButton: MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    int counter = 1;
                    string Param1 = "";
                    string Param2 = "";


                    foreach (var item in SelectedDates)
                    {
                        DataTable datable = new DataTable();

                        string Uploaded = this.dgvComparisonDate.Rows[item].Cells[0].Value.ToString();

                        datable = this._demandController.GetComparisonDemand(Uploaded);

                        if (_datatable == null)
                        {
                            Param1 = Uploaded;
                            _datatable = datable;

                            int position = _datatable.Columns.Count - 1;
                            _datatable.Columns["TTL"].SetOrdinal(position); 
                        }
                        else
                        {
                            Param2 = Uploaded;
                            _datatable.Merge(datable);

                            int position = _datatable.Columns.Count - 1;
                            _datatable.Columns["TTL"].SetOrdinal(position); 
                        }
                        if (counter == 2)
                        {
                            datable = this._demandController.GetTotalDemand(Param1, Param2);

                            int position = datable.Columns.Count - 1;
                            datable.Columns["TTL"].SetOrdinal(position); 

                            frm_ComparisonDemand allmonths = new frm_ComparisonDemand(_datatable, datable);
                            allmonths.Show();
                        }
                        counter++;
                    }
                    _countSelection = 1;
                }

            }
        }
    }
}
