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
    public class ClienteController : Controller
    {
        ClienteModel model = new ClienteModel();
        AuditoriaModel modelA = new AuditoriaModel();

        [HttpGet]
        public ActionResult MostrarClientes()
        {
           var respuesta = model.ConsultarClientes();
            if (respuesta.Codigo == 0)
            {
                return View(respuesta.Datos);
            }
            else {
                return View(new List<Cliente>());
            }
        }
        [HttpGet]
        public ActionResult NuevoCliente()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NuevoCliente(Cliente entidad)
        {
            var respuesta = model.AgregarCliente(entidad);
            if (respuesta.Codigo == 0)
            {
                Auditoria au = new Auditoria();
                au.TableName = "Clientes";
                au.Action = "INSERT";
                au.Usuario = Session["NombreUsuario"].ToString();
                modelA.AgregarAuditoria(au);
                return RedirectToAction("MostrarClientes");
            }
            else
            {
                return View(new List<Cliente>());
            }
        }
        [HttpGet]
        public ActionResult ActualizarCliente(long id)
        {
            var respuesta = model.ConsultarCliente(id);
            return View(respuesta.Dato);

            
        }
        [HttpPost]
        public ActionResult ActualizarCliente(Cliente entidad)
        {
            var respuesta = model.ActualizarCliente(entidad);
            if (respuesta.Codigo == 0)
            {
                Auditoria au = new Auditoria();
                au.TableName = "Clientes";
                au.Action = "UPDATE";
                au.Usuario = Session["NombreUsuario"].ToString();
                modelA.AgregarAuditoria(au);
                return RedirectToAction("MostrarClientes");
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult EliminarCliente(long id)
        {
            var respuesta = model.EliminarCliente(id);
            
            if (respuesta.Codigo == 0)
            {
                
                Auditoria au = new Auditoria();
                au.TableName = "Clientes";
                au.Action = "INACTIVAR";
                au.Usuario = Session["NombreUsuario"].ToString();
                
                var Autoria = modelA.AgregarAuditoria(au);
                return RedirectToAction("MostrarClientes");
              
            }
            else
            {
                return View();
            }
        }


    }
}