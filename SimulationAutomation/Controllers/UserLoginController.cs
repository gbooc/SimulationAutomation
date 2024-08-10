using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAutomation.Controllers
{
    public class UserLoginController
    {
        public UserLoginController()
        {

        }

        public bool IsLogin(string username)
        {
            try
            {
                var login = new EntitiesServices.EntitiesManager.Tables.UserRightsManager().UserRights().Where(x => x.username.Equals(username) && x.status.Equals("Active")).FirstOrDefault();

                if (login != null)
                {
                    Program.userLog = login.FullName;
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
