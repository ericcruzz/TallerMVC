using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TallerMVC.Models.ViewModels;
using TallerMVC.Models;
using static TallerMVC.Models.Enum;

namespace TallerMVC.Controllers
{
    public class RefaccionController : Controller
    {
        // GET: Refaccion
        public ActionResult Index()
        {
            List<ListViewRefaccion> list = new List<ListViewRefaccion>();
            using (TallerEntities db = new TallerEntities())
            {
                list = (from re in db.Refaccion
                        select new ListViewRefaccion
                        {
                            idRefaccion = re.idRefaccion,
                            tipo = re.tipo,
                            precio = re.precio,
                            servicioId = re.servicioId
                        }).ToList();
            }
            return View(list);
        }

        public ActionResult Nueva_Refaccion()
        {
            ViewBag.Title = "Nueva Refaccion";
            return View();
        }

        [HttpPost]
        public ActionResult Nueva_Refaccion(NuevaRefaccion model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (TallerEntities db = new TallerEntities())
                    {
                        var re = new Refaccion();
                        re.tipo = model.tipo; 
                        re.precio = model.precio;
                        re.servicioId = model.servicioId;

                        db.Refaccion.Add(re);
                        db.SaveChanges();
                    }
                    Alert("Registro guardado con éxito", NotificationType.success);
                    return Redirect("~/Refaccion");
                }
                Alert("Verifique la informacion", NotificationType.warning);
                return View(model);
            }
            catch (Exception ex)
            {
                Alert("Error: " + ex.Message, NotificationType.error);
                return View(model);
            }
        }

        public ActionResult Editar_Refaccion(int id)
        {
            Refaccion refa = new Refaccion();
            using (TallerEntities db = new TallerEntities())
            {
                refa = db.Refaccion.Where(x => x.idRefaccion == id).FirstOrDefault();
            }
            ViewBag.Title = "Editar Refaccion No°: " + refa.idRefaccion;
            return View(refa);
        }

        [HttpPost]
        public ActionResult Editar_Refaccion(Refaccion model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (TallerEntities db = new TallerEntities())
                    {
                        var refa = new Refaccion();
                        refa.idRefaccion = model.idRefaccion;
                        refa.tipo = model.tipo;
                        refa.precio = model.precio;
                        refa.servicioId = model.servicioId;

                        db.Entry(refa).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();

                        Alert("Actualizacion guardada con éxito", NotificationType.success);
                    }
                   
                    return Redirect("~/Refaccion");
                }
                Alert("Verifique la informacion", NotificationType.warning);
                return View(model);
            }
            catch (Exception ex)
            {
                Alert("Error: " + ex.Message, NotificationType.error);
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult Eliminar_Refaccion(int id)
        {
            Refaccion refa = new Refaccion();
            try
            {
                using (TallerEntities db = new TallerEntities())
                {
                    refa = db.Refaccion.Where(x => x.idRefaccion == id).FirstOrDefault();
                    db.Refaccion.Remove(refa);
                    db.SaveChanges();
                }
                Alert("Registro Eliminado con éxito ", NotificationType.success);
                return Redirect("~/Refaccion");
            }
            catch (Exception ex)
            {
                Alert("Error: " + ex.Message, NotificationType.error);
                return Redirect("~/Refaccion");
            }
        }

        public void Alert(string message, NotificationType notificationType)
        {
            var msg = "<script language='javascript'> Swal.fire('" + notificationType.ToString().ToUpper() + "','" + message + "','" +
                notificationType + "')" + "</script>";

            TempData["notification"] = msg;
        }
    }
}