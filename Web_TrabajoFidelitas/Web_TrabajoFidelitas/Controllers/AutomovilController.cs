using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Web_TrabajoFidelitas.Entidades;
using Web_TrabajoFidelitas.Models;

namespace Web_TrabajoFidelitas.Controllers
{
    [FiltroSeguridad]
    public class AutomovilController : Controller
    {
        AutomovilModel model = new AutomovilModel();
        AuditoriaModel modelA = new AuditoriaModel();
        [HttpGet]
        public ActionResult MostrarAutomoviles()
        {
            var respuesta = model.ConsultarAutomoviles();
            if (respuesta.Codigo == 0)
            {
            

                return View(respuesta.Datos);
            } else 
            {
                ViewBag.MsjPantalla = respuesta.Detalle;
                return View(new List<Automovil>());
            }
        }

        // ---------------------- REGISTRO ----------------------

        [HttpGet]
        public ActionResult NuevoAutomovil()
        {
            CargarViewBagIdClientes();

            return View();
        }

        [HttpPost]
        public ActionResult NuevoAutomovil(Automovil entidad)
        {
            var respuesta = model.AgregarAutomovil(entidad);
            if (respuesta.Codigo == 0)
            {
                Auditoria au = new Auditoria();
                au.TableName = "Automoviles";
                au.Action = "INSERT";
                au.Usuario = Session["NombreUsuario"].ToString();
                modelA.AgregarAuditoria(au);
                return RedirectToAction("MostrarAutomoviles");
            }
            else
            {
                ViewBag.MsjPantalla = respuesta.Detalle;
                return View(new List<Automovil>());
            }
        }

        // ---------------------- ACTUALIZAR ---------------------

        [HttpGet]
        public ActionResult ActualizarAutomovil(long id)
        {
            CargarViewBagIdClientes();
            var respuesta = model.ConsultarAutomovil(id);
            return View(respuesta.Dato);
        }
        [HttpPost]
        public ActionResult ActualizarAutomovil(Automovil entidad)
        {
            var respuesta = model.ActualizarAutomovil(entidad);
            if (respuesta.Codigo == 0)
            {
                Auditoria au = new Auditoria();
                au.TableName = "Automoviles";
                au.Action = "UPDATE";
                au.Usuario = Session["NombreUsuario"].ToString();
                modelA.AgregarAuditoria(au);
                return RedirectToAction("MostrarAutomoviles");
            }
            else
            {
                return View();
            }
        }

        // ---------------------- ELIMINAR ---------------------

        [HttpGet]
        public ActionResult EliminarAutomovil(long id)
        {
            var respuesta = model.EliminarAutomovil(id);

            if (respuesta.Codigo == 0)
            {
                Auditoria au = new Auditoria();
                au.TableName = "Automoviles";
                au.Action = "INACTIVAR";
                au.Usuario = Session["NombreUsuario"].ToString();
                modelA.AgregarAuditoria(au);
                return RedirectToAction("MostrarAutomoviles", "Automovil");
            }
            else
            {
                ViewBag.MsjPantalla = respuesta.Detalle;
                return View();
            }
        }

        // ---------------------- EXTRA / DROPDOWN ----------------------
        private void CargarViewBagIdClientes()
        {
            var respuesta = model.ConsultarIdsClientes();
            var idClientes = new List<SelectListItem>();

            idClientes.Add(new SelectListItem { Text = "seleccione un id ...", Value = "" });
            foreach (var item in respuesta.Datos)
                idClientes.Add(new SelectListItem { Text = item.NombreCliente, Value = item.IdsCliente.ToString() });

            ViewBag.IdsClientes = idClientes;
        }
    }
}