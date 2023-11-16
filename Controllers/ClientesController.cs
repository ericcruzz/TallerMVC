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
    public class ClientesController : Controller
    {
        // GET: Clientes
        public ActionResult Index()
        {
            List<ListViewCliente> list = new List<ListViewCliente>();
            using(TallerEntities context = new TallerEntities())
            {
                list = (from c in context.Cliente
                        select new ListViewCliente{
                            idCliente = c.idCliente,
                            nombreCompleto = c.nombre + " " + c.apellidoPaterno + " " + c.apellidoMaterno,
                            edad = c.edad,
                            sexo = c.sexo,
                            direccion = c.direccion,
                            telefono = c.telefono,
                            correo = c.correo
                        }).ToList();
            }
            return View(list);
        }

        public ActionResult Nuevo_Cliente()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo_Cliente(NuevoCliente model)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    using(TallerEntities context = new TallerEntities())
                    {
                        var cliente = new Cliente();
                        cliente.nombre = model.nombre;
                        cliente.apellidoPaterno = model.apellidoPaterno;
                        cliente.apellidoMaterno = model.apellidoMaterno;
                        cliente.edad = model.edad;
                        cliente.sexo = model.sexo;
                        cliente.direccion = model.direccion;
                        cliente.telefono = model.telefono;
                        cliente.correo = model.correo;

                        context.Cliente.Add(cliente);
                        context.SaveChanges();
                        
                    }
                    Alert("Registro guardado con éxito", NotificationType.success);
                    return Redirect("~/Clientes");
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

        public ActionResult Editar_Cliente(int id)
        {
            Cliente cliente = new Cliente();
            using(TallerEntities db = new TallerEntities())
            {
                cliente = db.Cliente.Where(x => x.idCliente == id).FirstOrDefault();
            }
            ViewBag.Title = "Editar Cliente No°: " + cliente.idCliente;
            return View(cliente);
        }

        [HttpPost]
        public ActionResult Editar_Cliente(Cliente model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (TallerEntities db = new TallerEntities())
                    {
                        var cliente = new Cliente();
                        cliente.idCliente = model.idCliente;
                        cliente.nombre = model.nombre;
                        cliente.apellidoPaterno = model.apellidoPaterno;
                        cliente.apellidoMaterno = model.apellidoMaterno;
                        cliente.edad = model.edad;
                        cliente.sexo = model.sexo;
                        cliente.direccion = model.direccion;
                        cliente.telefono = model.telefono;
                        cliente.correo = model.correo;

                        db.Entry(cliente).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        Alert("Registro guardado con éxito", NotificationType.success);
                    }
                    return Redirect("~/Clientes");
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
        public ActionResult Eliminar_Cliente(int id)
        {
            Cliente cliente = new Cliente();
            try
            {
                using(TallerEntities db = new TallerEntities())
                {
                    cliente = db.Cliente.Where(x => x.idCliente == id).FirstOrDefault();
                    db.Cliente.Remove(cliente);
                    db.SaveChanges();
                }
                Alert("Registro Eliminado con éxito ", NotificationType.success);
                return Redirect("~/Clientes");
            }
            catch (Exception ex)
            {
                Alert("Error: " + ex.Message, NotificationType.error);
                return Redirect("~/Clientes");
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