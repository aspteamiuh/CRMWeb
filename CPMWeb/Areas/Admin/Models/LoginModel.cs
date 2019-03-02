using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CPMWeb.Areas.Admin.Models
{
    public class LoginModel
    {[Required(ErrorMessage = "Mời nhập vào user name")]
        public string UserName { set; get; }

        [Required(ErrorMessage = "Mời nhập vào Password")]
        public string Password { set; get; }

        
        public bool RememberMe { set; get; }
     }
}