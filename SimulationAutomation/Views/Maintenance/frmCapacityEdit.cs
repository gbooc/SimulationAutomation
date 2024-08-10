using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimulationAutomation.Views.Maintenance
{
    public partial class frmCapacityEdit : Form
    {
        public frmCapacityEdit(string code, string workScheme, string model, string line, string tat, int capacity, string status)
        {
            InitializeComponent();

            this._code = code;
            this._workScheme = workScheme;
            this._model = model;
            this._tat = tat;
            this._line= line;
            this._status = status;
            this._capacity = capacity;
        }

        private string _code { get; set; }
        private string _workScheme{ get; set; }
        private string _model { get; set; }
        private string _tat{ get; set; }
        private string _line { get; set; }
        private string _status { get; set; }
        private int _capacity { get; set; }
        public Models.Maintenance.CapacityModel.CapacityAuditTrail capacityAuditTrailModel { get; set; }

        public bool _ISCHANGES { get; set; }
        public int _CAPACITY { get; set; }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Escape:
                    this.Close();
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void frmCapacityEdit_Load(object sender, EventArgs e)
        {
            this.txtModel.Text = this._model;
            this.txtTat.Text = this._tat;
            this.txtCode.Text = this._code;
            this.txtWorkScheme.Text = this._workScheme;
            this.txtLine.Text = this._line;
            this.txtOldCapacity.Text = this._capacity.ToString();
            this.txtNewCapacity.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.txtReason.Text.Trim()))
                {
                    Util.MessageUtil.ShowWarning("Reason is required!", string.Format(Util.Messages.ERROR_FOUND, ""));
                    return;
                }
                else if (!string.IsNullOrEmpty(this.txtReason.Text.Trim()) && this.txtReason.Text.Trim().Length < 10)
                {
                    Util.MessageUtil.ShowWarning("Character in reason must be beyond 10 characters.", string.Format(Util.Messages.ERROR_FOUND, ""));
                    return;
                }

                if (!string.IsNullOrEmpty(this.txtNewCapacity.Text))
                {
                    int newCapacity = Convert.ToInt32(this.txtNewCapacity.Text);
                    new Controllers.Maintenance.CapacityController().InsertUpdateCapacity(this._code, this._workScheme, this._model, this._line, this._tat, newCapacity, this._status);

                    capacityAuditTrailModel = new Models.Maintenance.CapacityModel.CapacityAuditTrail();

                    capacityAuditTrailModel.model = this._model;
                    capacityAuditTrailModel.WorkScheme = this._workScheme;
                    capacityAuditTrailModel.from = Convert.ToInt32(this.txtOldCapacity.Text);
                    capacityAuditTrailModel.to = newCapacity;
                    capacityAuditTrailModel.reason = this.txtReason.Text;
                    capacityAuditTrailModel.incharge = Program.userLog;
                    new Controllers.Maintenance.CapacityController().InsertCapacityAuditTrail(capacityAuditTrailModel);

                    this._ISCHANGES = true;
                    this._CAPACITY = Convert.ToInt32(this.txtNewCapacity.Text);
                    this.Close();
                }
                else
                {
                    Util.MessageUtil.ShowWarning("Invalid Capacity value!", string.Format(Util.Messages.ERROR_FOUND, ""));
                }
            }
            catch (Exception ex)
            {
                Util.MessageUtil.ShowError(ex.Message, string.Format(Util.Messages.ERROR_FOUND, ""));
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCapacity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
    }
}
