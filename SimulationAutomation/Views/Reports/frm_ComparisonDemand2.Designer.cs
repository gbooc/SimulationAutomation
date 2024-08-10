namespace SimulationAutomation.Views.Reports
{
    partial class frm_ComparisonDemand2
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
            this.dgvUploaded2 = new System.Windows.Forms.DataGridView();
            this.lblDateUploaded2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUploaded2)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvUploaded2
            // 
            this.dgvUploaded2.BackgroundColor = System.Drawing.SystemColors.Menu;
            this.dgvUploaded2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUploaded2.Location = new System.Drawing.Point(12, 43);
            this.dgvUploaded2.Name = "dgvUploaded2";
            this.dgvUploaded2.Size = new System.Drawing.Size(648, 324);
            this.dgvUploaded2.TabIndex = 6;
            // 
            // lblDateUploaded2
            // 
            this.lblDateUploaded2.AutoSize = true;
            this.lblDateUploaded2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateUploaded2.Location = new System.Drawing.Point(97, 6);
            this.lblDateUploaded2.Name = "lblDateUploaded2";
            this.lblDateUploaded2.Size = new System.Drawing.Size(16, 24);
            this.lblDateUploaded2.TabIndex = 9;
            this.lblDateUploaded2.Text = "-";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Date Uploaded:";
            // 
            // frm_ComparisonDemand2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 379);
            this.Controls.Add(this.lblDateUploaded2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvUploaded2);
            this.Name = "frm_ComparisonDemand2";
            this.Text = "frm_ComparisonDemand2";
            ((System.ComponentModel.ISupportInitialize)(this.dgvUploaded2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvUploaded2;
        private System.Windows.Forms.Label lblDateUploaded2;
        private System.Windows.Forms.Label label1;
    }
}