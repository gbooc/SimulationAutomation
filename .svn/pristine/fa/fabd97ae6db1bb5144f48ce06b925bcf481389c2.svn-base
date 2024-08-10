using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimulationAutomation.UserControl_Form.Maintenance.Calendar
{
    public partial class uscButton : UserControl
    {
        //public uscButton(Nullable<DateTime> date,/* bool isIdentifier = false,*/ bool isHoliday = false, string holidayName = "", string holidayType = ""/*, string workSchemeCode = "", string workScheme = "", string type = ""*/)
        public uscButton(KeyValuePair<Nullable<DateTime>, string> dateAndStatus, bool isHoliday = false, string holidayName = "", string holidayType = "", string shiftCount = "", string workScheme = "")
        {
            InitializeComponent();

            if (dateAndStatus.Key.HasValue)
            {
                if (!string.IsNullOrEmpty(shiftCount))
                {
                    btnIdentifier.ContextMenuStrip = this.contextMenuStrip1;
                    roundButton1.ContextMenuStrip = this.contextMenuStrip1;
                    label1.ContextMenuStrip = this.contextMenuStrip1;
                    this.ContextMenuStrip = this.contextMenuStrip1;

                    //this.toolTipHoliday.SetToolTip(this.roundButton1, string.Format("{0} {1}",holidayName,);
                    //this.toolTipHoliday.ToolTipIcon = ToolTipIcon.Info;
                    //this.toolTipHoliday.ToolTipTitle = holidayType;

                }
                this.Name = string.Format("btn{0}", dateAndStatus.Key.Value.Day.ToString());
                this.roundButton1.Text = dateAndStatus.Key.Value.Day.ToString();
                this.roundButton1.Tag = dateAndStatus.Key.Value.Date;
                this.BorderStyle = (dateAndStatus.Key.Value.Date == DateTime.Now.Date) ? BorderStyle.FixedSingle : BorderStyle.None;
                this.label1.Text = shiftCount;

                this.toolTipHoliday.SetToolTip(this.roundButton1, string.Format("{0} {1}", holidayName, workScheme));               
                this.toolTipHoliday.ToolTipIcon = ToolTipIcon.Info;
                this.toolTipHoliday.ToolTipTitle = string.IsNullOrEmpty(holidayType) ? "WorkScheme" : holidayType;

                this.roundButton1.BackColor = isHoliday ? Color.ForestGreen : Color.White;
                this.roundButton1.ForeColor = dateAndStatus.Key.Value.DayOfWeek.ToString() == Util.GlobalConstants.SUNDAY ? Color.Red : dateAndStatus.Key.Value.DayOfWeek.ToString() == Util.GlobalConstants.SATURDAY ? Color.Blue : Color.Black;
                //this._date = dateAndStatus.Key.Value;
                this._dateAndStatus = dateAndStatus;
            }
        }

        private KeyValuePair<Nullable<DateTime>, string> _dateAndStatus;

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this._dateAndStatus.Key.HasValue)
            {
              //  new Controllers.Maintenance.CalendarController().DeleteCalendar(this._dateAndStatus.Value, this._dateAndStatus.Key.Value.Date, "Active", Program.userLog);
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this._dateAndStatus.Key.HasValue)
            {
                  new Controllers.Maintenance.CalendarController().DeleteCalendar(this._dateAndStatus.Value, this._dateAndStatus.Key.Value.Date, "deleted", Program.userLog);
                  this.label1.Text = string.Empty;
            }
        }
    }
}
