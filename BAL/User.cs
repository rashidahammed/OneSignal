using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.Models;
using DAL.Entity;

namespace BAL
{
   public class UserC
    {
        public LoginResponse UserLogin(string LoginID,string Password)
        {
            LoginResponse response = new LoginResponse() { LoginStatus=false};
            try
            {
               var result = new OneSignalEntities().sp_UserLogin(LoginID, Password).FirstOrDefault();
                if (result != null)
                {
                    response.LoginStatus = true;
                    response.UserName = result.UserName;
                    response.FullName = result.FullName;
                    response.RoleID = result.RoleID;
                    response.UserID = result.UserID;
                }
                
            }
            catch(Exception ex)
            {
                return response;
            }
            return response;
        }
    }
}
