using Securitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DevTemplate.Authorize
{
    /// <summary>
    /// 自定義驗證角色
    /// </sum
    /// mary>
    public class AuthorizeRoles : AuthorizeAttribute
    {
        /// <summary>
        /// 角色代號
        /// </summary>
        public string RoleNo { get; set; }
        /// <summary>
        /// 覆寫 Authorize 設定
        /// </summary>
        /// <param name="httpContext">httpContext</param>
        /// <returns>驗證結果</returns>
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool bln_authorized = false;
            string[] roles = RoleNo.Split(',');
            foreach (string role in roles)
            {
                if (role == UserAccount.UserRole.ToString()) { bln_authorized = true; break; }
            }
            return bln_authorized;
        }
    }
}