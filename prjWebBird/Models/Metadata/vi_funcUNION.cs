using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace prjWebBird.Models
{

    [MetadataType(typeof(vi_funcUNION_metadata))]
    public partial class vi_funcUNION
    {
        private partial class vi_funcUNION_metadata
        {
            public int rowid { get; set; }
            public string userno { get; set; }

            public string username { get; set; }
            public string mtel { get; set; }
            public string mconn { get; set; }
            public string memail { get; set; }
            public string mno { get; set; }

            [DisplayName("名字")]
            public string mname { get; set; }
            public string mid { get; set; }
            public string mid2 { get; set; }

            [DisplayName("品種")]
            public string mspecies { get; set; }

            [DisplayName("色系")]
            public string mcolor { get; set; }
            public string mfeature { get; set; }

            [DisplayName("位置")]
            public string maddr { get; set; }
            public string maddr_detail { get; set; }
            public Nullable<decimal> lat { get; set; }
            public Nullable<decimal> lng { get; set; }
            [DisplayName("資料日期")]
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
            public Nullable<System.DateTime> mdate { get; set; }

            [DisplayName("最後修改時間")]
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd HH:mm}")]
            public Nullable<System.DateTime> mdate_edit { get; set; }

            [DisplayName("創建時間")]
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyyMMddHHmmfff}")]
            public Nullable<System.DateTime> mdate_create { get; set; }
            public string mremarks { get; set; }
            public string mstate { get; set; }
            public Nullable<bool> edit { get; set; }

            [DisplayName("狀態")]
            public string statename { get; set; }
            public Nullable<System.DateTime> mtime { get; set; }

            [DisplayName("腳環號碼")]
            public string show_id { get; set; }

            
           
        }
    }
}