using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using prjWebBird.Models;
using Securitys;
using UpLoadPic;

namespace prjWebBird.Controllers
{

    [RequireHttps]
    public class HomeController : Controller
    {
        webbirdEntities db = new webbirdEntities();
        public ActionResult Index()
        {
            var fly = db.vi_funcUNION.OrderByDescending(m => m.mtime).ToList();
           
            return View(fly);
            
        }

        public ActionResult picIndex()
        {


            //test abc = new test();
            //abc.abc = db.z_func_fly.ToList();
            var picindex = db.vi_funcUNION.OrderByDescending(m=>m.mtime).ToList();
            
            //if (picindex.Where(m => m.mno.Substring(0, 1) == "S").Count() > 1)
            //{
            //    picindex=picindex.Where(m => m.mno.Substring(0, 1) == "S"&& )
            //}

            return View(picindex);

        }

        public ActionResult Wellcome()
        {
            var picindex = db.vi_funcUNION.OrderByDescending(m => m.mtime).ToList();

           return View(picindex);
            
        }

        public ActionResult Edit()
        {
           
            var userinfo = db.z_bas_user.Where(m => m.mno == UserAccount.UserNo).FirstOrDefault();

            return View(userinfo);
        }


        [HttpPost]
        public ActionResult Edit(z_bas_user user)
        {
           

            return RedirectToAction("picIndex");
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}