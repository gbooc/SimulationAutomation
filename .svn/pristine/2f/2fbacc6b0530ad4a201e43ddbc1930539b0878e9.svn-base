using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimulationAutomation.Views.Reports
{
    public partial class frm_ComparisonDemand1 : Form
    {
        public frm_ComparisonDemand1(DataTable datable,string DateUploaded)
        {
            InitializeComponent();

            this.lblDateUploaded.Text = DateUploaded;
            this.dgvUploaded1.DataSource = datable;

            dgvUploaded1.Columns["model_name"].Frozen = true;
            dgvUploaded1.Columns["suffix"].Frozen = true;
        }
    }
}
