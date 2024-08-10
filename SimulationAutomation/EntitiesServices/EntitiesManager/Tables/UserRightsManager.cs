using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAutomation.EntitiesServices.EntitiesManager.Tables
{
    public class UserRightsManager
    {
        public UserRightsManager()
        {
            this._dbContext = new DB.dbRT1_SADataContext();
        }

        private readonly DB.dbRT1_SADataContext _dbContext;

        public List<DB.UserRight> UserRights()
        {
            try
            {
                return this._dbContext.UserRights.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void SaveUserRights(DB.UserRight userRight)
        {
            try
            {
                this._dbContext.UserRights.InsertOnSubmit(userRight);
                this._dbContext.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateUserRights(DB.UserRight userRight)
        {
            try
            {
                var data = this.UserRights().Where(x => x.username.Equals(userRight.username)).FirstOrDefault();
                data.status = data.status;
                this._dbContext.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}