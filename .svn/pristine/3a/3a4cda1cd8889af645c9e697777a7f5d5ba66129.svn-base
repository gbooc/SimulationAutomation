using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAutomation.Controllers.Maintenance
{
    public class CalendarController
    {
        public CalendarController()
        {
        }

        public void InsertUpdateCalendar(string type, DateTime date, string dayName, string shiftACode, string shiftAWorkScheme, Nullable<decimal> shiftAHours, string shiftBCode, string shiftBWorkScheme, Nullable<decimal> shiftBHours, string shiftCCode, string shiftCWorkScheme, Nullable<decimal> shiftCHours, string status, string action, string userLog)
        {
            try
            {
                new EntitiesServices.EntitiesManager.StoredProcedures.sp_Calendar_InsertUpdate().SP_Calendar_InsertUpdate(type, date.Date, dayName, shiftACode, shiftAWorkScheme, shiftAHours, shiftBCode, shiftBWorkScheme, shiftBHours, shiftCCode, shiftCWorkScheme, shiftCHours, status, action, userLog);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteCalendar(string type, DateTime date, string status, string userLog)
        {
            try
            {
                EntitiesServices.DB.Calendar calendar = new EntitiesServices.DB.Calendar();
                calendar.Type = type;
                calendar.Date = date;
                calendar.Status = "Active";
                calendar.UserLog = userLog;
                new EntitiesServices.EntitiesManager.Tables.CalendarManager().DeleteCalendar(calendar);
                //new EntitiesServices.EntitiesManager.StoredProcedures.sp_Calendar_InsertUpdate().SP_Calendar_InsertUpdate(type, date.Date, dayName, shiftACode, shiftAWorkScheme, shiftAHours, shiftBCode, shiftBWorkScheme, shiftBHours, shiftCCode, shiftCWorkScheme, shiftCHours, status, action, userLog);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public Models.Maintenance.CalendaList GetCalendar(DateTime dateStart, DateTime dateEnd, string type)
        {
            Models.Maintenance.CalendaList result = new Models.Maintenance.CalendaList();
            try
            {
                result.List = new EntitiesServices.EntitiesManager
                                             .Tables
                                             .CalendarManager()
                                             .Calendar()
                                             .Where(x => (x.Date.Date >= dateStart.Date && x.Date.Date <= dateEnd.Date)
                                                       && x.Type == type)
                                             .Select(x => new Models.Maintenance.CalendarModel()
                                             {
                                                 Type = x.Type,
                                                 Date = x.Date,
                                                 DayName = x.DayName,
                                                 ShiftACode = x.ShiftACode,
                                                 ShiftAWorkScheme = x.ShiftAWorkScheme,
                                                 ShiftAHours = x.ShiftAHours,
                                                 ShiftBCode = x.ShiftBCode,
                                                 ShiftBWorkScheme = x.ShiftBWorkScheme,
                                                 ShiftBHours = x.ShiftBHours,
                                                 ShiftCCode = x.ShiftCCode,
                                                 ShiftCWorkScheme = x.ShiftCWorkScheme,
                                                 ShiftCHours = x.ShiftCHours
                                             })
                                             .ToList();
            }
            catch (Exception ex)
            {
                result.Error = ex.Message;
            }
            return result;
        }

        public Models.Maintenance.HolidayList GetHoliday(DateTime from,DateTime to)
        {
            Models.Maintenance.HolidayList result = new Models.Maintenance.HolidayList();
            try
            {
                result.List = new EntitiesServices.EntitiesManager
                                                  .StoredProcedures
                                                  .sp_GetHoliday()
                                                  .SP_getHoliday(from, to)
                                                  .Select(x => new Models.Maintenance.Holiday()
                                                  {
                                                      hldy_date = x.hldy_date,
                                                      hldy_name = x.hldy_name.Trim(),
                                                      hldy_type = x.hldy_type.Trim()
                                                  })
                                                  .ToList();
            }
            catch (Exception ex)
            {
                result.Error = ex.Message;
            }
            return result;
        }
    }
}