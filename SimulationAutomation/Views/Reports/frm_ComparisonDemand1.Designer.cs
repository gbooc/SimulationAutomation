namespace SimulationAutomation.Views.Reports
{
    partial class frm_ComparisonDemand1
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
            this.dgvUploaded1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDateUploaded = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUploaded1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvUploaded1
            // 
            this.dgvUploaded1.BackgroundColor = System.Drawing.SystemColors.Menu;
            this.dgvUploaded1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUploaded1.Location = new System.Drawing.Point(8, 45);
            this.dgvUploaded1.Name = "dgvUploaded1";
            this.dgvUploaded1.Size = new System.Drawing.Size(658, 322);
            this.dgvUploaded1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Date Uploaded:";
            // 
            // lblDateUploaded
            // 
            this.lblDateUploaded.AutoSize = true;
            this.lblDateUploaded.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateUploaded.Location = new System.Drawing.Point(97, 11);
            this.lblDateUploaded.Name = "lblDateUploaded";
            this.lblDateUploaded.Size = new System.Drawing.Size(16, 24);
            this.lblDateUploaded.TabIndex = 7;
            this.lblDateUploaded.Text = "-";
            // 
            // frm_ComparisonDemand1
            // 
            this.ClientSize = new System.Drawing.Size(672, 379);
            this.Controls.Add(this.lblDateUploaded);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvUploaded1);
            this.Name = "frm_ComparisonDemand1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)(this.dgvUploaded1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvComparison1;
        private System.Windows.Forms.DataGridView dgvUploaded1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDateUploaded;
    }
}