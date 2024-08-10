using SimulationAutomation.Controllers;
using SimulationAutomation.Models;
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
    public partial class FrmShippingLeadtime : Form
    {

        #region Global Decleration/Initialization

        public FrmShippingLeadtime()
        {
            InitializeComponent();
            this._shippingLeadtime = new Models.Maintenance.ShippingLeadTimeModel();
            this._leadtimeController = new Controllers.Maintenance.ShippingLeadTimeController();
            
        }

        private Models.Maintenance.ShippingLeadTimeModel _shippingLeadtime;
        private Controllers.Maintenance.ShippingLeadTimeController _leadtimeController;

        private void FrmShippingLeadtime_Load(object sender, EventArgs e)
        {
            this.RetrieveShippingLeadtime();
        }

        #endregion


        private void RetrieveShippingLeadtime()
        {
            this._shippingLeadtime = this._leadtimeController.GetShippingLeadTime();

            // air
            this.txtPackingHkgAir.Text = this._shippingLeadtime.packing_hkg_air.ToString();
            this.txtPackingShanAir.Text = this._shippingLeadtime.packing_shan_air.ToString();
            this.txtPackingJpAir.Text = this._shippingLeadtime.packing_jp_air.ToString();

            this.txtPickupHkgAir.Text = this._shippingLeadtime.pickup_hkg_air.ToString();
            this.txtPickupShanAir.Text = this._shippingLeadtime.pickup_shan_air.ToString();
            this.txtPickupJpAir.Text = this._shippingLeadtime.pickup_jp_air.ToString();

            this.txtAirlineHkgAir.Text = this._shippingLeadtime.cargo_hkg_air.ToString();
            this.txtAirlineShanAir.Text = this._shippingLeadtime.cargo_shan_air.ToString();
            this.txtAirlineJpAir.Text = this._shippingLeadtime.cargo_jp_air.ToString();

            this.txtLeadtimeHkgAir.Text = this._shippingLeadtime.leadtime_hkg_air.ToString();
            this.txtLeadtimeShanAir.Text = this._shippingLeadtime.leadtime_shan_air.ToString();
            this.txtLeadtimeJpAir.Text = this._shippingLeadtime.leadtime_jp_air.ToString();

            this.txtETDHkgAir.Text = this._shippingLeadtime.etd_hkg_air.ToString();
            this.txtETDShanAir.Text = this._shippingLeadtime.etd_shan_air.ToString();
            this.txtETDJpAir.Text = this._shippingLeadtime.etd_jp_air.ToString();

            // sea
            this.txtPackingHkgSea.Text = this._shippingLeadtime.packing_hkg_sea.ToString();
            this.txtPackingShanSea.Text = this._shippingLeadtime.packing_shan_sea.ToString();
            this.txtPackingJpSea.Text = this._shippingLeadtime.packing_jp_sea.ToString();

            this.txtConfirmationHkgSea.Text = this._shippingLeadtime.confirmation_hkg_sea.ToString();
            this.txtConfirmationShanSea.Text = this._shippingLeadtime.confirmation_shan_sea.ToString();
            this.txtConfirmationJpSea.Text = this._shippingLeadtime.confirmation_jp_sea.ToString();

            this.txtPickupHkgSea.Text = this._shippingLeadtime.pickup_hkg_sea.ToString();
            this.txtPickupShanSea.Text = this._shippingLeadtime.pickup_shan_sea.ToString();
            this.txtPickupJpSea.Text = this._shippingLeadtime.pickup_jp_sea.ToString();

            this.txtCutoffHkgSea.Text = this._shippingLeadtime.cutoff_hkg_sea.ToString();
            this.txtCutoffShanSea.Text = this._shippingLeadtime.cutoff_shan_sea.ToString();
            this.txtCutoffJpSea.Text = this._shippingLeadtime.cutoff_jp_sea.ToString();

            this.txtVesselHkgSea.Text = this._shippingLeadtime.cargo_hkg_sea.ToString();
            this.txtVesselShanSea.Text = this._shippingLeadtime.cargo_shan_sea.ToString();
            this.txtVesselJpSea.Text = this._shippingLeadtime.cargo_jp_sea.ToString();

            this.txtLeadtimeHkgSea.Text = this._shippingLeadtime.leadtime_hkg_sea.ToString();
            this.txtLeadtimeShanSea.Text = this._shippingLeadtime.leadtime_shan_sea.ToString();
            this.txtLeadtimeJpSea.Text = this._shippingLeadtime.leadtime_jp_sea.ToString();

            this.txtETDHkgSea.Text = this._shippingLeadtime.etd_hkg_sea.ToString();
            this.txtETDShanSea.Text = this._shippingLeadtime.etd_shan_sea.ToString();
            this.txtETDJpSea.Text = this._shippingLeadtime.etd_jp_sea.ToString();
        }

        private void ComputeAirShipmentTotal()
        {
            int tempTotal = 0;
            Control control;

            // get total for hongkong
            for (int row = 0; row < this.tblLayoutAirShipment.RowCount - 1; row++)
            {
                control = this.tblLayoutAirShipment.GetControlFromPosition(1, row);

                if (control is TextBox)
                {
                    tempTotal += Convert.ToInt32(control.Text);
                }
            }
            this.txtTotalHkgAir.Text = tempTotal.ToString();
            tempTotal = 0;

            // get total for shanghai
            for (int row = 0; row < this.tblLayoutAirShipment.RowCount - 1; row++)
            {
                control = this.tblLayoutAirShipment.GetControlFromPosition(2, row);

                if (control is TextBox)
                {
                    tempTotal += Convert.ToInt32(control.Text);
                }
            }
            this.txtTotalShanAir.Text = tempTotal.ToString();
            tempTotal = 0;

            // get total for japan
            for (int row = 0; row < this.tblLayoutAirShipment.RowCount - 1; row++)
            {
                control = this.tblLayoutAirShipment.GetControlFromPosition(3, row);

                if (control is TextBox)
                {
                    tempTotal += Convert.ToInt32(control.Text);
                }
            }
            this.txtTotalJpAir.Text = tempTotal.ToString();
            tempTotal = 0;
        }

        private void ComputeSeaShipmentTotal()
        {
            int tempTotal = 0;
            Control control;

            // get total for hongkong
            for (int row = 0; row < this.tblLayoutSeaShipment.RowCount - 1; row++)
            {
                control = this.tblLayoutSeaShipment.GetControlFromPosition(1, row);

                if (control is TextBox)
                {
                    tempTotal += Convert.ToInt32(control.Text);
                }
            }
            this.txtTotalHkgSea.Text = tempTotal.ToString();
            tempTotal = 0;

            // get total for shanghai
            for (int row = 0; row < this.tblLayoutSeaShipment.RowCount - 1; row++)
            {
                control = this.tblLayoutSeaShipment.GetControlFromPosition(2, row);

                if (control is TextBox)
                {
                    tempTotal += Convert.ToInt32(control.Text);
                }
            }
            this.txtTotalShanSea.Text = tempTotal.ToString();
            tempTotal = 0;

            // get total for japan
            for (int row = 0; row < this.tblLayoutSeaShipment.RowCount - 1; row++)
            {
                control = this.tblLayoutSeaShipment.GetControlFromPosition(3, row);

                if (control is TextBox)
                {
                    tempTotal += Convert.ToInt32(control.Text);
                }
            }
            this.txtTotalJpSea.Text = tempTotal.ToString();
            tempTotal = 0;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // air shipment textboxes to enable
            foreach (Control control in this.tblLayoutAirShipment.Controls)
            {
                if (control is TextBox)
                {
                    if (control.Name != this.txtTotalHkgAir.Name &&
                        control.Name != this.txtTotalShanAir.Name &&
                        control.Name != this.txtTotalJpAir.Name)
                    {
                        control.Enabled = true;
                    }
                }
            }

            // sea shipment textboxes to enable
            foreach (Control control in this.tblLayoutSeaShipment.Controls)
            {
                if (control is TextBox)
                {
                    if (control.Name != this.txtTotalHkgSea.Name &&
                        control.Name != this.txtTotalShanSea.Name &&
                        control.Name != this.txtTotalJpSea.Name)
                    {
                        control.Enabled = true;
                    }
                }
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            // air shipment textboxes to disable
            // air shipment table
            foreach (Control control in this.tblLayoutAirShipment.Controls)
            {
                if (control is TextBox)
                {
                    control.Enabled = false;
                }
            }

            // sea shipment textboxes to disable
            foreach (Control control in this.tblLayoutSeaShipment.Controls)
            {
                if (control is TextBox)
                {
                    control.Enabled = false;
                }
            }
        }


        private void tblLayoutAirShipment_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            if (e.Row == this.tblLayoutAirShipment.RowCount - 1)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.DarkSeaGreen), e.CellBounds);
            }
        }

        private void tblLayoutSeaShipment_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            if (e.Row == this.tblLayoutSeaShipment.RowCount - 1)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.DarkSeaGreen), e.CellBounds);
            }
        }


        private void btnSaveAll_Click(object sender, EventArgs e)
        {
            this.txtPackingHkgAir.Select();

            if (this.HasChangesAirShipmentValues())
            {
                this._leadtimeController.UpdateShippingLeadtime(this.AssignTextBoxValuesToModelAirShipment());
            }

            if (this.HasChangesSeaShipmentValues())
            {
                this._leadtimeController.UpdateShippingLeadtime(this.AssignTextBoxValuesToModelSeaShipment());

            }

            this.RetrieveShippingLeadtime();
            this.btnCancel_Click(null, null);
            MessageUtil.ShowInfo(Messages.ENTRY_SAVED);
        }


        private Models.Maintenance.ShippingLeadTimeModel AssignTextBoxValuesToModelAirShipment()
        {
            Models.Maintenance.ShippingLeadTimeModel model = new Models.Maintenance.ShippingLeadTimeModel();

            model.shipping_leadtime_Id = this._shippingLeadtime.shipping_leadtime_Id;
            model.packing_hkg_air = Convert.ToInt32(this.txtPackingHkgAir.Text);
            model.packing_shan_air = Convert.ToInt32(this.txtPackingShanAir.Text);
            model.packing_jp_air = Convert.ToInt32(this.txtPackingJpAir.Text);
            model.pickup_hkg_air = Convert.ToInt32(this.txtPickupHkgAir.Text);
            model.pickup_shan_air = Convert.ToInt32(this.txtPickupShanAir.Text);
            model.pickup_jp_air = Convert.ToInt32(this.txtPickupJpAir.Text);
            model.cargo_hkg_air = Convert.ToInt32(this.txtAirlineHkgAir.Text);
            model.cargo_shan_air = Convert.ToInt32(this.txtAirlineShanAir.Text);
            model.cargo_jp_air = Convert.ToInt32(this.txtAirlineJpAir.Text);
            model.leadtime_hkg_air = Convert.ToInt32(this.txtLeadtimeHkgAir.Text);
            model.leadtime_shan_air = Convert.ToInt32(this.txtLeadtimeShanAir.Text);
            model.leadtime_jp_air = Convert.ToInt32(this.txtLeadtimeJpAir.Text);
            model.etd_hkg_air = Convert.ToInt32(this.txtETDHkgAir.Text);
            model.etd_shan_air = Convert.ToInt32(this.txtETDShanAir.Text);
            model.etd_jp_air = Convert.ToInt32(this.txtETDJpAir.Text);

            return model;
        }


        private Models.Maintenance.ShippingLeadTimeModel AssignTextBoxValuesToModelSeaShipment()
        {
            Models.Maintenance.ShippingLeadTimeModel model = new Models.Maintenance.ShippingLeadTimeModel();

            model.shipping_leadtime_Id = this._shippingLeadtime.shipping_leadtime_Id;
            model.packing_hkg_sea = Convert.ToInt32(this.txtPackingHkgSea.Text);
            model.packing_shan_sea = Convert.ToInt32(this.txtPackingShanSea.Text);
            model.packing_jp_sea = Convert.ToInt32(this.txtPackingJpSea.Text);
            model.confirmation_hkg_sea = Convert.ToInt32(this.txtConfirmationHkgSea.Text);
            model.confirmation_shan_sea = Convert.ToInt32(this.txtConfirmationShanSea.Text);
            model.confirmation_jp_sea = Convert.ToInt32(this.txtConfirmationJpSea.Text);
            model.pickup_hkg_sea = Convert.ToInt32(this.txtPickupHkgSea.Text);
            model.pickup_shan_sea = Convert.ToInt32(this.txtPickupShanSea.Text);
            model.pickup_jp_sea = Convert.ToInt32(this.txtPickupJpSea.Text);
            model.cutoff_hkg_sea = Convert.ToInt32(this.txtCutoffHkgSea.Text);
            model.cutoff_shan_sea = Convert.ToInt32(this.txtCutoffShanSea.Text);
            model.cutoff_jp_sea = Convert.ToInt32(this.txtCutoffJpSea.Text);
            model.cargo_hkg_sea = Convert.ToInt32(this.txtVesselHkgSea.Text);
            model.cargo_shan_sea = Convert.ToInt32(this.txtVesselShanSea.Text);
            model.cargo_jp_sea = Convert.ToInt32(this.txtVesselJpSea.Text);
            model.leadtime_hkg_sea = Convert.ToInt32(this.txtLeadtimeHkgSea.Text);
            model.leadtime_shan_sea = Convert.ToInt32(this.txtLeadtimeShanSea.Text);
            model.leadtime_jp_sea = Convert.ToInt32(this.txtLeadtimeJpSea.Text);
            model.etd_hkg_sea = Convert.ToInt32(this.txtETDHkgSea.Text);
            model.etd_shan_sea = Convert.ToInt32(this.txtETDShanSea.Text);
            model.etd_jp_sea = Convert.ToInt32(this.txtETDJpSea.Text);

            return model;
        }


        private bool HasChangesSeaShipmentValues()
        {
            bool hasChanges = false;

            if (Convert.ToInt32(this.txtPackingHkgSea.Text) != this._shippingLeadtime.packing_hkg_sea ||
                Convert.ToInt32(this.txtPackingShanSea.Text) != this._shippingLeadtime.packing_shan_sea ||
                Convert.ToInt32(this.txtPackingJpSea.Text) != this._shippingLeadtime.packing_jp_sea ||
                Convert.ToInt32(this.txtConfirmationHkgSea.Text) != this._shippingLeadtime.confirmation_hkg_sea ||
                Convert.ToInt32(this.txtConfirmationShanSea.Text) != this._shippingLeadtime.confirmation_shan_sea ||
                Convert.ToInt32(this.txtConfirmationJpSea.Text) != this._shippingLeadtime.confirmation_jp_sea ||
                Convert.ToInt32(this.txtPickupHkgSea.Text) != this._shippingLeadtime.pickup_hkg_sea ||
                Convert.ToInt32(this.txtPickupShanSea.Text) != this._shippingLeadtime.pickup_shan_sea ||
                Convert.ToInt32(this.txtPickupJpSea.Text) != this._shippingLeadtime.pickup_jp_sea ||
                Convert.ToInt32(this.txtCutoffHkgSea.Text) != this._shippingLeadtime.cutoff_hkg_sea ||
                Convert.ToInt32(this.txtCutoffShanSea.Text) != this._shippingLeadtime.cutoff_shan_sea ||
                Convert.ToInt32(this.txtCutoffJpSea.Text) != this._shippingLeadtime.cutoff_jp_sea ||
                Convert.ToInt32(this.txtVesselHkgSea.Text) != this._shippingLeadtime.cargo_hkg_sea ||
                Convert.ToInt32(this.txtVesselShanSea.Text) != this._shippingLeadtime.cargo_shan_sea ||
                Convert.ToInt32(this.txtVesselJpSea.Text) != this._shippingLeadtime.cargo_jp_sea ||
                Convert.ToInt32(this.txtLeadtimeHkgSea.Text) != this._shippingLeadtime.leadtime_hkg_sea ||
                Convert.ToInt32(this.txtLeadtimeShanSea.Text) != this._shippingLeadtime.leadtime_shan_sea ||
                Convert.ToInt32(this.txtLeadtimeJpSea.Text) != this._shippingLeadtime.leadtime_jp_sea ||
                Convert.ToInt32(this.txtETDHkgSea.Text) != this._shippingLeadtime.etd_hkg_sea ||
                Convert.ToInt32(this.txtETDShanSea.Text) != this._shippingLeadtime.etd_shan_sea ||
                Convert.ToInt32(this.txtETDJpSea.Text) != this._shippingLeadtime.etd_jp_sea)
            {
                hasChanges = true;
            }
            return hasChanges;
        }


        private bool HasChangesAirShipmentValues()
        {
            bool hasChanges = false;

            if (Convert.ToInt32(this.txtPackingHkgAir.Text) != this._shippingLeadtime.packing_hkg_air ||
                Convert.ToInt32(this.txtPackingShanAir.Text) != this._shippingLeadtime.packing_shan_air ||
                Convert.ToInt32(this.txtPackingJpAir.Text) != this._shippingLeadtime.packing_jp_air ||
                Convert.ToInt32(this.txtPickupHkgAir.Text) != this._shippingLeadtime.pickup_hkg_air ||
                Convert.ToInt32(this.txtPickupShanAir.Text) != this._shippingLeadtime.pickup_shan_air ||
                Convert.ToInt32(this.txtPickupJpAir.Text) != this._shippingLeadtime.pickup_jp_air ||
                Convert.ToInt32(this.txtAirlineHkgAir.Text) != this._shippingLeadtime.cargo_hkg_air ||
                Convert.ToInt32(this.txtAirlineShanAir.Text) != this._shippingLeadtime.cargo_shan_air ||
                Convert.ToInt32(this.txtAirlineJpAir.Text) != this._shippingLeadtime.cargo_jp_air ||
                Convert.ToInt32(this.txtLeadtimeHkgAir.Text) != this._shippingLeadtime.leadtime_hkg_air ||
                Convert.ToInt32(this.txtLeadtimeShanAir.Text) != this._shippingLeadtime.leadtime_shan_air ||
                Convert.ToInt32(this.txtLeadtimeJpAir.Text) != this._shippingLeadtime.leadtime_jp_air ||
                Convert.ToInt32(this.txtETDHkgAir.Text) != this._shippingLeadtime.etd_hkg_air ||
                Convert.ToInt32(this.txtETDShanAir.Text) != this._shippingLeadtime.etd_shan_air ||
                Convert.ToInt32(this.txtETDJpAir.Text) != this._shippingLeadtime.etd_jp_air)
            {
                hasChanges = true;
            }
            return hasChanges;
        }


        private void txtTableAir_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (!string.IsNullOrEmpty(textBox.Text))
            {
                this.ComputeAirShipmentTotal();
            }
        }


        private void txtTableSea_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (!string.IsNullOrEmpty(textBox.Text))
            {
                this.ComputeSeaShipmentTotal();
            }
        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.S))
            {
                this.btnSaveAll_Click(null, null);
            }
            else if (keyData == (Keys.Control | Keys.E))
            {
                this.btnEdit_Click(null, null);
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }


        private void txtBoxes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }


        private void txtBoxes_Click(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            textBox.SelectAll();
        }


        private void txtBoxes_Validating(object sender, CancelEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Text = "0";
            }
        }
    }
}
