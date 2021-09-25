using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_Test_Case.Models;

namespace MVC_Test_Case.Controllers
{
    public class UsersController : Controller
    {
        private UserDBContext db = new UserDBContext();

        // GET: Users
        public ActionResult Home()
        {
            return View();
        }

        // GET: Users/Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {
            Session["Name"] = user.Name;
            return View();
        }

        // GET: Users/Register
        public ActionResult Register()
        {
            return View();
        }

        // GET: Users/Logout
        public ActionResult Logout()
        {
            Session["Name"] = null;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User user)
        {
    
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Login");
            }

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
