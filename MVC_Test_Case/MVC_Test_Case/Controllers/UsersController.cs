using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using MVC_Test_Case.Models;

namespace MVC_Test_Case.Controllers
{
    public class UsersController : Controller
    {
        string tempPass;
        private UserDBContext db = new UserDBContext();

        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }

        // GET: Users
        public ActionResult Home()
        {
            return View();
        }

        // GET: Users/Login
        public ActionResult Login()
        {
            Session["isSuccess"] = false;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {

            if (Session["Name"] != null)
            {
                ViewBag.Error = "You are already logged in";
                return View("Login");
            }

            if (!String.IsNullOrEmpty(user.Name) && !String.IsNullOrEmpty(user.Password))
            {
                tempPass = CreateMD5(user.Password);

                if (db.Users.Any(x => x.Name == user.Name && tempPass == x.Password))
                {
                    Session["Name"] = user.Name;

                    return RedirectToAction("Home");
                }
                else
                {
                    ViewBag.ErrorMessage = "Incorrect name or password !!";
                }
            }

            else
            {
                ViewBag.ErrorMessage2 = "Please type your name and password !!";
            }

            
            return View();
        }

        // GET: Users/Register
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [OutputCache(NoStore = true, Duration = 0)]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                if (db.Users.Any(x => x.Name == user.Name)) {

                    ViewBag.ErrorMessage = "Account with this name already exists !!";

                    return View("Register");
                }

                else { 
                    user.Password = CreateMD5(user.Password);
                    db.Users.Add(user);
                    db.SaveChanges();

                    ModelState.Clear();

                    ViewBag.Message = "You have successfully registered.";
                }
            }

            return View("Register");
        }

        // GET: Users/Logout
        public ActionResult Logout()
        {
            Session["Name"] = null;
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
