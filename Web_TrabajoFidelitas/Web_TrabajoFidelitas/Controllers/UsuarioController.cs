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
    public class UsuarioController : Controller
    {

        UsuarioModel modelo = new UsuarioModel();

        AuditoriaModel modelA = new AuditoriaModel();
        [HttpGet]
        public ActionResult IniciarSesion()
        {
            return View();
        }

        [HttpPost]
        public ActionResult IniciarSesion(Usuario entidad)
        {
            var respuesta = modelo.InicioSesion(entidad);

            if (respuesta.Codigo == 0)
            {
               
                Session["NombreUsuario"] = respuesta.Dato.nombreUsuario;
                Session["RolUsuario"] = respuesta.Dato.idRol;
                Session["NombreRol"] = respuesta.Dato.nombreRol;
                Session["CorreoUsuario"] = respuesta.Dato.emailUsuario;
                Session["idUsuario"] = respuesta.Dato.idUsuario;

                return RedirectToAction("Index", "Home");
            }
            else
            {


                ViewBag.MsjPantalla = respuesta.Detalle;
                return View();
            }
        }

        [HttpGet]
        public ActionResult MostrarUsuarios()
        {
            var respuesta = modelo.ConsultarUsuarios();
            if (respuesta.Codigo == 0)
            {
                return View(respuesta.Datos);
            }
            else
            {
                return View(new List<Usuario>());
            }
        }

        [HttpGet]
        public ActionResult RegistrarUsuario()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult RegistrarUsuario(Usuario entidad)
        {
            var respuesta = modelo.RegistrarUsuario(entidad);

            if (respuesta.Codigo == 0)
                return RedirectToAction("MostrarUsuarios", "Usuario");
            else
            {
                CargarViewBagRoles();
                ViewBag.MsjPantalla = respuesta.Detalle;
                return View();
            }
        }

        [HttpGet]
        public ActionResult ActualizarUsuario(long id)
        {
            var respuesta = modelo.ConsultarUsuario(id);
            
            if (respuesta.Codigo == 0)
            {
                CargarViewBagRoles();
                return View(respuesta.Dato);
            }
            else
            {
                CargarViewBagRoles();
                return View(new List<Usuario>());
            }
        }
        [HttpPost]
        public ActionResult ActualizarUsuario(Usuario entidad)
        {
            var respuesta = modelo.ActualizarUsuario(entidad);

            if (respuesta.Codigo == 0) {
                Auditoria au = new Auditoria();
                au.TableName = "Usuarios";
                au.Action = "UPDATE";
                au.Usuario = Session["NombreUsuario"].ToString();

                var Autoria = modelA.AgregarAuditoria(au);
                return RedirectToAction("MostrarUsuarios", "Usuario");
            }


               
            else
            {
                CargarViewBagRoles();
                ViewBag.MsjPantalla = respuesta.Detalle;
                return View();
            }
        }
        [HttpGet]
        public ActionResult EliminarUsuario(long id)
        {
            var respuesta = modelo.EliminarUsuario(id);

            if (respuesta.Codigo == 0)
            {

                Auditoria au = new Auditoria();
                au.TableName = "Usuarios";
                au.Action = "DELETE";
                au.Usuario = Session["NombreUsuario"].ToString();

                var Autoria = modelA.AgregarAuditoria(au);
                return RedirectToAction("MostrarUsuarios");

            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult InactivarUsuario(long id)
        {
            var respuesta = modelo.InactivarUsuario(id);

            if (respuesta.Codigo == 0)
            {

                Auditoria au = new Auditoria();
                au.TableName = "Usuarios";
                au.Action = "INACTIVAR";
                au.Usuario = Session["NombreUsuario"].ToString();

                var Autoria = modelA.AgregarAuditoria(au);
                return RedirectToAction("MostrarUsuarios");

            }
            else
            {
                return View();
            }
        }



        [FiltroSeguridad]
        [HttpGet]
        public ActionResult CerrarSesion()
        {
            Session.Clear();
            return RedirectToAction("IniciarSesion", "Usuario");
        }

        private void CargarViewBagRoles()
        {
            var respuesta = modelo.ConsultarRoles();
            var Roles = new List<SelectListItem>();

            Roles.Add(new SelectListItem { Text = "Seleccione una rol", Value = "" });
            foreach (var item in respuesta.Datos)
                Roles.Add(new SelectListItem { Text = item.nombreRol, Value = item.idRol.ToString() });

            ViewBag.Roles = Roles;
        }
    }
}