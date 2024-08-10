using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAutomation.Tools
{
    public class DataGridView : System.Windows.Forms.DataGridView
    {
        public DataGridView()
        {
            Type dgvType = this.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered",
                  BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(this, true, null);
        }
    }
}
