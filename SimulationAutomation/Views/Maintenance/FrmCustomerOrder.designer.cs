namespace SimulationAutomation.Views
{
    partial class FrmCustomerOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCustomerOrder));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnImport = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExport = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnGetData = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnClearAll = new System.Windows.Forms.ToolStripButton();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.dtpMonthUploadedInto = new System.Windows.Forms.DateTimePicker();
            this.dtpDateUploaded = new System.Windows.Forms.DateTimePicker();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.cmbDestination = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.btnSearch = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvCustomerOrder = new System.Windows.Forms.DataGridView();
            this.colRinksNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRinsPONo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDestination = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsFc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPOQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colETD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRemarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMRinks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMPO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMQTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMEtd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSuffix = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvUploadSummary = new System.Windows.Forms.DataGridView();
            this.colUpdMonth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUpdDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUpdVersion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnSearchGrid = new System.Windows.Forms.Button();
            this.txtSearchBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblFileName = new System.Windows.Forms.Label();
            this.lblMEtd = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblExcelEtd = new System.Windows.Forms.Label();
            this.txtGoodModel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNoGoodModel = new System.Windows.Forms.Label();
            this.lblExcelRinks = new System.Windows.Forms.Label();
            this.lblMQTY = new System.Windows.Forms.Label();
            this.txtFcCount = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblMPo = new System.Windows.Forms.Label();
            this.lblMRinks = new System.Windows.Forms.Label();
            this.lblExcelPo = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblExcelQTY = new System.Windows.Forms.Label();
            this.cbCustomerType = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomerOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUploadSummary)).BeginInit();
            this.SuspendLayout();
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.WorkerReportsProgress = true;
            this.backgroundWorker2.WorkerSupportsCancellation = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnImport,
            this.toolStripSeparator2,
            this.btnExport,
            this.toolStripSeparator1,
            this.btnGetData,
            this.btnSave,
            this.btnClearAll});
            this.toolStrip1.Location = new System.Drawing.Point(0, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(942, 25);
            this.toolStrip1.TabIndex = 56;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // btnImport
            // 
            this.btnImport.Image = ((System.Drawing.Image)(resources.GetObject("btnImport.Image")));
            this.btnImport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(64, 22);
            this.btnImport.Text = "Import";
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnExport
            // 
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(63, 22);
            this.btnExport.Text = "Export";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnGetData
            // 
            this.btnGetData.Image = ((System.Drawing.Image)(resources.GetObject("btnGetData.Image")));
            this.btnGetData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(76, 22);
            this.btnGetData.Text = "Get Data";
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(53, 22);
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClearAll
            // 
            this.btnClearAll.Image = ((System.Drawing.Image)(resources.GetObject("btnClearAll.Image")));
            this.btnClearAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(69, 22);
            this.btnClearAll.Text = "Clear All";
            this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
            // 
            // txtPath
            // 
            this.txtPath.Enabled = false;
            this.txtPath.Location = new System.Drawing.Point(632, 3);
            this.txtPath.Multiline = true;
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(196, 10);
            this.txtPath.TabIndex = 71;
            this.txtPath.Visible = false;
            // 
            // dtpMonthUploadedInto
            // 
            this.dtpMonthUploadedInto.CustomFormat = "";
            this.dtpMonthUploadedInto.Location = new System.Drawing.Point(54, 0);
            this.dtpMonthUploadedInto.Name = "dtpMonthUploadedInto";
            this.dtpMonthUploadedInto.Size = new System.Drawing.Size(142, 22);
            this.dtpMonthUploadedInto.TabIndex = 59;
            // 
            // dtpDateUploaded
            // 
            this.dtpDateUploaded.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDateUploaded.CustomFormat = "MM/dd/yyyy";
            this.dtpDateUploaded.Enabled = false;
            this.dtpDateUploaded.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateUploaded.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateUploaded.Location = new System.Drawing.Point(847, 1);
            this.dtpDateUploaded.Name = "dtpDateUploaded";
            this.dtpDateUploaded.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtpDateUploaded.Size = new System.Drawing.Size(85, 22);
            this.dtpDateUploaded.TabIndex = 58;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripLabel4,
            this.cmbDestination,
            this.btnSearch});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(942, 25);
            this.toolStrip2.TabIndex = 57;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel1.AutoSize = false;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(180, 22);
            this.toolStripLabel1.Text = "Date Uploaded: ";
            this.toolStripLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbDestination
            // 
            this.cmbDestination.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbDestination.AutoSize = false;
            this.cmbDestination.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDestination.Items.AddRange(new object[] {
            "JPN",
            "HK-SH",
            "HK-US",
            "HK( TVN )"});
            this.cmbDestination.Name = "cmbDestination";
            this.cmbDestination.Size = new System.Drawing.Size(70, 23);
            this.cmbDestination.Visible = false;
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.AutoSize = false;
            this.toolStripLabel4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(190, 22);
            this.toolStripLabel4.Text = "Month:";
            this.toolStripLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSearch
            // 
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(150, 22);
            this.btnSearch.Text = "All Uploaded By Month";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click_1);
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.dgvCustomerOrder);
            this.panel1.Controls.Add(this.dgvUploadSummary);
            this.panel1.Controls.Add(this.BtnSearchGrid);
            this.panel1.Controls.Add(this.txtSearchBox);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblFileName);
            this.panel1.Controls.Add(this.lblMEtd);
            this.panel1.Controls.Add(this.lblMessage);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.txtPath);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lblExcelEtd);
            this.panel1.Controls.Add(this.txtGoodModel);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtNoGoodModel);
            this.panel1.Controls.Add(this.lblExcelRinks);
            this.panel1.Controls.Add(this.lblMQTY);
            this.panel1.Controls.Add(this.txtFcCount);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.lblMPo);
            this.panel1.Controls.Add(this.lblMRinks);
            this.panel1.Controls.Add(this.lblExcelPo);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.lblExcelQTY);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(942, 505);
            this.panel1.TabIndex = 60;
            // 
            // dgvCustomerOrder
            // 
            this.dgvCustomerOrder.AllowUserToAddRows = false;
            this.dgvCustomerOrder.AllowUserToDeleteRows = false;
            this.dgvCustomerOrder.AllowUserToResizeRows = false;
            this.dgvCustomerOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCustomerOrder.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCustomerOrder.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvCustomerOrder.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvCustomerOrder.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dgvCustomerOrder.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCustomerOrder.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dgvCustomerOrder.ColumnHeadersHeight = 35;
            this.dgvCustomerOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCustomerOrder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colRinksNo,
            this.colRinsPONo,
            this.colDestination,
            this.colIsFc,
            this.colPOQty,
            this.colETD,
            this.colRemarks,
            this.colMRinks,
            this.colMPO,
            this.colMQTY,
            this.colMEtd,
            this.colSuffix});
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCustomerOrder.DefaultCellStyle = dataGridViewCellStyle16;
            this.dgvCustomerOrder.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvCustomerOrder.Location = new System.Drawing.Point(234, 112);
            this.dgvCustomerOrder.Name = "dgvCustomerOrder";
            this.dgvCustomerOrder.ReadOnly = true;
            this.dgvCustomerOrder.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgvCustomerOrder.Size = new System.Drawing.Size(696, 361);
            this.dgvCustomerOrder.TabIndex = 7;
            this.dgvCustomerOrder.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvCustomerOrder_RowPostPaint);
            this.dgvCustomerOrder.SelectionChanged += new System.EventHandler(this.dgvCustomerOrder_SelectionChanged);
            // 
            // colRinksNo
            // 
            this.colRinksNo.FillWeight = 200.1539F;
            this.colRinksNo.HeaderText = "RINKS NO";
            this.colRinksNo.Name = "colRinksNo";
            this.colRinksNo.ReadOnly = true;
            this.colRinksNo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colRinsPONo
            // 
            this.colRinsPONo.FillWeight = 285.2371F;
            this.colRinsPONo.HeaderText = "RINS PO NO";
            this.colRinsPONo.Name = "colRinsPONo";
            this.colRinsPONo.ReadOnly = true;
            this.colRinsPONo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colDestination
            // 
            this.colDestination.FillWeight = 147.017F;
            this.colDestination.HeaderText = "Customer Destination";
            this.colDestination.Name = "colDestination";
            this.colDestination.ReadOnly = true;
            this.colDestination.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colIsFc
            // 
            this.colIsFc.FillWeight = 73.67658F;
            this.colIsFc.HeaderText = "FC";
            this.colIsFc.Name = "colIsFc";
            this.colIsFc.ReadOnly = true;
            this.colIsFc.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colIsFc.Visible = false;
            // 
            // colPOQty
            // 
            dataGridViewCellStyle14.Format = "N0";
            dataGridViewCellStyle14.NullValue = null;
            this.colPOQty.DefaultCellStyle = dataGridViewCellStyle14;
            this.colPOQty.FillWeight = 25.78257F;
            this.colPOQty.HeaderText = "PO QTY";
            this.colPOQty.Name = "colPOQty";
            this.colPOQty.ReadOnly = true;
            this.colPOQty.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colETD
            // 
            dataGridViewCellStyle15.Format = "d";
            dataGridViewCellStyle15.NullValue = null;
            this.colETD.DefaultCellStyle = dataGridViewCellStyle15;
            this.colETD.FillWeight = 34.18782F;
            this.colETD.HeaderText = "ETD:RIMP";
            this.colETD.Name = "colETD";
            this.colETD.ReadOnly = true;
            this.colETD.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colRemarks
            // 
            this.colRemarks.FillWeight = 28.82262F;
            this.colRemarks.HeaderText = "Remarks";
            this.colRemarks.Name = "colRemarks";
            this.colRemarks.ReadOnly = true;
            this.colRemarks.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colMRinks
            // 
            this.colMRinks.HeaderText = "MRinks";
            this.colMRinks.Name = "colMRinks";
            this.colMRinks.ReadOnly = true;
            this.colMRinks.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colMRinks.Visible = false;
            // 
            // colMPO
            // 
            this.colMPO.HeaderText = "MPO";
            this.colMPO.Name = "colMPO";
            this.colMPO.ReadOnly = true;
            this.colMPO.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colMPO.Visible = false;
            // 
            // colMQTY
            // 
            this.colMQTY.HeaderText = "MQty";
            this.colMQTY.Name = "colMQTY";
            this.colMQTY.ReadOnly = true;
            this.colMQTY.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colMQTY.Visible = false;
            // 
            // colMEtd
            // 
            this.colMEtd.HeaderText = "MEtd";
            this.colMEtd.Name = "colMEtd";
            this.colMEtd.ReadOnly = true;
            this.colMEtd.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colMEtd.Visible = false;
            // 
            // colSuffix
            // 
            this.colSuffix.HeaderText = "Suffix";
            this.colSuffix.Name = "colSuffix";
            this.colSuffix.ReadOnly = true;
            this.colSuffix.Visible = false;
            // 
            // dgvUploadSummary
            // 
            this.dgvUploadSummary.AllowUserToAddRows = false;
            this.dgvUploadSummary.AllowUserToDeleteRows = false;
            this.dgvUploadSummary.AllowUserToResizeRows = false;
            this.dgvUploadSummary.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUploadSummary.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUploadSummary.BackgroundColor = System.Drawing.SystemColors.Menu;
            this.dgvUploadSummary.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvUploadSummary.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dgvUploadSummary.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUploadSummary.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle17;
            this.dgvUploadSummary.ColumnHeadersHeight = 35;
            this.dgvUploadSummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvUploadSummary.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colUpdMonth,
            this.colUpdDate,
            this.colUpdVersion});
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUploadSummary.DefaultCellStyle = dataGridViewCellStyle18;
            this.dgvUploadSummary.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvUploadSummary.Location = new System.Drawing.Point(9, 112);
            this.dgvUploadSummary.Name = "dgvUploadSummary";
            this.dgvUploadSummary.ReadOnly = true;
            this.dgvUploadSummary.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgvUploadSummary.RowHeadersVisible = false;
            this.dgvUploadSummary.Size = new System.Drawing.Size(217, 361);
            this.dgvUploadSummary.TabIndex = 63;
            this.dgvUploadSummary.SelectionChanged += new System.EventHandler(this.dgvUploadSummary_SelectionChanged);
            // 
            // colUpdMonth
            // 
            this.colUpdMonth.FillWeight = 111.9289F;
            this.colUpdMonth.HeaderText = "Month";
            this.colUpdMonth.Name = "colUpdMonth";
            this.colUpdMonth.ReadOnly = true;
            // 
            // colUpdDate
            // 
            this.colUpdDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colUpdDate.FillWeight = 111.9289F;
            this.colUpdDate.HeaderText = "Date";
            this.colUpdDate.Name = "colUpdDate";
            this.colUpdDate.ReadOnly = true;
            // 
            // colUpdVersion
            // 
            this.colUpdVersion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colUpdVersion.FillWeight = 76.14214F;
            this.colUpdVersion.HeaderText = "# Of Items";
            this.colUpdVersion.Name = "colUpdVersion";
            this.colUpdVersion.ReadOnly = true;
            this.colUpdVersion.Width = 50;
            // 
            // BtnSearchGrid
            // 
            this.BtnSearchGrid.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.BtnSearchGrid.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnSearchGrid.Location = new System.Drawing.Point(845, 80);
            this.BtnSearchGrid.Name = "BtnSearchGrid";
            this.BtnSearchGrid.Size = new System.Drawing.Size(75, 23);
            this.BtnSearchGrid.TabIndex = 90;
            this.BtnSearchGrid.Text = "Search";
            this.BtnSearchGrid.UseVisualStyleBackColor = false;
            this.BtnSearchGrid.Click += new System.EventHandler(this.BtnSearchGrid_Click);
            // 
            // txtSearchBox
            // 
            this.txtSearchBox.Location = new System.Drawing.Point(678, 81);
            this.txtSearchBox.Name = "txtSearchBox";
            this.txtSearchBox.Size = new System.Drawing.Size(161, 22);
            this.txtSearchBox.TabIndex = 89;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(385, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 14);
            this.label8.TabIndex = 88;
            this.label8.Text = "ETD:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(292, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 14);
            this.label7.TabIndex = 87;
            this.label7.Text = "QTY:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(188, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 14);
            this.label4.TabIndex = 86;
            this.label4.Text = "PO:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(82, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 14);
            this.label2.TabIndex = 85;
            this.label2.Text = "Rinks #:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.BackColor = System.Drawing.Color.Transparent;
            this.lblFileName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblFileName.Location = new System.Drawing.Point(304, 480);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(54, 14);
            this.lblFileName.TabIndex = 82;
            this.lblFileName.Text = "Filename";
            this.lblFileName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblFileName.Visible = false;
            // 
            // lblMEtd
            // 
            this.lblMEtd.AutoSize = true;
            this.lblMEtd.BackColor = System.Drawing.Color.Transparent;
            this.lblMEtd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMEtd.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMEtd.ForeColor = System.Drawing.Color.Black;
            this.lblMEtd.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblMEtd.Location = new System.Drawing.Point(388, 84);
            this.lblMEtd.Name = "lblMEtd";
            this.lblMEtd.Size = new System.Drawing.Size(16, 16);
            this.lblMEtd.TabIndex = 84;
            this.lblMEtd.Text = "0";
            this.lblMEtd.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Tempus Sans ITC", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.Color.Red;
            this.lblMessage.Location = new System.Drawing.Point(416, 779);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(11, 16);
            this.lblMessage.TabIndex = 58;
            this.lblMessage.Text = ".";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(243, 478);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 16);
            this.label11.TabIndex = 70;
            this.label11.Text = "Filename:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(88, 477);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 14);
            this.label1.TabIndex = 61;
            this.label1.Text = "NG:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(10, 477);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 14);
            this.label3.TabIndex = 6;
            this.label3.Text = "Good:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblExcelEtd
            // 
            this.lblExcelEtd.AutoSize = true;
            this.lblExcelEtd.BackColor = System.Drawing.Color.Transparent;
            this.lblExcelEtd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblExcelEtd.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExcelEtd.ForeColor = System.Drawing.Color.Black;
            this.lblExcelEtd.Location = new System.Drawing.Point(388, 57);
            this.lblExcelEtd.Name = "lblExcelEtd";
            this.lblExcelEtd.Size = new System.Drawing.Size(16, 16);
            this.lblExcelEtd.TabIndex = 83;
            this.lblExcelEtd.Text = "0";
            this.lblExcelEtd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtGoodModel
            // 
            this.txtGoodModel.AutoSize = true;
            this.txtGoodModel.BackColor = System.Drawing.Color.Transparent;
            this.txtGoodModel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.txtGoodModel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGoodModel.ForeColor = System.Drawing.Color.Green;
            this.txtGoodModel.Location = new System.Drawing.Point(59, 476);
            this.txtGoodModel.Name = "txtGoodModel";
            this.txtGoodModel.Size = new System.Drawing.Size(15, 16);
            this.txtGoodModel.TabIndex = 60;
            this.txtGoodModel.Text = "0";
            this.txtGoodModel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(169, 477);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 14);
            this.label6.TabIndex = 63;
            this.label6.Text = "FC:";
            // 
            // txtNoGoodModel
            // 
            this.txtNoGoodModel.AutoSize = true;
            this.txtNoGoodModel.BackColor = System.Drawing.Color.Transparent;
            this.txtNoGoodModel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.txtNoGoodModel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoGoodModel.ForeColor = System.Drawing.Color.DarkRed;
            this.txtNoGoodModel.Location = new System.Drawing.Point(130, 477);
            this.txtNoGoodModel.Name = "txtNoGoodModel";
            this.txtNoGoodModel.Size = new System.Drawing.Size(15, 16);
            this.txtNoGoodModel.TabIndex = 62;
            this.txtNoGoodModel.Text = "0";
            this.txtNoGoodModel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblExcelRinks
            // 
            this.lblExcelRinks.AutoSize = true;
            this.lblExcelRinks.BackColor = System.Drawing.Color.Transparent;
            this.lblExcelRinks.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblExcelRinks.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExcelRinks.ForeColor = System.Drawing.Color.Black;
            this.lblExcelRinks.Location = new System.Drawing.Point(91, 57);
            this.lblExcelRinks.Name = "lblExcelRinks";
            this.lblExcelRinks.Size = new System.Drawing.Size(16, 16);
            this.lblExcelRinks.TabIndex = 76;
            this.lblExcelRinks.Text = "0";
            this.lblExcelRinks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMQTY
            // 
            this.lblMQTY.AutoSize = true;
            this.lblMQTY.BackColor = System.Drawing.Color.Transparent;
            this.lblMQTY.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMQTY.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMQTY.ForeColor = System.Drawing.Color.Black;
            this.lblMQTY.Location = new System.Drawing.Point(292, 84);
            this.lblMQTY.Name = "lblMQTY";
            this.lblMQTY.Size = new System.Drawing.Size(16, 16);
            this.lblMQTY.TabIndex = 81;
            this.lblMQTY.Text = "0";
            this.lblMQTY.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtFcCount
            // 
            this.txtFcCount.AutoSize = true;
            this.txtFcCount.BackColor = System.Drawing.Color.Transparent;
            this.txtFcCount.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.txtFcCount.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFcCount.ForeColor = System.Drawing.Color.Black;
            this.txtFcCount.Location = new System.Drawing.Point(211, 476);
            this.txtFcCount.Name = "txtFcCount";
            this.txtFcCount.Size = new System.Drawing.Size(15, 16);
            this.txtFcCount.TabIndex = 64;
            this.txtFcCount.Text = "0";
            this.txtFcCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(10, 57);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 20);
            this.label10.TabIndex = 60;
            this.label10.Text = "Excel";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMPo
            // 
            this.lblMPo.AutoSize = true;
            this.lblMPo.BackColor = System.Drawing.Color.Transparent;
            this.lblMPo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMPo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMPo.ForeColor = System.Drawing.Color.Black;
            this.lblMPo.Location = new System.Drawing.Point(188, 84);
            this.lblMPo.Name = "lblMPo";
            this.lblMPo.Size = new System.Drawing.Size(16, 16);
            this.lblMPo.TabIndex = 77;
            this.lblMPo.Text = "0";
            this.lblMPo.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblMRinks
            // 
            this.lblMRinks.AutoSize = true;
            this.lblMRinks.BackColor = System.Drawing.Color.Transparent;
            this.lblMRinks.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMRinks.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMRinks.ForeColor = System.Drawing.Color.Black;
            this.lblMRinks.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblMRinks.Location = new System.Drawing.Point(91, 84);
            this.lblMRinks.Name = "lblMRinks";
            this.lblMRinks.Size = new System.Drawing.Size(16, 16);
            this.lblMRinks.TabIndex = 80;
            this.lblMRinks.Text = "0";
            this.lblMRinks.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblExcelPo
            // 
            this.lblExcelPo.AutoSize = true;
            this.lblExcelPo.BackColor = System.Drawing.Color.Transparent;
            this.lblExcelPo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblExcelPo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExcelPo.ForeColor = System.Drawing.Color.Black;
            this.lblExcelPo.Location = new System.Drawing.Point(188, 57);
            this.lblExcelPo.Name = "lblExcelPo";
            this.lblExcelPo.Size = new System.Drawing.Size(16, 16);
            this.lblExcelPo.TabIndex = 73;
            this.lblExcelPo.Text = "0";
            this.lblExcelPo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(10, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 21);
            this.label5.TabIndex = 67;
            this.label5.Text = "MFSODP";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblExcelQTY
            // 
            this.lblExcelQTY.AutoSize = true;
            this.lblExcelQTY.BackColor = System.Drawing.Color.Transparent;
            this.lblExcelQTY.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblExcelQTY.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExcelQTY.ForeColor = System.Drawing.Color.Black;
            this.lblExcelQTY.Location = new System.Drawing.Point(292, 57);
            this.lblExcelQTY.Name = "lblExcelQTY";
            this.lblExcelQTY.Size = new System.Drawing.Size(16, 16);
            this.lblExcelQTY.TabIndex = 74;
            this.lblExcelQTY.Text = "0";
            this.lblExcelQTY.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbCustomerType
            // 
            this.cbCustomerType.FormattingEnabled = true;
            this.cbCustomerType.Location = new System.Drawing.Point(448, 6);
            this.cbCustomerType.Name = "cbCustomerType";
            this.cbCustomerType.Size = new System.Drawing.Size(173, 22);
            this.cbCustomerType.TabIndex = 61;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(361, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 14);
            this.label9.TabIndex = 62;
            this.label9.Text = "Format Type:";
            // 
            // FrmCustomerOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(942, 530);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cbCustomerType);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.dtpMonthUploadedInto);
            this.Controls.Add(this.dtpDateUploaded);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip2);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmCustomerOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer Order";
            this.Load += new System.EventHandler(this.FrmCustomerOrder_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomerOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUploadSummary)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnImport;
        private System.Windows.Forms.ToolStripButton btnExport;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.DateTimePicker dtpMonthUploadedInto;
        private System.Windows.Forms.DateTimePicker dtpDateUploaded;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripButton btnSearch;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.ToolStripButton btnGetData;
        private System.Windows.Forms.ToolStripButton btnClearAll;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.Label lblMEtd;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblExcelEtd;
        private System.Windows.Forms.Label txtGoodModel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label txtNoGoodModel;
        private System.Windows.Forms.Label lblExcelRinks;
        private System.Windows.Forms.Label lblMQTY;
        private System.Windows.Forms.Label txtFcCount;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblMPo;
        private System.Windows.Forms.Label lblMRinks;
        private System.Windows.Forms.Label lblExcelPo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblExcelQTY;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSearchBox;
        private System.Windows.Forms.Button BtnSearchGrid;
        private System.Windows.Forms.DataGridView dgvCustomerOrder;
        private System.Windows.Forms.DataGridView dgvUploadSummary;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUpdMonth;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUpdDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUpdVersion;
        private System.Windows.Forms.ToolStripComboBox cmbDestination;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRinksNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRinsPONo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDestination;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIsFc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPOQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colETD;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRemarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMRinks;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMPO;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMQTY;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMEtd;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSuffix;
        private System.Windows.Forms.ComboBox cbCustomerType;
        private System.Windows.Forms.Label label9;

    }
}