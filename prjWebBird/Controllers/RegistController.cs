using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using prjWebBird.Models;
using prjWebBird.Services;


namespace prjWebBird.Controllers
{
    
    public class RegistController : Controller
    {
        webbirdEntities db = new webbirdEntities();
        // GET: Regist
        public ActionResult Regist(MembersRegisterViewModel user )
        {
            MembersRegisterViewModel newuser = new MembersRegisterViewModel();
            

            return View();
        }
    }
}