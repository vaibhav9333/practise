using MvcCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCrud.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            cruddbEntities db = new cruddbEntities();
            var employee = db.employees.ToList(); 
            return View(employee);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
   public ActionResult Create(int?Id,string Ename,string Position,int Age,int salary )
        {
            try
            {
                employee e = new employee();
                e.Id = Id;
                e.Ename = Ename;
                e.Position = Position;
                e.Age = Age;
                e.Salary = salary;
                cruddbEntities db = new cruddbEntities();
                db.employees.Add(e);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            catch(Exception ex)
            {

                return View();
            }

        }
        
        public ActionResult Edit(int? id)
        {
            cruddbEntities db = new cruddbEntities();
            employee emp = db.employees.FirstOrDefault(x => x.Id==id);
            return View(emp);
        }
        [HttpPost]
        public ActionResult Edit(int id, string Ename,string position,int age,int salary)
        {
            cruddbEntities db = new cruddbEntities();
            employee emp = db.employees.FirstOrDefault(x=>x.Id==id);
            emp.Id = id;
            emp.Ename = Ename;
            emp.Position = position;
            emp.Age = age;
            emp.Salary = salary;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Details(int? id)
        {
            cruddbEntities db = new cruddbEntities();
            employee emp = db.employees.FirstOrDefault(e => e.Id == id);

            return View(emp);
        }


        public ActionResult Delete(int? id)
        {
            cruddbEntities db = new cruddbEntities();
            employee emp = db.employees.FirstOrDefault(e => e.Id == id);

            return View(emp);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Deleteconfirmed(int? id)
        { cruddbEntities db = new cruddbEntities();
            employee e = db.employees.FirstOrDefault(x => x.Id == id);
                db.employees.Remove(e);

            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}