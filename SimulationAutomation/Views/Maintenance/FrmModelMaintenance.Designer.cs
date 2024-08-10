namespace SimulationAutomation.Views.Maintenance
{
    partial class FrmModelMaintenance
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvModel = new System.Windows.Forms.DataGridView();
            this.colModelID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRinksNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTAT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductionLT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colShipmentLT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModel)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvModel
            // 
            this.dgvModel.AllowUserToAddRows = false;
            this.dgvModel.AllowUserToDeleteRows = false;
            this.dgvModel.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.dgvModel.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvModel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvModel.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvModel.BackgroundColor = System.Drawing.SystemColors.InactiveCaption;
            this.dgvModel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvModel.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dgvModel.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvModel.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvModel.ColumnHeadersHeight = 40;
            this.dgvModel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvModel.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colModelID,
            this.colRinksNo,
            this.colTAT,
            this.colProductionLT,
            this.colShipmentLT});
            this.dgvModel.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvModel.Location = new System.Drawing.Point(0, 21);
            this.dgvModel.Name = "dgvModel";
            this.dgvModel.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgvModel.Size = new System.Drawing.Size(370, 398);
            this.dgvModel.TabIndex = 7;
            this.dgvModel.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvModel_CellDoubleClick);
            // 
            // colModelID
            // 
            this.colModelID.HeaderText = "MODEL ID";
            this.colModelID.Name = "colModelID";
            this.colModelID.Visible = false;
            // 
            // colRinksNo
            // 
            this.colRinksNo.HeaderText = "RINKS NO";
            this.colRinksNo.Name = "colRinksNo";
            // 
            // colTAT
            // 
            this.colTAT.HeaderText = "TAT";
            this.colTAT.Name = "colTAT";
            // 
            // colProductionLT
            // 
            this.colProductionLT.HeaderText = "Production LT";
            this.colProductionLT.Name = "colProductionLT";
            // 
            // colShipmentLT
            // 
            this.colShipmentLT.HeaderText = "Shipment LT";
            this.colShipmentLT.Name = "colShipmentLT";
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSearch.Location = new System.Drawing.Point(269, 1);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(100, 20);
            this.txtSearch.TabIndex = 57;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(225, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 58;
            this.label1.Text = "Search :";
            // 
            // FrmModelMaintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 420);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvModel);
            this.Name = "FrmModelMaintenance";
            this.Text = "Model Maintenance";
            this.Load += new System.EventHandler(this.FrmModelMaintenance_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvModel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModelID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRinksNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTAT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductionLT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colShipmentLT;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label1;
    }
}