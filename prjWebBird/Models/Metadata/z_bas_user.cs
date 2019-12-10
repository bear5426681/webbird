using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompareAttribute = System.Web.Mvc.CompareAttribute;

namespace prjWebBird.Models
{
    
    [MetadataType(typeof(z_bas_user_metadata))]
    public partial class z_bas_user
    {
        public partial class z_bas_user_metadata
        {
            [EditableAttribute(false)]
            public int rowid { get; set; }

            [Display(Name = "會員編號", AutoGenerateField = false)]
            [EditableAttribute(false)]
            public string mno { get; set; }
            public Nullable<System.DateTime> mdate { get; set; }

            [DisplayName("帳號")]
            [Required(ErrorMessage = "帳號不可為空白！")]
            [StringLength(20,MinimumLength =4,ErrorMessage ="帳號長度需介於4-20字元")]
            public string mid { get; set; }

            [DisplayName("密碼")]
            [Required(ErrorMessage = "密碼不可為空白！")]
            public string mpassword { get; set; }

            [DisplayName("稱呼")]
            public string mname { get; set; }
           
            [DisplayName("E-mail")]
            [Required(ErrorMessage = "email不可為空白！")]
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "email")]
            [EmailAddress(ErrorMessage ="email格式錯誤")]
            public string memail { get; set; }

            [DisplayName("電話")]
            public string mtel { get; set; }

            [DisplayName("其他聯絡方法")]
            public string mconn { get; set; }

            [DisplayName("地址")]
            public string maddr { get; set; }

            [DisplayName("會員類型")]
            [EditableAttribute(false)]
            public string mtype { get; set; }

            //[DisplayName("密碼")]
            //[Compare("mpassword", ErrorMessage = "兩次輸入密碼不一致！")]
            //[Required(ErrorMessage = "請再次輸入密碼！")]
            //public string mpasswordCheck { get; set; }
        }
        }
    
}