using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Models
{
   public class LoginResponse
    {
        public int UserID { get; set; }
        public int RoleID { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public int UserStatus { get; set; }
        public bool LoginStatus { get; set; }
    }
}
