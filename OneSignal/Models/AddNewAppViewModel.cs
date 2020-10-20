using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OneSignal.Models
{
    public class AddNewAppViewModel
    {
        [Required]
        [Display(Name = "Name")]
        public string name { get; set; }
        [Required]
        [Display(Name = "apns env")]
        public string apns_env { get; set; }
        [Required]
        [Display(Name = "apns p12")]
        public string apns_p12 { get; set; }
        [Required]
        [Display(Name = "apns p12 password")]
        public string apns_p12_password { get; set; }
        [Required]
        [Display(Name = "organization id ")]
        public string organization_id { get; set; }
        [Required]
        [Display(Name = "gcm key")]
        public string gcm_key { get; set; }
        [Required]
        [Display(Name = "site name")]
        public string site_name { get; set; }
    }
}