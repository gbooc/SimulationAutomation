using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimulationAutomation.Views
{
    public partial class MDIMain : Form
    {
        private int childFormNumber = 0;

        public MDIMain()
        {
            InitializeComponent();
        }
        
        public void OpenChildForm(Form childForm, FormWindowState windowState = FormWindowState.Normal)
        {
            this.Cursor = Cursors.WaitCursor;

            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == childForm.GetType())
                {
                    form.Focus();
                    this.Cursor = DefaultCursor;
                    return;
                }
            }
            childForm.MdiParent = this;
            childForm.Show();
            childForm.WindowState = windowState;
            this.Cursor = DefaultCursor;
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void customerOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.OpenChildForm(new Views.FrmCustomerOrder());
        }

        private void modelMaintenanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.OpenChildForm(new Views.Maintenance.FrmModelMaintenance());
        }

        private void modelSimulationProcessesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.OpenChildForm(new Views.Maintenance.FrmModelLeadTimeProcessesMaintenance());
        }

        private void shippingLeadtimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Views.Maintenance.FrmShippingLeadtime().ShowDialog();
        }

        private void calendarMaintenanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.OpenChildForm(new Views.Maintenance.Calendar.frmCalendar());
            //new Views.Maintenance.Calendar.frmCalendar().ShowDialog();
        }

        public void customerOrderHistory(object sender, EventArgs e)
        {
            //this.OpenChildForm(new Views.Maintenance.FrmCustomerOrderHistory());
            this.OpenChildForm(new Views.Maintenance.FrmModelLeadTimeProcessesMaintenance());
        }

        private void performanceReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.OpenChildForm(new Views.Reports.frmPerformanceReport());
        }

        private void simulationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.OpenChildForm(new Views.Transaction.POSimulation.frmSimulatePO());
        }

        private void capacitySetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.OpenChildForm(new Views.Maintenance.frmCapacity());
        }

        private void pOVsMGLNPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.OpenChildForm(new Views.Maintenance.frmMGLNPComparison());
        }

        private void MDIMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void comparisonDemandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.OpenChildForm(new Views.Reports.frm_ComparisonDates());
        }

        private void rT1CrititalPartsSimulationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.OpenChildForm(new Views.Reports.frm_CriticalPartsSimulation());
        }

        private void transactionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
