using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAL.Model
{
   public class UpdateApp
    {
            public string name { get; set; }
            public string apns_env { get; set; }
            public string apns_p12 { get; set; }
            public string apns_p12_password { get; set; }
            public string organization_id { get; set; }
            public string gcm_key { get; set; }
    }
}
