using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RegistrationForm.Models;
using System.Web.Security;

namespace RegistrationForm.Controllers
 {       
    public class User2Controller : Controller
    {
        private officeEntities db = new officeEntities();
        
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User2 model)
        {
            using (var context = new officeEntities())
            {
                bool isvalid = context.User2.Any(x => x.Username == model.Username && x.Password == model.Password);
                if (isvalid)
                {
                    return RedirectToAction("Index", "User2");
                }

            }
            ModelState.AddModelError("", "Invalid username and password");
            return View();
        }


        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        public JsonResult Isusernamealready(string Username)
        {
            return Json(!db.User2.Any(u => u.Username == Username), JsonRequestBehavior.AllowGet);
        }

        // GET: User2
        public ActionResult Index()
        {
            return View(db.User2.ToList());
        }

        // GET: User2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User2 user2 = db.User2.Find(id);
            if (user2 == null)
            {
                return HttpNotFound();
            }
            return View(user2);
        }

        // GET: User2/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create([Bind(Include = "Id,Username,Password,ConfirmPassword,Mno,Email,State,City")] User2 user2)
        {
            if (ModelState.IsValid)
            {
                db.User2.Add(user2);
                db.SaveChanges();
                return RedirectToAction("Login");
            }

            return View(user2);
        }

        

        // GET: User2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User2 user2 = db.User2.Find(id);
            if (user2 == null)
            {
                return HttpNotFound();
            }
            return View(user2);
        }

        // POST: User2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Username,Password,Mno,Email,State,City")] User2 user2)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user2);
        }

        // GET: User2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User2 user2 = db.User2.Find(id);
            if (user2 == null)
            {
                return HttpNotFound();
            }
            return View(user2);
        }

        // POST: User2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User2 user2 = db.User2.Find(id);
            db.User2.Remove(user2);
            db.SaveChanges();
            return RedirectToAction("Index");
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
