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
    public partial class frmCalendar : Form
    {
        public frmCalendar()
        {
            InitializeComponent();
        }
        DateTime _dateNow = DateTime.Now;
        private string _type = "RT1";

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

        //private void Load_Calendar_Days(int number_of_Days, Nullable<DateTime> day = null/*, bool isIdentifier = false*/, bool isHoliday = false, string holidayName = "", string holidayType = "", string code = "", string workScheme = "", string type = "")
        //private void Load_Calendar_Days(int number_of_Days, Nullable<DateTime> day = null, bool isHoliday = false, string holidayName = "", string holidayType = "", string shiftCount = "")
        private void Load_Calendar_Days(int number_of_Days, KeyValuePair<Nullable<DateTime>, string> dateAndStatus, bool isHoliday = false, string holidayName = "", string holidayType = "", string shiftCount = "", string workScheme = "")
        {
            for (int i = 0; i < number_of_Days; i++)
            {
                //this.flowLayoutPanel1.Controls.Add(new UserControl_Form.Maintenance.Calendar.uscButton(day, /*isIdentifier,*/ isHoliday, holidayName, holidayType, code, workScheme, type));
                var button = new UserControl_Form.Maintenance.Calendar.uscButton(dateAndStatus, isHoliday, holidayName, holidayType, shiftCount, workScheme);
                if (dateAndStatus.Key.HasValue)
                {                    //button.Name = string.Format("btn{0}", dateAndStatus.Key.Value.Day.ToString());
                    button.Tag = dateAndStatus.Key.Value;
                    button.Controls["roundButton1"].Click += new System.EventHandler(this.uscButton_Click); 
                }

                this.flowLayoutPanel1.Controls.Add(button);
            }
        }

        private void Load_Blank_Days(DayOfWeek dayOfWeek)
        {
            switch (dayOfWeek)
            {
                case DayOfWeek.Monday:
                    this.Load_Calendar_Days(1, new KeyValuePair<DateTime?, string>(null, string.Empty));
                    break;
                case DayOfWeek.Tuesday:
                    this.Load_Calendar_Days(2, new KeyValuePair<DateTime?, string>(null, string.Empty));
                    break;
                case DayOfWeek.Wednesday:
                    this.Load_Calendar_Days(3, new KeyValuePair<DateTime?, string>(null, string.Empty));
                    break;
                case DayOfWeek.Thursday:
                    this.Load_Calendar_Days(4, new KeyValuePair<DateTime?, string>(null, string.Empty));
                    break;
                case DayOfWeek.Friday:
                    this.Load_Calendar_Days(5, new KeyValuePair<DateTime?, string>(null, string.Empty));
                    break;
                case DayOfWeek.Saturday:
                    this.Load_Calendar_Days(6, new KeyValuePair<DateTime?, string>(null, string.Empty));
                    break;
            }
        }

        private void Populate_Calendar(DateTime firstDayOfMonth, DateTime lastDayOfMonth, string type)
        {
            this.btnPrevious.Tag = firstDayOfMonth;
            this.btnNext.Tag = lastDayOfMonth;
            this.flowLayoutPanel1.Controls.Clear();

            this.Load_Blank_Days(firstDayOfMonth.DayOfWeek);

            Models.Maintenance.CalendaList calendarResult = new Controllers.Maintenance.CalendarController().GetCalendar(firstDayOfMonth.Date, lastDayOfMonth.Date, type);

            if (!string.IsNullOrEmpty(calendarResult.Error))
            {
                Util.MessageUtil.ShowError("Please refresh.. Cannot load workScheme\n" + calendarResult.Error, Util.Messages.ERROR_TITLE);
            }

            Models.Maintenance.HolidayList holidayResult = new Controllers.Maintenance.CalendarController().GetHoliday(firstDayOfMonth.Date, lastDayOfMonth.Date);

            if (!string.IsNullOrEmpty(holidayResult.Error))
            {
                Util.MessageUtil.ShowError("Please refresh.. Cannot load holiday\n" + calendarResult.Error, Util.Messages.ERROR_TITLE);
            }

            for (int i = firstDayOfMonth.Day; lastDayOfMonth.Day >= i; i++)
            {
                DateTime date = firstDayOfMonth.AddDays(i - 1);

                var calendar = calendarResult.List.Where(x => x.Date.Date.Equals(date.Date)).FirstOrDefault();
                var holiday = holidayResult.List.Where(x => x.hldy_date.Date.Equals(date.Date)).FirstOrDefault();
                bool isHoliday = false;
                string holidayName = string.Empty;
                string holidayType = string.Empty;
                
                if (holiday != null)
                {
                    isHoliday = true;
                    holidayName = holiday.hldy_name;
                    holidayType = holiday.hldy_type;
                }

                if (calendar != null)
                {

                    string shiftCount = "1 shift";
                    
                    string workScheme = string.Format("[{0} Hrs]", Math.Round(Convert.ToDecimal(calendar.ShiftAHours), 1));

                    if (!string.IsNullOrEmpty(calendar.ShiftBCode))
                    {
                        shiftCount = "2 shift";
                        workScheme = string.Format("[{0} Hrs] [{1} Hrs]", Math.Round(Convert.ToDecimal(calendar.ShiftAHours), 1), Math.Round(Convert.ToDecimal(calendar.ShiftBHours), 1));
                    }

                    if (!string.IsNullOrEmpty(calendar.ShiftCCode))
                    {
                        shiftCount = "3 shift";
                        workScheme = string.Format("[{0} Hrs] [{1} Hrs] [{2} Hrs]", Math.Round(Convert.ToDecimal(calendar.ShiftAHours), 1), Math.Round(Convert.ToDecimal(calendar.ShiftBHours), 1), Math.Round(Convert.ToDecimal(calendar.ShiftCHours), 1));
                    }
                    //string workScheme = string.Format("[{0}] [{1}] [{2}]", Math.Round(Convert.ToDecimal(calendar.ShiftAHours), 1), Math.Round(Convert.ToDecimal(calendar.ShiftBHours), 1), Math.Round(Convert.ToDecimal(calendar.ShiftCHours), 1));
                    //this.Load_Calendar_Days(1, date, true, isHoliday, holidayName, holidayType, calendar.ShiftACode, calendar.ShiftAWorkScheme, type);

                    //this.Load_Calendar_Days(1, date, isHoliday, holidayName, holidayType, shiftCount);
                    this.Load_Calendar_Days(1, new KeyValuePair<Nullable<DateTime>, string>(date, type), isHoliday, holidayName, holidayType, shiftCount, workScheme);
                }
                else
                    this.Load_Calendar_Days(1, new KeyValuePair<Nullable<DateTime>, string>(date, type), isHoliday, holidayName, holidayType);
                //this.Load_Calendar_Days(1, date,false, isHoliday, holidayName, holidayType);
            }
            this.lblTitle.Text = firstDayOfMonth.ToString(Util.GlobalConstants.MONTHYEAR);
        }

        private void frmRinksCalendar_Load(object sender, EventArgs e)
        {
            DateTime firstDayOfMonth = new DateTime(this._dateNow.Year, this._dateNow.Month, 1);
            DateTime lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

            this.Populate_Calendar(firstDayOfMonth, lastDayOfMonth, this._type);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            this._dateNow = this._dateNow.AddMonths(1);
            DateTime firstDayOfMonth = new DateTime(this._dateNow.Year, this._dateNow.Month, 1);
            DateTime lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

            this.Populate_Calendar(firstDayOfMonth, lastDayOfMonth, this._type);
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            this._dateNow = this._dateNow.AddMonths(-1);
            DateTime firstDayOfMonth = new DateTime(this._dateNow.Year, this._dateNow.Month, 1);
            DateTime lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

            this.Populate_Calendar(firstDayOfMonth, lastDayOfMonth, this._type);
        }

        private void btnSetupCalendar_Click(object sender, EventArgs e)
        {
            DateTime firstDayOfMonth = (DateTime)this.btnPrevious.Tag;
            DateTime lastDayOfMonth = (DateTime)this.btnNext.Tag;

            var dialogForm = new frmSetupCalendar(firstDayOfMonth, lastDayOfMonth, this._type);
            dialogForm.StartPosition = FormStartPosition.Manual;

            //Get the actual position of the MDI Parent form in screen coords
            Point screenLocation = Parent.PointToScreen(Parent.Location);

            //Adjust for position of the MDI Child form in screen coords
            screenLocation.X += Location.X;
            screenLocation.Y += Location.Y;

            dialogForm.Location = new Point(screenLocation.X + (Width - dialogForm.Width) / 2,
                                            screenLocation.Y + (Height - dialogForm.Height) / 2);

            dialogForm.ShowDialog(this);
            if (dialogForm.DialogResult == DialogResult.OK)
            {
                this.Populate_Calendar(firstDayOfMonth, lastDayOfMonth, this._type);
            }
        }
        private void uscButton_Click(object sender, EventArgs e)
        {
            var uscButton = sender as UserControl_Form.Maintenance.Calendar.uscButton;

            DateTime firstDayOfMonth = (DateTime)uscButton.Tag;// this.btnPrevious.Tag;
            DateTime lastDayOfMonth = (DateTime)uscButton.Tag;

            var dialogForm = new frmSetupCalendar(firstDayOfMonth, lastDayOfMonth, this._type);
            dialogForm.StartPosition = FormStartPosition.Manual;

            //Get the actual position of the MDI Parent form in screen coords
            Point screenLocation = Parent.PointToScreen(Parent.Location);

            //Adjust for position of the MDI Child form in screen coords
            screenLocation.X += Location.X;
            screenLocation.Y += Location.Y;

            dialogForm.Location = new Point(screenLocation.X + (Width - dialogForm.Width) / 2,
                                            screenLocation.Y + (Height - dialogForm.Height) / 2);

            dialogForm.ShowDialog(this);
            if (dialogForm.DialogResult == DialogResult.OK)
            {
                this.Populate_Calendar(firstDayOfMonth, lastDayOfMonth, this._type);
            }
        }
    }
}
