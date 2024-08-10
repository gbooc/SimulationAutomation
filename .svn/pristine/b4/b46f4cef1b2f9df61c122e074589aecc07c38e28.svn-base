using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAutomation.Models.Maintenance
{
    public class CalendarModel : LogModel
    {
        public virtual string Type { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual string DayName{ get; set; }
        public virtual string ShiftACode { get; set; }
        public virtual string ShiftAWorkScheme { get; set; }
        public virtual Nullable<decimal> ShiftAHours { get; set; }
        public virtual string ShiftBCode { get; set; }
        public virtual string ShiftBWorkScheme { get; set; }
        public virtual Nullable<decimal> ShiftBHours { get; set; }
        public virtual string ShiftCCode { get; set; }
        public virtual string ShiftCWorkScheme { get; set; }
        public virtual Nullable<decimal> ShiftCHours { get; set; }
    }

    public class CalendaList : BaseModel
    {
        public CalendaList()
        {
            this.List = new List<CalendarModel>();
        }

        public List<CalendarModel> List;
    }

    public class Holiday
    {
        public DateTime hldy_date { get; set; }
        public string hldy_name{ get; set; }
        public string hldy_type { get; set; }
    }

    public class HolidayList : BaseModel
    {
        public HolidayList()
        {
            this.List = new List<Holiday>();
        }

        public List<Holiday> List;
    }
}
