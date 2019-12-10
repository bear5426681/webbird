using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using prjWebBird.Models;
using prjWebBird.Models.ViewModels;
using prjWebBird.Services;
using Securitys;

namespace prjWebBird.Controllers
{
    public class userController : Controller
    {
        // GET: user
        webbirdEntities db = new webbirdEntities();
        public ActionResult Index()
        {
            return View();
        }

           

        // GET: user/Create
        public ActionResult _Register()
        {
            z_bas_user users = new z_bas_user();
            return View(users);
        }

        // POST: user/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult _Register(z_bas_user user)
        {
            bool isSuccess = true;
            
            //db.SaveChanges();
            try
            {
                
                if (ModelState.IsValid)
                {
                    var newuser = db.z_bas_user.Where(m => m.mid == user.mid).FirstOrDefault();
                    var newemil = db.z_bas_user.Where(m => m.memail == user.memail).FirstOrDefault();
                    if (newuser != null|| newemil!=null)
                    {
                        if (newuser != null)
                        {
                            ModelState.AddModelError("mid", "此帳號已註冊");                            
                            isSuccess = false;
                        }
                        else 
                        {
                            ModelState.AddModelError("memail", "此信箱已註冊");
                            isSuccess = false;
                        }
                                           }
                    if (isSuccess)
                    {
                        user.mpassword = HashPassword(user.mpassword);
                        db.z_bas_user.Add(user);
                        user.mdate = DateTime.Today;
                        user.mtype = "u1";
                        int i = db.SaveChanges();
                        //db.SaveChanges();
                        
                    }            
                }            
            }
            catch(Exception ex)
            {
                throw;
            }

            var returnData = new
            {
                // 成功與否
                IsSuccess = isSuccess,
                // ModelState錯誤訊息 
                ModelStateErrors = ModelState.Where(x => x.Value.Errors.Count > 0)
            .ToDictionary(k => k.Key, k => k.Value.Errors.Select(e => e.ErrorMessage).ToArray())
            };
            return Content(Newtonsoft.Json.JsonConvert.SerializeObject(returnData), "application/json");


        }

        
        public ActionResult Login()
        {
            LoginViewModel login = new LoginViewModel();
            return View(login);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel logonModel)
        {
            bool isSuccess = false;
            if (!ModelState.IsValid)
            {
                return View(logonModel);
            }
            var hashpass = HashPassword(logonModel.Password) ;
            var user = db.z_bas_user.Where((m => m.mid == logonModel.UserNo || m.memail == logonModel.UserNo)).Where(m => m.mpassword == hashpass).FirstOrDefault();

            if (user != null) 
            {
                UserAccount.LogIn(user.mid, user.mname, enUserRole.User,"");
                return RedirectToAction("Index", "Home");
            }

            if (logonModel.UserNo == "admin" && logonModel.Password == "admin")
            {
                UserAccount.LogIn(logonModel.UserNo, "管理者", enUserRole.Admin,"");
                return RedirectToAction("Index", "Home");
            }
            UserAccount.LogOut();

            

            if (user == null)
            {
                ModelState.AddModelError("UserNo", "請輸入正確的帳號或密碼!");
                var returnData = new
                {
                    
                // 成功與否
                IsSuccess = isSuccess,
                    // ModelState錯誤訊息 
                    ModelStateErrors = ModelState.Where(x => x.Value.Errors.Count > 0)
          .ToDictionary(k => k.Key, k => k.Value.Errors.Select(e => e.ErrorMessage).ToArray())
                };
                return Content(Newtonsoft.Json.JsonConvert.SerializeObject(returnData), "application/json");
            }
            UserAccount.LogOut();
            ModelState.AddModelError("", "請輸入正確的帳號或密碼!");
            return View(logonModel);

        }

        public ActionResult Logout()
        {
            UserAccount.LogOut();
            return RedirectToAction("Index", "Home");
        }

        // GET: user/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: user/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: user/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: user/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        #region Hash密碼
        private string HashPassword(string mpassword)
        {
            string saltkey = "12uiaglb639er89749p504h2ws3y293vmo";
            string saltAndPassword = String.Concat(mpassword, saltkey);
            SHA256CryptoServiceProvider sHA256Hasher = new SHA256CryptoServiceProvider();

            byte[] PasswordData = Encoding.Default.GetBytes(saltAndPassword);
            byte[] HashData = sHA256Hasher.ComputeHash(PasswordData);
            string Hashresult = Convert.ToBase64String(HashData);

            return Hashresult;
        }
        #endregion

        #region 確認密碼
        private bool passwordCheck(z_bas_user haveuser,string mpassword)
        {
            bool result = haveuser.mpassword.Equals(HashPassword(mpassword));
            return result;
        }
        #endregion
    }
}
