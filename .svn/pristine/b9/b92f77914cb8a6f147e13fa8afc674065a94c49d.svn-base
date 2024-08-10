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
    public partial class frmCapacity : Form
    {
        public frmCapacity()
        {
            InitializeComponent();
        }

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

        private void PreventEditRows()
        {
            foreach (DataGridViewRow row in this.dgvCapacitySetup.Rows)
            {
                #region Color Cell when Read Only
                #region LINE A
                row.Cells[this.colLineCapacityLineA_A.Index].Style.BackColor = ((Convert.ToBoolean(row.Cells[this.colCapabilitiesLineA.Index].Value)) ? row.Cells[this.colRinksNo.Index].Style.BackColor : Color.Gray);
                row.Cells[this.colLineCapacityLineA_B.Index].Style.BackColor = ((Convert.ToBoolean(row.Cells[this.colCapabilitiesLineA.Index].Value)) ? row.Cells[this.colRinksNo.Index].Style.BackColor : Color.Gray);
                row.Cells[this.colLineCapacityLineA_C.Index].Style.BackColor = ((Convert.ToBoolean(row.Cells[this.colCapabilitiesLineA.Index].Value)) ? row.Cells[this.colRinksNo.Index].Style.BackColor : Color.Gray);
                row.Cells[this.colLineCapacityLineA_D.Index].Style.BackColor = ((Convert.ToBoolean(row.Cells[this.colCapabilitiesLineA.Index].Value)) ? row.Cells[this.colRinksNo.Index].Style.BackColor : Color.Gray);
                row.Cells[this.colLineCapacityLineA_E.Index].Style.BackColor = ((Convert.ToBoolean(row.Cells[this.colCapabilitiesLineA.Index].Value)) ? row.Cells[this.colRinksNo.Index].Style.BackColor : Color.Gray);
                #endregion
                #region LINE B
                row.Cells[this.colLineCapacityLineB_A.Index].Style.BackColor = ((Convert.ToBoolean(row.Cells[this.colCapabilitiesLineB.Index].Value)) ? row.Cells[this.colRinksNo.Index].Style.BackColor : Color.Gray);
                row.Cells[this.colLineCapacityLineB_B.Index].Style.BackColor = ((Convert.ToBoolean(row.Cells[this.colCapabilitiesLineB.Index].Value)) ? row.Cells[this.colRinksNo.Index].Style.BackColor : Color.Gray);
                row.Cells[this.colLineCapacityLineB_C.Index].Style.BackColor = ((Convert.ToBoolean(row.Cells[this.colCapabilitiesLineB.Index].Value)) ? row.Cells[this.colRinksNo.Index].Style.BackColor : Color.Gray);
                row.Cells[this.colLineCapacityLineB_D.Index].Style.BackColor = ((Convert.ToBoolean(row.Cells[this.colCapabilitiesLineB.Index].Value)) ? row.Cells[this.colRinksNo.Index].Style.BackColor : Color.Gray);
                row.Cells[this.colLineCapacityLineB_E.Index].Style.BackColor = ((Convert.ToBoolean(row.Cells[this.colCapabilitiesLineB.Index].Value)) ? row.Cells[this.colRinksNo.Index].Style.BackColor : Color.Gray);
                #endregion
                #endregion

                #region Read Only the cells when false
                #region LINE A
                //row.Cells[this.colLineCapacityLineA_A.Index].ReadOnly = !Convert.ToBoolean(row.Cells[this.colCapabilitiesLineA.Index].Value);
                //row.Cells[this.colLineCapacityLineA_B.Index].ReadOnly = !Convert.ToBoolean(row.Cells[this.colCapabilitiesLineA.Index].Value);
                //row.Cells[this.colLineCapacityLineA_C.Index].ReadOnly = !Convert.ToBoolean(row.Cells[this.colCapabilitiesLineA.Index].Value);
                //row.Cells[this.colLineCapacityLineA_D.Index].ReadOnly = !Convert.ToBoolean(row.Cells[this.colCapabilitiesLineA.Index].Value);
                //row.Cells[this.colLineCapacityLineA_E.Index].ReadOnly = !Convert.ToBoolean(row.Cells[this.colCapabilitiesLineA.Index].Value);
                #endregion
                #region LINE B
                //row.Cells[this.colLineCapacityLineB_A.Index].ReadOnly = !Convert.ToBoolean(row.Cells[this.colCapabilitiesLineB.Index].Value);
                //row.Cells[this.colLineCapacityLineB_B.Index].ReadOnly = !Convert.ToBoolean(row.Cells[this.colCapabilitiesLineB.Index].Value);
                //row.Cells[this.colLineCapacityLineB_C.Index].ReadOnly = !Convert.ToBoolean(row.Cells[this.colCapabilitiesLineB.Index].Value);
                //row.Cells[this.colLineCapacityLineB_D.Index].ReadOnly = !Convert.ToBoolean(row.Cells[this.colCapabilitiesLineB.Index].Value);
                //row.Cells[this.colLineCapacityLineB_E.Index].ReadOnly = !Convert.ToBoolean(row.Cells[this.colCapabilitiesLineB.Index].Value);
                #endregion
                #endregion
            }
        }

        private void frmCapacity_Load(object sender, EventArgs e)
        {
            Util.CommonUtil.InvokeDgvDoubleBuffered(this.dgvCapacitySetup);
            Util.CommonUtil.InvokeDgvDoubleBuffered(this.dataGridView1);

            #region PADDING
            Padding padding = new Padding(0, 0, 0, 4);

            #region LINE A
            this.colLineCapacityLineA_A.HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            this.colLineCapacityLineA_A.HeaderCell.Style.Padding = padding;

            this.colLineCapacityLineA_B.HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            this.colLineCapacityLineA_B.HeaderCell.Style.Padding = padding;

            this.colLineCapacityLineA_C.HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            this.colLineCapacityLineA_C.HeaderCell.Style.Padding = padding;

            this.colLineCapacityLineA_D.HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            this.colLineCapacityLineA_D.HeaderCell.Style.Padding = padding;

            this.colLineCapacityLineA_E.HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            this.colLineCapacityLineA_E.HeaderCell.Style.Padding = padding;
            #endregion
            #region LINE B
            this.colLineCapacityLineB_A.HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            this.colLineCapacityLineB_A.HeaderCell.Style.Padding = padding;

            this.colLineCapacityLineB_B.HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            this.colLineCapacityLineB_B.HeaderCell.Style.Padding = padding;

            this.colLineCapacityLineB_C.HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            this.colLineCapacityLineB_C.HeaderCell.Style.Padding = padding;

            this.colLineCapacityLineB_D.HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            this.colLineCapacityLineB_D.HeaderCell.Style.Padding = padding;

            this.colLineCapacityLineB_E.HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            this.colLineCapacityLineB_E.HeaderCell.Style.Padding = padding;
            #endregion
            #endregion

            Models.Maintenance.CapacityModel.ModelCapacityList result = new Models.Maintenance.CapacityModel.ModelCapacityList();
            result = new Controllers.Maintenance.CapacityController().GetModelCapacity();

            if (!string.IsNullOrEmpty(result.Error))
            {
                Util.MessageUtil.ShowError(result.Error, string.Format(Util.Messages.ERROR_FOUND, ""));
                return;
            }

            foreach (var item in result._List)
            {
                this.dgvCapacitySetup.Rows.Add(item.rinks_no, item.tat,
                                                  (item.Line_A != null),
                                                  (item.Line_B != null),
                                                  item.CODE_HOURS_A_A,
                                                  item.CODE_HOURS_A_B,
                                                  item.CODE_HOURS_B_A,
                                                  item.CODE_HOURS_B_B,
                                                  item.CODE_HOURS_C_A,
                                                  item.CODE_HOURS_C_B,
                                                  item.CODE_HOURS_D_A,
                                                  item.CODE_HOURS_D_B,
                                                  item.CODE_HOURS_E_A,
                                                  item.CODE_HOURS_E_B);
            }


            Models.Maintenance.CapacityModel.CapacityAuditTrailList capacityAuditTrailResult = new Models.Maintenance.CapacityModel.CapacityAuditTrailList();
            capacityAuditTrailResult = new Controllers.Maintenance.CapacityController().GetCapacityAuditTrail();

            foreach (var item in capacityAuditTrailResult._List)
            {
                this.dataGridView1.Rows.Add(item.id, item.model, item.WorkScheme, item.from, item.to, item.reason, item.dateupdated, item.incharge);
            }
        }

        private void dgvCapacitySetup_Paint(object sender, PaintEventArgs e)
        {
            Util.CommonUtil.DrawRectangle(this.colLineCapacityLineA_A.Index, Util.GlobalConstants.HOURS_WORKSCHEME_A, e, this.dgvCapacitySetup);
            Util.CommonUtil.DrawRectangle(this.colLineCapacityLineA_B.Index, Util.GlobalConstants.HOURS_WORKSCHEME_B, e, this.dgvCapacitySetup);
            Util.CommonUtil.DrawRectangle(this.colLineCapacityLineA_C.Index, Util.GlobalConstants.HOURS_WORKSCHEME_C, e, this.dgvCapacitySetup);
            Util.CommonUtil.DrawRectangle(this.colLineCapacityLineA_D.Index, Util.GlobalConstants.HOURS_WORKSCHEME_D, e, this.dgvCapacitySetup);
            Util.CommonUtil.DrawRectangle(this.colLineCapacityLineA_E.Index, Util.GlobalConstants.HOURS_WORKSCHEME_E, e, this.dgvCapacitySetup);
        }

        private void dgvCapacitySetup_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.PreventEditRows();
        }

        private void dgvCapacitySetup_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            this.PreventEditRows();

            /**************************************************************
            if (e.ColumnIndex == this.colCapabilitiesLineA.Index) // LINE A
            {
                string model = this.dgvCapacitySetup.Rows[e.RowIndex].Cells[this.colRinksNo.Index].Value.ToString();
                string line = Util.GlobalConstants.LINE_A;
                string status = Convert.ToBoolean(this.dgvCapacitySetup.Rows[e.RowIndex].Cells[this.colCapabilitiesLineA.Index].Value) ? Util.GlobalConstants.ACTIVE : Util.GlobalConstants.INACTIVE;
                new Controllers.Maintenance.CapacityController().LineModelActivation(model, line, status);
            }
            else if (e.ColumnIndex == this.colCapabilitiesLineB.Index) // LINE B
            {
                string model = this.dgvCapacitySetup.Rows[e.RowIndex].Cells[this.colRinksNo.Index].Value.ToString();
                string line = Util.GlobalConstants.LINE_B;
                string status = Convert.ToBoolean(this.dgvCapacitySetup.Rows[e.RowIndex].Cells[this.colCapabilitiesLineB.Index].Value) ? Util.GlobalConstants.ACTIVE : Util.GlobalConstants.INACTIVE;
                new Controllers.Maintenance.CapacityController().LineModelActivation(model, line, status);
            }
            else
            {
                int[] line_A = { this.colLineCapacityLineA_A.Index, this.colLineCapacityLineA_B.Index, this.colLineCapacityLineA_C.Index, this.colLineCapacityLineA_D.Index, this.colLineCapacityLineA_E.Index };
                int[] line_B = { this.colLineCapacityLineB_A.Index, this.colLineCapacityLineB_B.Index, this.colLineCapacityLineB_C.Index, this.colLineCapacityLineB_D.Index, this.colLineCapacityLineB_E.Index };

                int[] hoursCode_A = { this.colLineCapacityLineA_A.Index, this.colLineCapacityLineB_A.Index };
                int[] hoursCode_B = { this.colLineCapacityLineA_B.Index, this.colLineCapacityLineB_B.Index };
                int[] hoursCode_C = { this.colLineCapacityLineA_C.Index, this.colLineCapacityLineB_C.Index };
                int[] hoursCode_D = { this.colLineCapacityLineA_D.Index, this.colLineCapacityLineB_D.Index };
                int[] hoursCode_E = { this.colLineCapacityLineA_E.Index, this.colLineCapacityLineB_E.Index };

                Models.Maintenance.CapacityModel.Capacity capacity = new Models.Maintenance.CapacityModel.Capacity();
                capacity.Model = this.dgvCapacitySetup.Rows[e.RowIndex].Cells[this.colRinksNo.Index].Value.ToString();
                capacity.tat = this.dgvCapacitySetup.Rows[e.RowIndex].Cells[this.colTAT.Index].Value.ToString();
                capacity.CapacityValue = this.dgvCapacitySetup.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null ? 0 : int.Parse(this.dgvCapacitySetup.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                capacity.Status = Util.GlobalConstants.ACTIVE;

                if (line_A.Contains(e.ColumnIndex)) //LINE A
                {
                    capacity.Line = Util.GlobalConstants.LINE_A;

                    #region WORKSCHEME
                    if (hoursCode_A.Contains(e.ColumnIndex))
                    {
                        capacity.CODE = Util.GlobalConstants.HOURS_CODE_A;
                        capacity.WorkScheme = Util.GlobalConstants.HOURS_WORKSCHEME_A;
                    }
                    else if (hoursCode_B.Contains(e.ColumnIndex))
                    {
                        capacity.CODE = Util.GlobalConstants.HOURS_CODE_B;
                        capacity.WorkScheme = Util.GlobalConstants.HOURS_WORKSCHEME_B;
                    }
                    else if (hoursCode_C.Contains(e.ColumnIndex))
                    {
                        capacity.CODE = Util.GlobalConstants.HOURS_CODE_C;
                        capacity.WorkScheme = Util.GlobalConstants.HOURS_WORKSCHEME_C;
                    }
                    else if (hoursCode_D.Contains(e.ColumnIndex))
                    {
                        capacity.CODE = Util.GlobalConstants.HOURS_CODE_D;
                        capacity.WorkScheme = Util.GlobalConstants.HOURS_WORKSCHEME_D;
                    }
                    else if (hoursCode_E.Contains(e.ColumnIndex))
                    {
                        capacity.CODE = Util.GlobalConstants.HOURS_CODE_E;
                        capacity.WorkScheme = Util.GlobalConstants.HOURS_WORKSCHEME_E;
                    }
                    #endregion
                }
                else if (line_B.Contains(e.ColumnIndex)) //LINE B
                {
                    capacity.Line = Util.GlobalConstants.LINE_B;

                    #region WORKSCHEME
                    if (hoursCode_A.Contains(e.ColumnIndex))
                    {
                        capacity.CODE = Util.GlobalConstants.HOURS_CODE_A;
                        capacity.WorkScheme = Util.GlobalConstants.HOURS_WORKSCHEME_A;
                    }
                    else if (hoursCode_B.Contains(e.ColumnIndex))
                    {
                        capacity.CODE = Util.GlobalConstants.HOURS_CODE_B;
                        capacity.WorkScheme = Util.GlobalConstants.HOURS_WORKSCHEME_B;
                    }
                    else if (hoursCode_C.Contains(e.ColumnIndex))
                    {
                        capacity.CODE = Util.GlobalConstants.HOURS_CODE_C;
                        capacity.WorkScheme = Util.GlobalConstants.HOURS_WORKSCHEME_C;
                    }
                    else if (hoursCode_D.Contains(e.ColumnIndex))
                    {
                        capacity.CODE = Util.GlobalConstants.HOURS_CODE_D;
                        capacity.WorkScheme = Util.GlobalConstants.HOURS_WORKSCHEME_D;
                    }
                    else if (hoursCode_E.Contains(e.ColumnIndex))
                    {
                        capacity.CODE = Util.GlobalConstants.HOURS_CODE_E;
                        capacity.WorkScheme = Util.GlobalConstants.HOURS_WORKSCHEME_E;
                    }
                    #endregion
                }
                new Controllers.Maintenance.CapacityController().InsertUpdateCapacity(capacity.CODE, capacity.WorkScheme, capacity.Model, capacity.Line, capacity.tat, capacity.CapacityValue, capacity.Status);
            }
             ***********************************************************************/
        }

        private void dgvCapacitySetup_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var colTextBox = e.Control as TextBox;

            colTextBox.ShortcutsEnabled = false;
            colTextBox.MaxLength = 10;
            colTextBox.KeyPress += OnkeyPress;
        }

        private void OnkeyPress(object sender, KeyPressEventArgs e)
        {
            var textbox = sender as TextBox;

            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchValue = txtSearch.Text;

            dgvCapacitySetup.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            try
            {
                foreach (DataGridViewRow row in dgvCapacitySetup.Rows)
                {
                    if (row.Cells["colRinksNo"].Value.ToString().Contains(searchValue) || row.Cells["colTAT"].Value.ToString().Contains(searchValue))
                    {
                        row.Selected = true;
                        this.dgvCapacitySetup.CurrentCell = this.dgvCapacitySetup[0, row.Index];
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

        private void dgvCapacitySetup_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (this.dgvCapacitySetup.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly) return;
            if (this.dgvCapacitySetup.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor == Color.Gray) return;

            if (e.ColumnIndex == this.colCapabilitiesLineA.Index) // LINE A
            {
                string model = this.dgvCapacitySetup.Rows[e.RowIndex].Cells[this.colRinksNo.Index].Value.ToString();
                string line = Util.GlobalConstants.LINE_A;
                string status = Convert.ToBoolean(this.dgvCapacitySetup.Rows[e.RowIndex].Cells[this.colCapabilitiesLineA.Index].Value) ? Util.GlobalConstants.ACTIVE : Util.GlobalConstants.INACTIVE;
                new Controllers.Maintenance.CapacityController().LineModelActivation(model, line, status);
            }
            else if (e.ColumnIndex == this.colCapabilitiesLineB.Index) // LINE B
            {
                string model = this.dgvCapacitySetup.Rows[e.RowIndex].Cells[this.colRinksNo.Index].Value.ToString();
                string line = Util.GlobalConstants.LINE_B;
                string status = Convert.ToBoolean(this.dgvCapacitySetup.Rows[e.RowIndex].Cells[this.colCapabilitiesLineB.Index].Value) ? Util.GlobalConstants.ACTIVE : Util.GlobalConstants.INACTIVE;
                new Controllers.Maintenance.CapacityController().LineModelActivation(model, line, status);
            }
            else
            {
                int[] line_A = { this.colLineCapacityLineA_A.Index, this.colLineCapacityLineA_B.Index, this.colLineCapacityLineA_C.Index, this.colLineCapacityLineA_D.Index, this.colLineCapacityLineA_E.Index };
                int[] line_B = { this.colLineCapacityLineB_A.Index, this.colLineCapacityLineB_B.Index, this.colLineCapacityLineB_C.Index, this.colLineCapacityLineB_D.Index, this.colLineCapacityLineB_E.Index };

                int[] hoursCode_A = { this.colLineCapacityLineA_A.Index, this.colLineCapacityLineB_A.Index };
                int[] hoursCode_B = { this.colLineCapacityLineA_B.Index, this.colLineCapacityLineB_B.Index };
                int[] hoursCode_C = { this.colLineCapacityLineA_C.Index, this.colLineCapacityLineB_C.Index };
                int[] hoursCode_D = { this.colLineCapacityLineA_D.Index, this.colLineCapacityLineB_D.Index };
                int[] hoursCode_E = { this.colLineCapacityLineA_E.Index, this.colLineCapacityLineB_E.Index };

                Models.Maintenance.CapacityModel.Capacity capacity = new Models.Maintenance.CapacityModel.Capacity();
                capacity.Model = this.dgvCapacitySetup.Rows[e.RowIndex].Cells[this.colRinksNo.Index].Value.ToString();
                capacity.tat = this.dgvCapacitySetup.Rows[e.RowIndex].Cells[this.colTAT.Index].Value.ToString();
                capacity.CapacityValue = this.dgvCapacitySetup.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null ? 0 : int.Parse(this.dgvCapacitySetup.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                capacity.Status = Util.GlobalConstants.ACTIVE;

                if (line_A.Contains(e.ColumnIndex)) //LINE A
                {
                    capacity.Line = Util.GlobalConstants.LINE_A;

                    #region WORKSCHEME
                    if (hoursCode_A.Contains(e.ColumnIndex))
                    {
                        capacity.CODE = Util.GlobalConstants.HOURS_CODE_A;
                        capacity.WorkScheme = Util.GlobalConstants.HOURS_WORKSCHEME_A;
                    }
                    else if (hoursCode_B.Contains(e.ColumnIndex))
                    {
                        capacity.CODE = Util.GlobalConstants.HOURS_CODE_B;
                        capacity.WorkScheme = Util.GlobalConstants.HOURS_WORKSCHEME_B;
                    }
                    else if (hoursCode_C.Contains(e.ColumnIndex))
                    {
                        capacity.CODE = Util.GlobalConstants.HOURS_CODE_C;
                        capacity.WorkScheme = Util.GlobalConstants.HOURS_WORKSCHEME_C;
                    }
                    else if (hoursCode_D.Contains(e.ColumnIndex))
                    {
                        capacity.CODE = Util.GlobalConstants.HOURS_CODE_D;
                        capacity.WorkScheme = Util.GlobalConstants.HOURS_WORKSCHEME_D;
                    }
                    else if (hoursCode_E.Contains(e.ColumnIndex))
                    {
                        capacity.CODE = Util.GlobalConstants.HOURS_CODE_E;
                        capacity.WorkScheme = Util.GlobalConstants.HOURS_WORKSCHEME_E;
                    }
                    #endregion
                }
                else if (line_B.Contains(e.ColumnIndex)) //LINE B
                {
                    capacity.Line = Util.GlobalConstants.LINE_B;

                    #region WORKSCHEME
                    if (hoursCode_A.Contains(e.ColumnIndex))
                    {
                        capacity.CODE = Util.GlobalConstants.HOURS_CODE_A;
                        capacity.WorkScheme = Util.GlobalConstants.HOURS_WORKSCHEME_A;
                    }
                    else if (hoursCode_B.Contains(e.ColumnIndex))
                    {
                        capacity.CODE = Util.GlobalConstants.HOURS_CODE_B;
                        capacity.WorkScheme = Util.GlobalConstants.HOURS_WORKSCHEME_B;
                    }
                    else if (hoursCode_C.Contains(e.ColumnIndex))
                    {
                        capacity.CODE = Util.GlobalConstants.HOURS_CODE_C;
                        capacity.WorkScheme = Util.GlobalConstants.HOURS_WORKSCHEME_C;
                    }
                    else if (hoursCode_D.Contains(e.ColumnIndex))
                    {
                        capacity.CODE = Util.GlobalConstants.HOURS_CODE_D;
                        capacity.WorkScheme = Util.GlobalConstants.HOURS_WORKSCHEME_D;
                    }
                    else if (hoursCode_E.Contains(e.ColumnIndex))
                    {
                        capacity.CODE = Util.GlobalConstants.HOURS_CODE_E;
                        capacity.WorkScheme = Util.GlobalConstants.HOURS_WORKSCHEME_E;
                    }
                    #endregion
                }

                frmCapacityEdit capacityEdit = new frmCapacityEdit(capacity.CODE, capacity.WorkScheme, capacity.Model, capacity.Line, capacity.tat, capacity.CapacityValue.Value, capacity.Status);
                capacityEdit.ShowDialog();
                if (capacityEdit._ISCHANGES)
                {
                    this.dgvCapacitySetup.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = capacityEdit._CAPACITY;

                    //Models.Maintenance.CapacityModel.CapacityAuditTrailList capacityAuditTrailResult = new Models.Maintenance.CapacityModel.CapacityAuditTrailList();
                    //capacityAuditTrailResult = new Controllers.Maintenance.CapacityController().GetCapacityAuditTrail();

                    //foreach (var item in capacityAuditTrailResult._List)
                    //{
                    this.dataGridView1.Rows.Add(capacityEdit.capacityAuditTrailModel.id, capacityEdit.capacityAuditTrailModel.model, capacityEdit.capacityAuditTrailModel.WorkScheme, capacityEdit.capacityAuditTrailModel.from, capacityEdit.capacityAuditTrailModel.to, capacityEdit.capacityAuditTrailModel.reason, DateTime.Now, capacityEdit.capacityAuditTrailModel.incharge);
                }
                //new Controllers.Maintenance.CapacityController().InsertUpdateCapacity(capacity.CODE, capacity.WorkScheme, capacity.Model, capacity.Line, capacity.tat, capacity.CapacityValue, capacity.Status);
            }
        }
    }
}