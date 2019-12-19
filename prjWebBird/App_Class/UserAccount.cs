using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Securitys
{
    public static class UserAccount
    {
        private static string _UserNo = "";
        private static string _UserName = "";
        private static enUserRole _UserRole = enUserRole.None;
        private static bool _IsLogin = false;

        public static string UserNo { get { return _UserNo; } set { _UserNo = value; } }
        public static string UserName { get { return _UserName; } set { _UserName = value; } }
        public static enUserRole UserRole { get { return _UserRole; } set { _UserRole = value; } }
        public static bool IsLogin { get { return _IsLogin; } set { _IsLogin = value; } }
        public static string UserPassword
        {
            get { return (HttpContext.Current.Session["UserPassword"] is null) ? "" : HttpContext.Current.Session["UserPassword"].ToString(); }
            set { HttpContext.Current.Session["UserPassword"] = value; }
        }

        public static string mno
        {
            get { return (HttpContext.Current.Session["mno"] is null) ? "" : HttpContext.Current.Session["mno"].ToString(); }
            set { HttpContext.Current.Session["mno"] = value; }
        }
       

        public static void LogIn(string sUserNo , string sUserName , enUserRole enRole,string smno)
        {
            UserNo = sUserNo;
            UserName = sUserName;
            UserRole = enRole;
            mno = smno;
            IsLogin = true;
        }

        public static void LogOut()
        {
            UserNo = "";
            UserName = "";
            UserRole = enUserRole.None;
            mno = "";
            IsLogin = false;
        }
    }

    /// <summary>
    /// 使用者角色
    /// </summary>
    public enum enUserRole
    {
        /// <summary>
        /// 管理者
        /// </summary>
        Admin = 0,
        /// <summary>
        /// 使用者
        /// </summary>
        User = 1,
        /// <summary>
        /// 飛失用戶
        /// </summary>
        FlyUser = 2,
        /// <summary>
        /// 拾獲用戶
        /// </summary>
        CatchUser = 3,
        /// <summary>
        /// 未定義
        /// </summary>
        None = 4
    }
}