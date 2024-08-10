using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAutomation.EntitiesServices.EntitiesManager.Tables
{
    public class CalendarManager
    {
        public CalendarManager()
        {
            this._dbContext = new DB.dbRT1_SADataContext();
        }

        private readonly DB.dbRT1_SADataContext _dbContext;

        public List<DB.Calendar> Calendar()
        {
            try
            {
                var data = this._dbContext.Calendars.Where(x => x.Status.Equals("Active")).ToList();
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //public DB.Capacity FindById(int iNDEX)
        //{
        //    try
        //    {
        //        return this.Capacity()
        //                   .Where(x => x.INDEX == iNDEX)
        //                   .FirstOrDefault();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        public void SaveCalendar(DB.Calendar calendar)
        {
            try
            {
                this._dbContext.Calendars.InsertOnSubmit(calendar);
                this._dbContext.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteCalendar(DB.Calendar calendar)
        {
            try
            {
                DB.Calendar updateCalendar = this.Calendar()
                                         .Where(x => x.Type.Equals(calendar.Type)
                                                  && x.Date.Date.Equals(calendar.Date.Date)
                                                  && x.Status.Equals(calendar.Status))
                                         .FirstOrDefault();

                updateCalendar.Action = "deleted";
                updateCalendar.Status = "deleted";
                updateCalendar.DateModified = calendar.DateModified;
                updateCalendar.UserLog = calendar.UserLog;
                this._dbContext.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateCalendar(DB.Calendar calendar)
        {
            try
            {
                var updateCalendar = this.Calendar()
                                         .Where(x => x.Type.Equals(calendar.Type)
                                                  && x.Date.Date.Equals(calendar.Date.Date)
                                                  && x.Status.Equals(calendar.Status))
                                         .FirstOrDefault();

                updateCalendar.DayName = calendar.DayName;
                updateCalendar.ShiftACode = calendar.ShiftACode;
                updateCalendar.ShiftAWorkScheme = calendar.ShiftAWorkScheme;
                updateCalendar.ShiftAHours = calendar.ShiftAHours;
                updateCalendar.ShiftBCode = calendar.ShiftBCode;
                updateCalendar.ShiftBWorkScheme = calendar.ShiftBWorkScheme;
                updateCalendar.ShiftBHours = calendar.ShiftBHours;
                updateCalendar.ShiftCCode = calendar.ShiftCCode;
                updateCalendar.ShiftCWorkScheme = calendar.ShiftCWorkScheme;
                updateCalendar.ShiftCHours = calendar.ShiftCHours;
                updateCalendar.Remarks = calendar.Remarks;
                updateCalendar.Action = calendar.Action;
                updateCalendar.DateModified = calendar.DateModified;
                updateCalendar.UserLog = calendar.UserLog;
                this._dbContext.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
