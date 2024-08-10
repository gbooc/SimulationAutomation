using SimulationAutomation.Util;
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
    public partial class FrmModelMaintenance : Form
    {
        public FrmModelMaintenance()
        {
            InitializeComponent();         
        }

        private void FrmModelMaintenance_Load(object sender, EventArgs e)
        {
            try
            {
                var data = new Controllers.Maintenance.ModelsController().GetAllModels()._List.OrderBy(x => x.RinksNo);

                foreach (var item in data)
                {
                    this.dgvModel.Rows.Add(item.ModelID, item.RinksNo, item.TAT, item.ProductionLT, item.ShipmentLT);
                }
            }
            catch (Exception ex)
            {
                Util.MessageUtil.Confirm(ex.Message, string.Format(Util.Messages.ERROR_FOUND, ""));
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchValue = txtSearch.Text;

            dgvModel.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            try
            {
                foreach (DataGridViewRow row in dgvModel.Rows)
                {
                    if (row.Cells["colRinksNo"].Value.ToString().Contains(searchValue) || row.Cells["colTAT"].Value.ToString().Contains(searchValue))
                    {
                        row.Selected = true;
                        this.dgvModel.CurrentCell = this.dgvModel[1, row.Index];
                        break;
                    }
                    else
                    {
                        row.Selected = false;
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void dgvModel_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string type = this.dgvModel.Rows[e.RowIndex].Cells[this.colProductionLT.Name].Value.ToString();
                int modelId = Convert.ToInt32(this.dgvModel.Rows[e.RowIndex].Cells[this.colModelID.Name].Value.ToString());

                FrmModelEdit modelEdit = new FrmModelEdit(type, modelId);
                modelEdit.ShowDialog(this);

                if (modelEdit._ISCHANGES)
                {
                    this.dgvModel.Rows[e.RowIndex].Cells[this.colProductionLT.Name].Value = modelEdit._LEADTIME;
                }
            }
        }
    }
}