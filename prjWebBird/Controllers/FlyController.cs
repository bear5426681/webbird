using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using prjWebBird.Models;
using prjWebBird.Models.ViewModels;
using Securitys;

namespace prjWebBird.Controllers
{
    
    public class FlyController : Controller
    {

        webbirdEntities db = new webbirdEntities();
        // GET: Fly
        public ActionResult Index()
        {

            var fly = db.z_func_fly.ToList();
            
            return View(fly);
        }
        public ActionResult picIndex()
        {
            
            
            //test abc = new test();
            //abc.abc = db.z_func_fly.ToList();
            var picindex = db.vi_user_fly.ToList();
            
            return View(picindex);
        }

        public ActionResult Create()
        {
           
            ViewBag.state = new SelectList(db.z_sys_state.Where(m=>m.fa_no == "sta2f").ToList());
            ViewData["mstate"] = db.z_sys_state.Where(m => m.fa_no == "sta2f").ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(z_func_fly _Fly, string connmname, string connect, string tel)
        {
            z_func_fly fly = new z_func_fly();
            var _id = UserAccount.UserNo;
            z_bas_user user = db.z_bas_user.Where(m => m.mid == _id).FirstOrDefault();
            if (UserAccount.IsLogin == false)
            {                   
                user.mconn = connect;
                user.mtel = tel;
                user.mdate = DateTime.Now;
                db.z_bas_user.Add(user);
                db.SaveChanges();
                //fly.user_no = db.z_bas_user.Where(m => m.mid == userid).FirstOrDefault().mno;
            }
            else
            {
                fly = _Fly;
                fly.user_no = db.z_bas_user.Where(m => m.mid == _id).FirstOrDefault().mno;
                //db.z_bas_user.Where(m => m.mno == fly.user_no).FirstOrDefault().mtel = tel;
                //db.z_bas_user.Where(m => m.mno == fly.user_no).FirstOrDefault().mconn = connect;
                //db.z_bas_user.Where(m => m.mno == fly.user_no).FirstOrDefault().mname = mname;
                user.mtel = tel;
                user.mconn = connect;
                user.mname = connmname;
                db.SaveChanges();
                //UserAccount.UserNo
            }
    
            fly.show_id = showID(_Fly.mid, _Fly.mid2);
            fly.mdate_edit = DateTime.Now;
            //DateTime date = DateTime.Parse(_Fly.mtime.ToString().Substring(0, 9));
            fly.mdate =_Fly.mtime;
            if (_Fly.mstate == "sta2f3" || _Fly.mstate == "sta2f2")
            {
                fly.edit = false;
            }
            else
                fly.edit = true;

            db.z_func_fly.Add(fly);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
      



        public string showID(string mid1,string mid2)
        {
            var result = "";
            if (mid1 != null)
            {
                result += mid1.Substring(0, 2);
                for (int i = 1; i <= mid1.Length - 4; i++)
                {
                    result += "*";
                }
                result += mid1.Substring(mid1.Length - 3);
            }
            if (mid2 != null)
            {
                result += "、";
                result += mid2.Substring(0, 2);
                for (int i = 1; i <= mid2.Length - 4; i++)
                {
                    result += "*";
                }
                result += mid2.Substring(mid2.Length - 3);
            }
            return result;
        }
    }
}