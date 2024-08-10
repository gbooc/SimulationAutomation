using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimulationAutomation.Views.Maintenance.Calendar
{
    public partial class frmSetupCalendar : Form
    {
        public frmSetupCalendar(DateTime dateTimeStart, DateTime dateTimeEnd, string type)
        {
            InitializeComponent();

            this.cmbShiftA.Items.Add(Util.GlobalConstants.HOURS_WORKSCHEME_A);
            this.cmbShiftA.Items.Add(Util.GlobalConstants.HOURS_WORKSCHEME_B);
            this.cmbShiftA.Items.Add(Util.GlobalConstants.HOURS_WORKSCHEME_C);
            this.cmbShiftA.Items.Add(Util.GlobalConstants.HOURS_WORKSCHEME_D);
            //this.cmbShiftA.Items.Add(Util.GlobalConstants.HOURS_WORKSCHEME_E);

            this.cmbShiftB.Items.Add(Util.GlobalConstants.HOURS_WORKSCHEME_A);
            this.cmbShiftB.Items.Add(Util.GlobalConstants.HOURS_WORKSCHEME_B);
            this.cmbShiftB.Items.Add(Util.GlobalConstants.HOURS_WORKSCHEME_C);
            this.cmbShiftB.Items.Add(Util.GlobalConstants.HOURS_WORKSCHEME_D);
            //this.cmbShiftB.Items.Add(Util.GlobalConstants.HOURS_WORKSCHEME_E);

            this.cmbShiftC.Items.Add(Util.GlobalConstants.HOURS_WORKSCHEME_A);
            //this.cmbShiftC.Items.Add(Util.GlobalConstants.HOURS_WORKSCHEME_B);
            //this.cmbShiftC.Items.Add(Util.GlobalConstants.HOURS_WORKSCHEME_C);
            //this.cmbShiftC.Items.Add(Util.GlobalConstants.HOURS_WORKSCHEME_D);
            //this.cmbShiftC.Items.Add(Util.GlobalConstants.HOURS_WORKSCHEME_E);

            this._dateTimeStart = dateTimeStart;
            this._dateTimeEnd = dateTimeEnd;
            this._type = type;
        }

        private string _type = string.Empty;
        private DateTime _dateTimeStart;
        private DateTime _dateTimeEnd;

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Escape:
                    this.Close();
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private string ShiftCode(string hoursWorkScheme)
        {
            switch (hoursWorkScheme)
            {
                case Util.GlobalConstants.HOURS_WORKSCHEME_A:
                    return Util.GlobalConstants.HOURS_CODE_A;
                case Util.GlobalConstants.HOURS_WORKSCHEME_B:
                    return Util.GlobalConstants.HOURS_CODE_B;
                case Util.GlobalConstants.HOURS_WORKSCHEME_C:
                    return Util.GlobalConstants.HOURS_CODE_C;
                case Util.GlobalConstants.HOURS_WORKSCHEME_D:
                    return Util.GlobalConstants.HOURS_CODE_D;
                case Util.GlobalConstants.HOURS_WORKSCHEME_E:
                    return Util.GlobalConstants.HOURS_CODE_E;
            }
            return string.Empty;
        }

        private decimal ShiftHours(string hoursWorkScheme)
        {
            switch (hoursWorkScheme)
            {
                case Util.GlobalConstants.HOURS_WORKSCHEME_A:
                    return 8;
                case Util.GlobalConstants.HOURS_WORKSCHEME_B:
                    return 9.6m;
                case Util.GlobalConstants.HOURS_WORKSCHEME_C:
                    return 10;
                case Util.GlobalConstants.HOURS_WORKSCHEME_D:
                    return 12;
                case Util.GlobalConstants.HOURS_WORKSCHEME_E:
                    return 0;
            }
            return 0;
        }

        private void btnProcessCalendarSetup_Click(object sender, EventArgs e)
        {
            try
            {
                for (DateTime date = this.dtpFrom.Value.Date; date.Date <= this.dtpTo.Value.Date; date = date.AddDays(1).Date)
                {
                    if (!this.chckIncludeSaturday.Checked && date.DayOfWeek.ToString() == Util.GlobalConstants.SATURDAY)
                    {
                        continue;
                    }
                    else if (!this.chckIncludeSunday.Checked && date.DayOfWeek.ToString() == Util.GlobalConstants.SUNDAY)
                    {
                        continue;
                    }
                    else
                    {
                        Models.Maintenance.CalendarModel calendar = new Models.Maintenance.CalendarModel();
                        calendar.Type = this._type;
                        calendar.Date = date.Date;
                        calendar.DayName = date.DayOfWeek.ToString();

                        calendar.ShiftACode = this.ShiftCode(this.cmbShiftA.Text);
                        calendar.ShiftAWorkScheme = this.cmbShiftA.Text;
                        calendar.ShiftAHours = this.ShiftHours(this.cmbShiftA.Text);

                        if (this.chckShiftB.Checked && this.chckShiftB.Enabled)
                        {
                            calendar.ShiftBCode = this.ShiftCode(this.cmbShiftB.Text);
                            calendar.ShiftBWorkScheme = this.cmbShiftB.Text;
                            calendar.ShiftBHours = this.ShiftHours(this.cmbShiftB.Text);
                        }

                        if (this.chckShiftC.Checked && this.chckShiftC.Enabled)
                        {
                            calendar.ShiftCCode = this.ShiftCode(this.cmbShiftC.Text);
                            calendar.ShiftCWorkScheme = this.cmbShiftC.Text;
                            calendar.ShiftCHours = this.ShiftHours(this.cmbShiftC.Text);
                        }

                        new Controllers.Maintenance.CalendarController().InsertUpdateCalendar(calendar.Type, calendar.Date, calendar.DayName, calendar.ShiftACode, calendar.ShiftAWorkScheme, calendar.ShiftAHours, calendar.ShiftBCode, calendar.ShiftBWorkScheme, calendar.ShiftBHours, calendar.ShiftCCode, calendar.ShiftCWorkScheme, calendar.ShiftCHours, "Active", "added", Program.userLog);
                    }
                }
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                Util.MessageUtil.ShowError(ex.Message, Util.Messages.ERROR_TITLE);
            }
        }

        private void frmSetupCalendar_Load(object sender, EventArgs e)
        {
            this.dtpFrom.MinDate = DateTime.Now.Date;
            this.dtpTo.MinDate = this.dtpFrom.Value.Date;

            this.dtpFrom.Value = (DateTime.Now.Date >= this._dateTimeStart.Date) ? this.dtpFrom.MinDate : this._dateTimeStart.Date;
            this.dtpTo.Value = this._dateTimeEnd.Date;
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            this.dtpTo.MinDate = this.dtpFrom.Value.Date;
        }

        private void chckShiftB_CheckedChanged(object sender, EventArgs e)
        {
            this.cmbShiftB.Enabled = this.chckShiftB.Checked;
            this.chckShiftC.Enabled = this.chckShiftB.Checked;
            this.chckShiftC.Checked = !this.chckShiftB.Checked ? false : this.chckShiftC.Checked;
        }

        private void chckShiftC_CheckedChanged(object sender, EventArgs e)
        {
            this.cmbShiftC.Enabled = this.chckShiftC.Checked;
        }

        private void cmbShiftB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbShiftA.Text == Util.GlobalConstants.HOURS_WORKSCHEME_A && this.cmbShiftB.Text == Util.GlobalConstants.HOURS_WORKSCHEME_A)
            {
                this.chckShiftC.Enabled = true;
            }
            else
            {
                this.chckShiftC.Enabled = false;
            }
            //this.chckShiftC.Checked = (this.cmbShiftA.Text == Util.GlobalConstants.HOURS_WORKSCHEME_A && this.cmbShiftB.Text == Util.GlobalConstants.HOURS_WORKSCHEME_A);
        }

        private void cmbShiftA_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cmbShiftB_SelectedIndexChanged(this.cmbShiftA, e);
        }
    }
}