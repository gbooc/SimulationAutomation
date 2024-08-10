namespace SimulationAutomation.Views.Reports
{
    partial class frm_ComparisonDemand
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ComparisonDemand));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnComparison = new System.Windows.Forms.ToolStripButton();
            this.dgvAllMonths = new System.Windows.Forms.DataGridView();
            this.dgvComparisons = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllMonths)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComparisons)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnComparison});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(914, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnComparison
            // 
            this.btnComparison.Image = ((System.Drawing.Image)(resources.GetObject("btnComparison.Image")));
            this.btnComparison.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnComparison.Name = "btnComparison";
            this.btnComparison.Size = new System.Drawing.Size(112, 22);
            this.btnComparison.Text = "Generate Report";
            this.btnComparison.Click += new System.EventHandler(this.btnComparison_Click);
            // 
            // dgvAllMonths
            // 
            this.dgvAllMonths.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAllMonths.BackgroundColor = System.Drawing.SystemColors.Menu;
            this.dgvAllMonths.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllMonths.Location = new System.Drawing.Point(17, 238);
            this.dgvAllMonths.Name = "dgvAllMonths";
            this.dgvAllMonths.Size = new System.Drawing.Size(885, 272);
            this.dgvAllMonths.TabIndex = 7;
            this.dgvAllMonths.SelectionChanged += new System.EventHandler(this.dgvAllMonths_SelectionChanged);
            // 
            // dgvComparisons
            // 
            this.dgvComparisons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvComparisons.BackgroundColor = System.Drawing.SystemColors.Menu;
            this.dgvComparisons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvComparisons.Location = new System.Drawing.Point(17, 56);
            this.dgvComparisons.Name = "dgvComparisons";
            this.dgvComparisons.Size = new System.Drawing.Size(885, 135);
            this.dgvComparisons.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 211);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(5, 10, 5, 5);
            this.label1.Size = new System.Drawing.Size(446, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = " All Months Comparison";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frm_ComparisonDemand
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 518);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvComparisons);
            this.Controls.Add(this.dgvAllMonths);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frm_ComparisonDemand";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "POReference";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllMonths)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComparisons)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnComparison;
        private System.Windows.Forms.DataGridView dgvAllMonths;
        private System.Windows.Forms.DataGridView dgvComparisons;
        private System.Windows.Forms.Label label1;
    }
}