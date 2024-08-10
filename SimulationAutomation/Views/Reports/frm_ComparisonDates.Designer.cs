namespace SimulationAutomation.Views.Reports
{
    partial class frm_ComparisonDates
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
            this.dtpMonthUploadedInto = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.dgvComparisonDate = new SimulationAutomation.Tools.DataGridView();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNoUpload = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComparisonDate)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpMonthUploadedInto
            // 
            this.dtpMonthUploadedInto.CustomFormat = "";
            this.dtpMonthUploadedInto.Location = new System.Drawing.Point(161, 20);
            this.dtpMonthUploadedInto.Name = "dtpMonthUploadedInto";
            this.dtpMonthUploadedInto.Size = new System.Drawing.Size(142, 20);
            this.dtpMonthUploadedInto.TabIndex = 60;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(309, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 61;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvComparisonDate
            // 
            this.dgvComparisonDate.BackgroundColor = System.Drawing.SystemColors.Menu;
            this.dgvComparisonDate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvComparisonDate.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDate,
            this.colNoUpload});
            this.dgvComparisonDate.Location = new System.Drawing.Point(12, 46);
            this.dgvComparisonDate.Name = "dgvComparisonDate";
            this.dgvComparisonDate.Size = new System.Drawing.Size(372, 226);
            this.dgvComparisonDate.TabIndex = 0;
            this.dgvComparisonDate.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvComparisonDate_CellContentClick_1);
            // 
            // colDate
            // 
            this.colDate.HeaderText = "Date";
            this.colDate.Name = "colDate";
            this.colDate.Width = 155;
            // 
            // colNoUpload
            // 
            this.colNoUpload.HeaderText = "Total Uploaded";
            this.colNoUpload.Name = "colNoUpload";
            this.colNoUpload.Width = 120;
            // 
            // frm_ComparisonDates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 284);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dtpMonthUploadedInto);
            this.Controls.Add(this.dgvComparisonDate);
            this.Name = "frm_ComparisonDates";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_ComparisonDates";
            this.Load += new System.EventHandler(this.frm_ComparisonDates_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvComparisonDate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Tools.DataGridView dgvComparisonDate;
        private System.Windows.Forms.DateTimePicker dtpMonthUploadedInto;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNoUpload;
    }
}