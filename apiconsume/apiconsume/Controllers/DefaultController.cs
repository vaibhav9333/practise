using apiconsume.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace apiconsume.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            IEnumerable<employee> employees = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53369/api/");
                var Responcetask = client.GetAsync("employees");
                Responcetask.Wait();
                var Result = Responcetask.Result;
                if(Result.IsSuccessStatusCode)
                {
                    var readtask = Result.Content.ReadAsAsync<IList<employee>>();
                    readtask.Wait();
                    employees = readtask.Result;
                }

            }
                return View(employees);
        }
        
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create( employee employee)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53369/api/employees");
                var posttask = client.PostAsJsonAsync<employee>("employees", employee);
                posttask.Wait();
                var result = posttask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError(string.Empty, "Server error");

            
                return View(employee);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            employee employees = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53369/api/");
                var Responcetask = client.GetAsync("employees?id=" + id.ToString());
                Responcetask.Wait();
                var Result = Responcetask.Result;
                if (Result.IsSuccessStatusCode)
                {
                    var readtask = Result.Content.ReadAsAsync<employee>();
                    readtask.Wait();
                    employees = readtask.Result;
                }

            }
            return View(employees);
        }
        [HttpPost]
        public ActionResult Edit(employee employee)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53369/api/employees");
                var responcetask = client.PutAsJsonAsync<employee>("employees", employee);
                responcetask.Wait();
                var result = responcetask.Result;
                if(result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }

            }

                return View(employee);
        }
        [HttpGet]
        public ActionResult Delete()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53369/api/");
                var responce = client.DeleteAsync("employees/" + id.ToString());
                responce.Wait();
                var result = responce.Result;
                if(result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

                return  RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult details(int id)
        {
            employee employees = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53369/api/");
                var Responcetask = client.GetAsync("employees?id=" + id.ToString());
                Responcetask.Wait();
                var Result = Responcetask.Result;
                if (Result.IsSuccessStatusCode)
                {
                    var readtask = Result.Content.ReadAsAsync<employee>();
                    readtask.Wait();
                    employees = readtask.Result;
                }

            }



            return View(employees);
        }
        
    }
}