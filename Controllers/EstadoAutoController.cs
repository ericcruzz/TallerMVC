using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TallerMVC.Models;
using TallerMVC.Models.ViewModels;
using static TallerMVC.Models.Enum;

namespace TallerMVC.Controllers
{
    public class EstadoAutoController : Controller
    {
        // GET: EstadoAuto
        public ActionResult Index()
        {
            List<ListViewEstadoAuto> list = new List<ListViewEstadoAuto>();
            using(TallerEntities db = new TallerEntities())
            {
                list = (from ea in db.EstadoAuto
                        join co in db.Coche on ea.cocheId equals co.idCoche select new ListViewEstadoAuto
                        {
                            idEstadoAuto = ea.idEstadoAuto,
                            condicion = ea.condicion,
                            inventario = ea.inventario,
                            FechaEdo = ea.FechaEdo,
                            coche = co.marca + " " + co.modelo + " " + co.anio
                        }).ToList();
            }
            return View(list);
        }


        public ActionResult Nuevo_EstadoAuto()
        {
            CargarDDL();
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo_EstadoAuto(NuevoEstadoAuto model)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    using (TallerEntities db = new TallerEntities())
                    {
                        var edoauto = new EstadoAuto();
                        edoauto.inventario = model.inventario;
                        edoauto.condicion = model.condicion;
                        edoauto.FechaEdo = model.FechaEdo;
                        edoauto.cocheId = model.cocheId;

                        db.EstadoAuto.Add(edoauto);
                        db.SaveChanges();
                    }
                    return Redirect("~/EstadoAuto");
                }
                Alert("Verifique la informacion", NotificationType.warning);
                CargarDDL();
                return View(model);
            }
            catch (Exception ex)
            {
                Alert("Error: " + ex.Message, NotificationType.error);
                return View(model);
            }
        }

        public ActionResult Editar_EstadoAuto(int id)
        {
            EstadoAuto ea = new EstadoAuto();
            using (TallerEntities db = new TallerEntities())
            {
                ea = db.EstadoAuto.Where(x => x.idEstadoAuto == id).FirstOrDefault();
            }
            ViewBag.Title = "Editar Coche No°: " + ea.idEstadoAuto;
            CargarDDL();
            return View(ea);
        }

        [HttpPost]
        public ActionResult Editar_EstadoAuto(EstadoAuto model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (TallerEntities db = new TallerEntities())
                    {
                        var ea = new EstadoAuto();
                        ea.idEstadoAuto = model.idEstadoAuto;
                        ea.inventario = model.inventario;
                        ea.condicion = model.condicion;
                        ea.FechaEdo = model.FechaEdo;
                        ea.cocheId = model.cocheId;

                        db.Entry(ea).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();

                        Alert("Registro guardado con éxito", NotificationType.success);
                    }
                    return Redirect("~/EstadoAuto");
                }
                Alert("Verifique la informacion", NotificationType.warning);
                CargarDDL();
                return View(model);
            }
            catch (Exception ex)
            {
                Alert("Error: " + ex.Message, NotificationType.error);
                CargarDDL();
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult Eliminar_EstadoAuto(int id)
        {
            EstadoAuto ea = new EstadoAuto();
            using (TallerEntities db = new TallerEntities())
            {
                ea = db.EstadoAuto.Where(x => x.idEstadoAuto == id).FirstOrDefault();
            }
            try
            {
                using (TallerEntities db = new TallerEntities())
                {
                    ea = db.EstadoAuto.Where(x => x.idEstadoAuto == id).FirstOrDefault();
                    db.EstadoAuto.Remove(ea);
                    db.SaveChanges();
                }
                Alert("Registro Eliminado con éxito ", NotificationType.success);
                return Redirect("~/EstadoAuto");
            }
            catch (Exception ex)
            {
                Alert("Error: " + ex.Message, NotificationType.error);
                return Redirect("~/EstadoAuto");
            }
        }

        public void CargarDDL()
        {
            List<CochesDDL> list = new List<CochesDDL>();
            list.Insert(0, new CochesDDL() { idCoche = 0, nombre = "Seleccione el Coche"});

            using (TallerEntities db = new TallerEntities())
            {
                foreach (var c in db.Coche)
                {
                    CochesDDL aux = new CochesDDL();
                    aux.idCoche = c.idCoche;
                    aux.nombre = c.marca + " " + c.modelo + " " + c.anio;

                    list.Add(aux);
                }

            }
            ViewBag.ListaCoches = list;
        }

        public void Alert(string message, NotificationType notificationType)
        {
            var msg = "<script language='javascript'> Swal.fire('" + notificationType.ToString().ToUpper() + "','" + message + "','" +
                notificationType + "')" + "</script>";

            TempData["notification"] = msg;
        }
    }
}