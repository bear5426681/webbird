using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using prjWebBird.Models;

namespace prjWebBird.Services
{
    public class MembersDBService
    {
        private readonly static string cnstr = ConfigurationManager.ConnectionStrings["webbird"].ConnectionString;
        private readonly SqlConnection conn = new SqlConnection(cnstr);

        
        public void Register(z_bas_user newuser)
        {
            newuser.mpassword = HashPassword(newuser.mpassword);
        }


        public string HashPassword(string mpassword)
        {
            string saltkey = "12uiaglb639er89749p504h2ws3y293vmo";
            string saltAndPassword = String.Concat(mpassword, saltkey);
            SHA256CryptoServiceProvider sHA256Hasher = new SHA256CryptoServiceProvider();

            byte[] PasswordData = Encoding.Default.GetBytes(saltAndPassword);
            byte[] HashData = sHA256Hasher.ComputeHash(PasswordData);
            string Hashresult = Convert.ToBase64String(HashData);

            return Hashresult;
        }
    }
}