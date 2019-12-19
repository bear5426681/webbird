using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace prjWebBird.Models
{

    [MetadataType(typeof(z_func_fly_metadata))]
    public partial class z_func_fly
    {
        private partial class z_func_fly_metadata
        {
            [DisplayName("rowid")]
            [Required()]
            public int rowid { get; set; }

            [DisplayName("用戶編號")]
            public string user_no { get; set; }

            [DisplayName("飛失編號")]
            public string mno { get; set; }

            [DisplayName("名字")]
            [Required(ErrorMessage = "呼名不可為空白！")]
            public string mname { get; set; }

            [DisplayName("腳環號")]
            public string mid { get; set; }

            [DisplayName("腳環號（額外）")]
            public string mid2 { get; set; }

            [DisplayName("腳環號碼")]
            public string show_id { get; set; }

            [DisplayName("品種")]
            [Required(ErrorMessage = "品種不可為空白！")]
            public string mspecies { get; set; }

            [DisplayName("色系")]
            public string mcolor { get; set; }

            [DisplayName("特徵")]
            public string mfeature { get; set; }

            [DisplayName("飛失地區")]
            [Required(ErrorMessage = "飛失位置不可為空白！")]
            public string maddr { get; set; }

            [DisplayName("飛失地址")]
            [Required(ErrorMessage = "詳細位置不可為空白！")]
            public string maddr_detail { get; set; }

            [DisplayName("位置細節")]
            public string maddr_content { get; set; }

            [DisplayName("經度")]
            public decimal lat { get; set; }

            [DisplayName("緯度")]
            public decimal lng { get; set; }

            [DisplayName("飛失日期")]
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
            public Nullable<System.DateTime> mdate { get; set; }

            [DisplayName("飛失時間")]
            public Nullable<System.DateTime> mtime { get; set; }

            [DisplayName("最後修改時間")]
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd HH:mm}")]
            public System.DateTime mdate_edit { get; set; }

            [DisplayName("備註")]
            public string mremarks { get; set; }

            [DisplayName("狀態")]
            public string mstate { get; set; }

            [DisplayName("可否編輯")]
            public Nullable<bool> edit { get; set; }
        }
    }
}