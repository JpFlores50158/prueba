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
    public class SucursalController : Controller
    {
        SucursalModel model = new SucursalModel();
        AuditoriaModel modelA = new AuditoriaModel();
        [HttpGet]
        public ActionResult MostrarSucursales()
        {
            var respuesta = model.ConsultarSucursal();
            if (respuesta.Codigo == 0)
            {
              
                return View(respuesta.Datos);
            }
            else
            {
                return View(new List<Sucursal>());
            }
        }
        [HttpGet]
        public ActionResult NuevoSucursal()
        {
            CargarViewBagCategorias();
            return View();
        }
        [HttpPost]
        public ActionResult NuevoSucursal(Sucursal entidad)
        {
            var respuesta = model.AgregarSucursal(entidad);
            if (respuesta.Codigo == 0)
            {
                Auditoria au = new Auditoria();
                au.TableName = "Citas";
                au.Action = "INSERT";
                au.Usuario = Session["NombreUsuario"].ToString();
                modelA.AgregarAuditoria(au);
                return RedirectToAction("MostrarSucursales");
            }
            else
            {
                return View(new List<Sucursal>());
            }
        }
        [HttpGet]
        public ActionResult ActualizarSucursal(long id)
        {
            var respuesta = model.TraerSucursal(id);
            CargarViewBagCategorias();
            return View(respuesta.Dato);
        }
        [HttpPost]
        public ActionResult ActualizarSucursal(Sucursal entidad)
        {
            var respuesta = model.ActualizarSucursal(entidad);
            if (respuesta.Codigo == 0)
            {
                Auditoria au = new Auditoria();
                au.TableName = "Citas";
                au.Action = "UPDATE";
                au.Usuario = Session["NombreUsuario"].ToString();
                modelA.AgregarAuditoria(au);
                return RedirectToAction("MostrarSucursales");
            }
            else
            {
                return View();
            }
        }
   
        [HttpGet]
        public ActionResult InactivarSucursal(long id)
        {
            var respuesta = model.InactivarSucursal(id);

            if (respuesta.Codigo == 0)
            {
                Auditoria au = new Auditoria();
                au.TableName = "Citas";
                au.Action = "DELETE";
                au.Usuario = Session["NombreUsuario"].ToString();
                modelA.AgregarAuditoria(au);
                return RedirectToAction("MostrarSucursales");
            }
            else
            {
                return View();
            }
        }
        private void CargarViewBagCategorias()
        {
            var respuesta = model.ConsultarCuidades();
            var cuidades = new List<SelectListItem>();

            cuidades.Add(new SelectListItem { Text = "Seleccione una categoría", Value = "" });
            foreach (var item in respuesta.Datos)
                cuidades.Add(new SelectListItem { Text = item.NombreCiudad, Value = item.IdCiudad.ToString() });

            ViewBag.Cuidades = cuidades;
        }



    }
}