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
    public class CochesController : Controller
    {
        // GET: Coches
        public ActionResult Index()
        {
            List<ListViewCoche> list = new List<ListViewCoche>();
            using(TallerEntities db = new TallerEntities())
            {
                list = (from co in db.Coche
                        join cl in db.Cliente on co.clienteId equals cl.idCliente
                        select new ListViewCoche{
                            idCoche = co.idCoche,
                            placa = co.placa,
                            marca = co.marca,
                            modelo = co.modelo,
                            anio = co.anio,
                            color = co.color,
                            cliente = cl.nombre + " " + cl.apellidoPaterno + " " + cl.apellidoMaterno
                        }).ToList();
            }
            return View(list);
        }

        public ActionResult Nuevo_Coche() {
            CargarDDL();
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo_Coche(NuevoCoche model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (TallerEntities db = new TallerEntities())
                    {
                        var coche = new Coche();
                        coche.placa = model.placa;
                        coche.marca = model.marca;
                        coche.modelo = model.modelo;
                        coche.anio = model.anio;
                        coche.color = model.color;
                        coche.clienteId = model.clienteid;

                        db.Coche.Add(coche);
                        db.SaveChanges();
                    }
                    Alert("Registro guardado con éxito", NotificationType.success);
                    return Redirect("~/Coches");
                }
                Alert("Verifique la informacion", NotificationType.warning);
                CargarDDL();
                return View(model);
            }
            catch(Exception ex)
            {
                Alert("Error: " + ex.Message, NotificationType.error);
                return View(model);
            }
        }

        public ActionResult Editar_Coche(int id)
        {
            Coche coche = new Coche();
            using(TallerEntities db = new TallerEntities())
            {
                coche = db.Coche.Where(x => x.idCoche == id).FirstOrDefault();
            }
            ViewBag.Title = "Editar Coche No°: " + coche.idCoche;
            CargarDDL();
            return View(coche);
        }

        [HttpPost]
        public ActionResult Editar_Coche(Coche model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (TallerEntities db = new TallerEntities())
                    {
                        var coche = new Coche();
                        coche.idCoche = model.idCoche;
                        coche.placa = model.placa;
                        coche.marca = model.marca;
                        coche.modelo = model.modelo;
                        coche.anio = model.anio;
                        coche.color = model.color;
                        coche.clienteId = model.clienteId;

                        db.Entry(coche).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        
                        Alert("Actualizacion guardado con éxito", NotificationType.success);
                    }
                    return Redirect("~/Coches");
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
        public ActionResult Eliminar_Coche(int id)
        {
            Coche coche = new Coche();
            try
            {
                using(TallerEntities db = new TallerEntities())
                {
                    coche = db.Coche.Where(x => x.idCoche == id).FirstOrDefault();
                    db.Coche.Remove(coche);
                    db.SaveChanges();
                }
                Alert("Registro Eliminado con éxito ", NotificationType.success);
                return Redirect("~/Coches");
            }
            catch (Exception ex)
            {
                Alert("Error: " + ex.Message, NotificationType.error);
                return Redirect("~/Coches");
            }
        }

        public void CargarDDL()
        {
            List<ClientesDDL> list = new List<ClientesDDL>();
            list.Insert(0, new ClientesDDL() { idCliente = 0, nombre = "Seleccione el Cliente"} );

            using(TallerEntities db = new TallerEntities())
            {
                foreach(var c in db.Cliente)
                {
                    ClientesDDL aux = new ClientesDDL();
                    aux.idCliente = c.idCliente;
                    aux.nombre = c.nombre + " " + c.apellidoPaterno + " " + c.apellidoMaterno;

                    list.Add(aux);
                }

            }
            ViewBag.ListaClientes = list;
        }

        public void Alert(string message, NotificationType notificationType)
        {
            var msg = "<script language='javascript'> Swal.fire('" + notificationType.ToString().ToUpper() + "','" + message + "','" +
                notificationType + "')" + "</script>";

            TempData["notification"] = msg;
        }
    }
}