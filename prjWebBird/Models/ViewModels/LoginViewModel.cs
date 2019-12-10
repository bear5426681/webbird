using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace prjWebBird.Models.ViewModels
{
    public class LoginViewModel
    {

        [Required]
        [Display(Name = "登入帳號")]
        public string UserNo { get; set; }
        [Required]
        [Display(Name = "登入密碼")]
        public string Password { get; set; }
        [Display(Name = "記住我")]
        public bool Remember { get; set; }

    }
}