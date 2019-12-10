using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using prjWebBird.Models;

namespace prjWebBird.Controllers
{
    
    public class FlyController : Controller
    {

        webbirdEntities db = new webbirdEntities();
        // GET: Fly
        public ActionResult Index2()
        {

            var fly = db.z_func_fly.ToList();
            return View(fly);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Create2()
        {
            return View();
        }
    }
}