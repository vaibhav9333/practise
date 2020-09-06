using JQuery_ajax_crud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JQuery_ajax_crud.Controllers
{
    public class EmployeeController : Controller
    {
        
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Viewall()
        {
            using (cruddbEntities db = new cruddbEntities())
            {
                var employee = db.employees.ToList();
                return View(employee);

            }
        }
    }
}