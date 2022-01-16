using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using UserAuth.Data;
using UserAuth.Models;

namespace UserAuth.Controllers
{
    public class AccountController : Controller
    {

        private UserAuthenticationContext db = new UserAuthenticationContext();
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Users Data)
        {
            if(Data == null) return View();
            //else 


            var success = db.Users.Any(P => P.Name == Data.Name && P.Password.Equals(Data.Password));
            if(success)
            {
                //set Cookie
                FormsAuthentication.SetAuthCookie(Data.Name, false);
                return RedirectToAction("Index","Home");
            }
            return View();

        }
        [Route("account/signup")]
        public ActionResult SignUp()
        {
            ViewBag.message = "";
            return View();

        }

        [HttpPost, Route("account/signup")]
        public ActionResult SignUp(Users user)
        {
            if (user == null) return View();
            //else 

            if (user.Password.Length != 6)
            {
                ViewBag.message = "Password length should be greater than 6";
                return View();
            }
            
            db.Users.Add(user);
            db.SaveChanges();
            return RedirectToAction("Login");

        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");

        }
    }
}