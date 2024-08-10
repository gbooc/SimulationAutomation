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
    public partial class FrmModelEdit : Form
    {
        public FrmModelEdit(string type, int modelID)
        {
            InitializeComponent();
            this._type = type;
            this._modelID = modelID;
        }

        public bool _ISCHANGES { get; set; }
        public int _LEADTIME { get; set; }
        private string _type;
        private int _modelID;

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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(this.txtLeadTime.Text))
                {
                    Models.Maintenance.RinksModel model = new Models.Maintenance.RinksModel();
                    model.ModelID = this._modelID;
                    model.ProductionLT = int.Parse(this.txtLeadTime.Text);
                    new Controllers.Maintenance.ModelsController().UpdateProductionLeadTime(model);
                    this._ISCHANGES = true;
                    this._LEADTIME = model.ProductionLT.Value;
                    this.Close();
                }
                else
                {
                    Util.MessageUtil.ShowWarning("Invalid LT value!", string.Format(Util.Messages.ERROR_FOUND, ""));
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

        private void txtLeadTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void FrmModelEdit_Load(object sender, EventArgs e)
        {
            this.txtLeadTime.Focus();
        }
    }
}
