using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Loginfrom.Models;
using System.Web.Security;

namespace Loginfrom.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Models.Membership model)
        {
            using (var context = new cruddbEntities())
            {
                bool isvalid = context.User1.Any(x => x.Username == model.Username && x.Password == model.Password);
                if(isvalid)
                {
                    FormsAuthentication.SetAuthCookie(model.Username,false); 
                    return RedirectToAction("Index", "employees");
                }
            }
            ModelState.AddModelError("", "invalid username and password");
                return View();
        }
        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signup(User1 model)
        {
            using (var context = new cruddbEntities())
            {
                context.User1.Add(model);
                context.SaveChanges();

            }
                return RedirectToAction("Login");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }

}