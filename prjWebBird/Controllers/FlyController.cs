using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using prjWebBird.Models;
using prjWebBird.Models.ViewModels;
using Securitys;
using UpLoadPic;
using CreateContent;

namespace prjWebBird.Controllers
{
    
    public class FlyController : Controller
    {

        webbirdEntities db = new webbirdEntities();
        create_content _cc = new create_content();
        // GET: Fly
        public ActionResult Index()
        {
            var fly = db.z_func_fly.OrderByDescending(m=>m.mtime).ToList();
            var item = db.z_sys_state.Where(m => m.fa_no == "sta2f").ToList();
            if (item.Count > 0)
            {
                foreach (var aa in fly)
                {
                    string state = db.z_sys_state.Where(m => m.mno == aa.mstate).FirstOrDefault().mname;
                    aa.mstate = state;
                }
            }
            return View(fly);
        }
        //var fly = db.z_func_fly.ToList();  ViewModel的作法
        //var item = db.z_sys_state.Where(m => m.fa_no == "sta2f").ToList();
        //if (item.Count > 0)
        //{
        //    foreach(var aa in fly)
        //    {
        //        indexInfoViewModel mm = new indexInfoViewModel()  

        //        {
        //           state = db.z_sys_state.Where(m => m.mno == aa.mstate).FirstOrDefault().mname
        //        };


        //        aa.mstate = mm.state;
        //    }
        //}


        public ActionResult picIndex()
        {
            //test abc = new test();
            //abc.abc = db.z_func_fly.ToList();
            var picindex = db.vi_user_fly.OrderByDescending(m => m.mtime).ToList();
            
            return View(picindex);
           
        }

        public ActionResult Create()
        {
            var _id = UserAccount.UserNo;
            //z_bas_user user = db.z_bas_user.Where(m => m.mid == _id).FirstOrDefault();
            ViewBag.userInfo = db.z_bas_user.Where(m => m.mid == _id).FirstOrDefault();
            ViewBag.state = new SelectList(db.z_sys_state.Where(m=>m.fa_no == "sta2f").ToList());
            ViewBag.maddr = new SelectList(db.z_sys_addr_city_area.Select(m=>m.remark).ToList());
            ViewData["mstate"] = db.z_sys_state.Where(m => m.fa_no == "sta2f").ToList();
            return View();
        }
         
       
        [HttpPost]
        public ActionResult Create(z_func_fly _Fly, string connmname, string connect, string tel, HttpPostedFileBase[] photos)
        {

            z_func_fly fly = new z_func_fly();
            var _id = UserAccount.UserNo;
            z_bas_user user = db.z_bas_user.Where(m => m.mid == _id).FirstOrDefault();

            if (UserAccount.IsLogin)
            {
                fly = _Fly;
                fly.user_no = db.z_bas_user.Where(m => m.mid == _id).FirstOrDefault().mno;
                user.mtel = tel;
                user.mconn = connect;
                user.mname = connmname;
                db.SaveChanges();
                //UserAccount.UserNo
            }
           
            fly.show_id = _cc.showID(_Fly.mid, _Fly.mid2);
            fly.mdate_edit = DateTime.Now;
            fly.mdate_create= DateTime.Now;
            //DateTime date = DateTime.Parse(_Fly.mtime.ToString().Substring(0, 9));
            fly.mdate =_Fly.mtime;
            int NoCount = db.z_func_fly.Where(m => m.mdate == _Fly.mtime).Count();
            string filebox = "F" + _Fly.mtime?.ToString("yyyyMMdd")+ (NoCount + 1).ToString("D3");
            //string date = fly.mdate_create?.ToString("yyyyMMddHHmmss");
             using (ezFileUpload upload = new ezFileUpload("~/Photos/" + user.mno + "/Fly/" + filebox + "/"))
            {
                var i = 1;
                foreach (HttpPostedFileBase item in photos)
                {
                    upload.SaveUploadFile(item, i.ToString());
                    i++;
                }
            };

            if (_Fly.mstate == null)
            {
                fly.mstate = "sta2f1";
            }
            else
                fly.mstate = _Fly.mstate;

            if (_Fly.mstate == "sta2f3" || _Fly.mstate == "sta2f2")
            {
                fly.edit = false;
            }
            else
                fly.edit = true;

            db.z_func_fly.Add(fly);
            db.SaveChanges();
            return RedirectToAction("picIndex");

        }

        
        public ActionResult Delete(string id)
        {
            var todo = db.z_func_fly.Where(m => m.mno == id).FirstOrDefault();
            db.z_func_fly.Remove(todo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(string id)
        {
            var todo = db.z_func_fly.Where(m => m.mno == id).FirstOrDefault();
            var _id = UserAccount.UserNo;
            //z_bas_user user = db.z_bas_user.Where(m => m.mid == _id).FirstOrDefault();
            ViewBag.userInfo = db.z_bas_user.Where(m => m.mid == _id).FirstOrDefault();
            ViewBag.state = new SelectList(db.z_sys_state.Where(m => m.fa_no == "sta2f").ToList());
            ViewBag.maddr = new SelectList(db.z_sys_addr_city_area.Select(m => m.remark).ToList());
            ViewData["mstate"] = db.z_sys_state.Where(m => m.fa_no == "sta2f").ToList();

            return View(todo);
        }

        [HttpPost]
        public ActionResult Edit(z_func_fly _Fly, string connmname, string connect, string tel, HttpPostedFileBase[] photos)
        {
      
        var fly = db.z_func_fly.Where(m => m.mno == _Fly.mno).FirstOrDefault();
            var _id = UserAccount.UserNo;
            z_bas_user user = db.z_bas_user.Where(m => m.mid == _id).FirstOrDefault();

            if (UserAccount.IsLogin && _id==fly.user_no || _id=="Admin")
            {
                fly.mname = _Fly.mname;
                fly.mid = _Fly.mid;
                fly.mid2 = _Fly.mid2;
                fly.mfeature = _Fly.mfeature;
                //fly.maddr = _Fly.maddr;//暫不可修改
                fly.maddr_detail = _Fly.maddr_detail;
                fly.mcolor = _Fly.mcolor;
                fly.mstate = _Fly.mstate;
                fly.mremarks = _Fly.mremarks;
                fly.mspecies = _Fly.mspecies;
                fly.lat = _Fly.lat;
                fly.lng = _Fly.lng;
                if (_id != "Admin")
                {
                    user.mtel = tel;
                    user.mconn = connect;
                    user.mname = connmname;
                }
                db.SaveChanges();
                //UserAccount.UserNo
            }

            fly.show_id = _cc.showID(_Fly.mid, _Fly.mid2);
            fly.mdate_edit = DateTime.Now;
            
            //DateTime date = DateTime.Parse(_Fly.mtime.ToString().Substring(0, 9));
            
           
            using (ezFileUpload upload = new ezFileUpload("~/Photos/" + user.mno + "/Fly/" + fly.mno + "/"))
            {
                var i = 1;
                foreach (HttpPostedFileBase item in photos)
                {
                    upload.SaveUploadFile(item, i.ToString());
                    i++;
                }
            };
            if (_Fly.mstate == null)
            {
                fly.mstate = "sta2f1";
            }
            else 
                fly.mstate = _Fly.mstate;
            if (_Fly.mstate == "sta2f3" || _Fly.mstate == "sta2f2")
            {
                fly.edit = false;
            }
            else
                fly.edit = true;

            
            db.SaveChanges();
            return RedirectToAction("Index"); 
        }



    }
}