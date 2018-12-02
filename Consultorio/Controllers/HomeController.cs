using Consultorio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Consultorio.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetPacientes()
        {
            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                var pacientes = dc.Pacientes.OrderBy(a => a.nombre).ToList();
                return Json(new { data = pacientes }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult Guardar(int id)
        {
            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {

                var v = dc.Pacientes.Where(a => a.Cedula == id).FirstOrDefault();
                return View(v);
            }
        }

        [HttpPost]
        public ActionResult Guardar(Paciente pct)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                using (MyDatabaseEntities dc = new MyDatabaseEntities())
                {
                if (pct.Cedula > 1)
                    {
                        var v = dc.Pacientes.Where(a => a.Cedula == pct.Cedula).FirstOrDefault();
                        if (v != null)
                        {
                            v.Cedula = pct.Cedula;
                            v.nombre = pct.nombre;
                            v.apellido = pct.apellido;
                            v.fecha = pct.fecha;
                            v.sangre = pct.sangre;
                        }
                    }
                else
                    {
                        dc.Pacientes.Add(pct);
                    }
                    dc.SaveChanges();
                    status = true;

                }
            
            }
            return new JsonResult { Data = new { status = status } };
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                var v = dc.Pacientes.Where(a => a.Cedula == id).FirstOrDefault();
                if (v != null)
                {
                    return View(v);
                }
                else
                {
                    return HttpNotFound();
                }
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Deletepacientes(int id)
        {
            bool status = false;
            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                var v = dc.Pacientes.Where(a => a.Cedula == id).FirstOrDefault();
                if (v != null)
                {
                    dc.Pacientes.Remove(v);
                    dc.SaveChanges();
                    status = true;
                }
          
            }
            return new JsonResult { Data = new { status = status } };
        }




        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}