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
    public partial class frm_ComparisonDemand2 : Form
    {
        public frm_ComparisonDemand2(DataTable datable,string DateUploaded)
        {
            InitializeComponent();

            this.dgvUploaded2.DataSource = datable;
            this.lblDateUploaded2.Text = DateUploaded;

            dgvUploaded2.Columns["model_name"].Frozen = true;
            dgvUploaded2.Columns["suffix"].Frozen = true;
        }
    }
}
