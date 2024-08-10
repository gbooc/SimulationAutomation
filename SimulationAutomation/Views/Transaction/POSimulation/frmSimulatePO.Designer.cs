namespace SimulationAutomation.Views.Transaction.POSimulation
{
    partial class frmSimulatePO
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
            PBarcoma.WindowsTools.DataGridViewButton dataGridViewButton1 = new PBarcoma.WindowsTools.DataGridViewButton();
            PBarcoma.WindowsTools.DataGridViewButton dataGridViewButton2 = new PBarcoma.WindowsTools.DataGridViewButton();
            PBarcoma.WindowsTools.DataGridViewButton dataGridViewButton3 = new PBarcoma.WindowsTools.DataGridViewButton();
            PBarcoma.WindowsTools.DataGridViewButton dataGridViewButton4 = new PBarcoma.WindowsTools.DataGridViewButton();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnSimulatePO = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnExportToExcel = new System.Windows.Forms.Button();
            this.dataGridView1 = new PBarcoma.WindowsTools.PBDataGridView();
            this.bgw_Export_To_Excel = new System.ComponentModel.BackgroundWorker();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.colNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPONo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSuffix = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPOBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDeliveryDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRemarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colShipDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colShipmentQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSimulatePO
            // 
            this.btnSimulatePO.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSimulatePO.Location = new System.Drawing.Point(0, 464);
            this.btnSimulatePO.Name = "btnSimulatePO";
            this.btnSimulatePO.Size = new System.Drawing.Size(724, 38);
            this.btnSimulatePO.TabIndex = 1;
            this.btnSimulatePO.Text = "Simulate PO";
            this.btnSimulatePO.UseVisualStyleBackColor = true;
            this.btnSimulatePO.Click += new System.EventHandler(this.btnSimulatePO_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportToExcel.Enabled = false;
            this.btnExportToExcel.Location = new System.Drawing.Point(0, 502);
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(724, 38);
            this.btnExportToExcel.TabIndex = 2;
            this.btnExportToExcel.Text = "Export To Excel";
            this.btnExportToExcel.UseVisualStyleBackColor = true;
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNo,
            this.colPONo,
            this.colItemNo,
            this.colSuffix,
            this.colModel,
            this.colOrder,
            this.colPOBalance,
            this.colDeliveryDate,
            this.colRemarks,
            this.colShipDate,
            this.colShipmentQty,
            this.colStatus});
            dataGridViewButton1.AutoSizeColumnMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewButton1.DisplayButton = true;
            dataGridViewButton1.HeaderText = "Delete";
            dataGridViewButton1.Name = "Delete";
            dataGridViewButton1.Text = "Delete";
            dataGridViewButton1.Width = 30;
            this.dataGridView1.DataGridViewButton1 = dataGridViewButton1;
            dataGridViewButton2.AutoSizeColumnMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.NotSet;
            dataGridViewButton2.DisplayButton = false;
            dataGridViewButton2.HeaderText = null;
            dataGridViewButton2.Name = null;
            dataGridViewButton2.Text = null;
            dataGridViewButton2.Width = 30;
            this.dataGridView1.DataGridViewButton2 = dataGridViewButton2;
            dataGridViewButton3.AutoSizeColumnMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.NotSet;
            dataGridViewButton3.DisplayButton = false;
            dataGridViewButton3.HeaderText = null;
            dataGridViewButton3.Name = null;
            dataGridViewButton3.Text = null;
            dataGridViewButton3.Width = 30;
            this.dataGridView1.DataGridViewButton3 = dataGridViewButton3;
            dataGridViewButton4.AutoSizeColumnMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.NotSet;
            dataGridViewButton4.DisplayButton = false;
            dataGridViewButton4.HeaderText = null;
            dataGridViewButton4.Name = null;
            dataGridViewButton4.Text = null;
            dataGridViewButton4.Width = 30;
            this.dataGridView1.DataGridViewButton4 = dataGridViewButton4;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.IsMoneyOnly = false;
            this.dataGridView1.IsNumberOnly = false;
            this.dataGridView1.LabelCount = null;
            this.dataGridView1.Location = new System.Drawing.Point(0, 23);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 25;
            this.dataGridView1.Size = new System.Drawing.Size(724, 441);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.DataGridViewButtonClick1 += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_DataGridViewButtonClick1);
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            // 
            // bgw_Export_To_Excel
            // 
            this.bgw_Export_To_Excel.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_Export_To_Excel_DoWork);
            this.bgw_Export_To_Excel.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgw_Export_To_Excel_RunWorkerCompleted);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Location = new System.Drawing.Point(623, 1);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(100, 20);
            this.txtSearch.TabIndex = 57;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(580, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 58;
            this.label1.Text = "Search :";
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(0, 0);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(75, 23);
            this.btnUp.TabIndex = 59;
            this.btnUp.Text = "Up";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(74, 0);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(75, 23);
            this.btnDown.TabIndex = 60;
            this.btnDown.Text = "Down";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // colNo
            // 
            this.colNo.HeaderText = "No";
            this.colNo.Name = "colNo";
            this.colNo.ReadOnly = true;
            // 
            // colPONo
            // 
            this.colPONo.HeaderText = "PO No";
            this.colPONo.Name = "colPONo";
            this.colPONo.ReadOnly = true;
            this.colPONo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colPONo.Width = 75;
            // 
            // colItemNo
            // 
            this.colItemNo.HeaderText = "Item No";
            this.colItemNo.Name = "colItemNo";
            this.colItemNo.ReadOnly = true;
            this.colItemNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colItemNo.Width = 75;
            // 
            // colSuffix
            // 
            this.colSuffix.HeaderText = "Suffix";
            this.colSuffix.Name = "colSuffix";
            this.colSuffix.ReadOnly = true;
            // 
            // colModel
            // 
            this.colModel.HeaderText = "Model";
            this.colModel.Name = "colModel";
            this.colModel.ReadOnly = true;
            this.colModel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colOrder
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colOrder.DefaultCellStyle = dataGridViewCellStyle3;
            this.colOrder.HeaderText = "Order";
            this.colOrder.Name = "colOrder";
            this.colOrder.ReadOnly = true;
            this.colOrder.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colOrder.Width = 60;
            // 
            // colPOBalance
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "#,##0";
            this.colPOBalance.DefaultCellStyle = dataGridViewCellStyle4;
            this.colPOBalance.HeaderText = "PO Balance";
            this.colPOBalance.Name = "colPOBalance";
            this.colPOBalance.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colPOBalance.Width = 55;
            // 
            // colDeliveryDate
            // 
            this.colDeliveryDate.HeaderText = "Delivery Date";
            this.colDeliveryDate.Name = "colDeliveryDate";
            this.colDeliveryDate.ReadOnly = true;
            this.colDeliveryDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colDeliveryDate.Width = 60;
            // 
            // colRemarks
            // 
            this.colRemarks.HeaderText = "Remarks";
            this.colRemarks.Name = "colRemarks";
            this.colRemarks.ReadOnly = true;
            this.colRemarks.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colShipDate
            // 
            this.colShipDate.HeaderText = "Ship Date";
            this.colShipDate.Name = "colShipDate";
            this.colShipDate.ReadOnly = true;
            this.colShipDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colShipDate.Visible = false;
            this.colShipDate.Width = 60;
            // 
            // colShipmentQty
            // 
            this.colShipmentQty.HeaderText = "Ship Qty";
            this.colShipmentQty.Name = "colShipmentQty";
            this.colShipmentQty.ReadOnly = true;
            this.colShipmentQty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colShipmentQty.Visible = false;
            this.colShipmentQty.Width = 55;
            // 
            // colStatus
            // 
            this.colStatus.HeaderText = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            this.colStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colStatus.Width = 55;
            // 
            // frmSimulatePO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 539);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExportToExcel);
            this.Controls.Add(this.btnSimulatePO);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frmSimulatePO";
            this.Text = "Simulate PO";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSimulatePO_FormClosing);
            this.Load += new System.EventHandler(this.frmSimulatePO_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PBarcoma.WindowsTools.PBDataGridView dataGridView1;
        private System.Windows.Forms.Button btnSimulatePO;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnExportToExcel;
        private System.ComponentModel.BackgroundWorker bgw_Export_To_Excel;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPONo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSuffix;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPOBalance;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeliveryDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRemarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn colShipDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colShipmentQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
    }
}