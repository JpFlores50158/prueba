using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_TrabajoFidelitas.Entidades;
using Web_TrabajoFidelitas.Models;

namespace Web_TrabajoFidelitas.Controllers
{
    public class HomeController : Controller
    {
        SucursalModel modelSu = new SucursalModel();
        [FiltroSeguridad]
       
        public ActionResult Index()
        {
            CitasModel modelCi = new CitasModel();
            AutomovilModel modelAuto = new AutomovilModel();
            ClienteModel modelCl = new ClienteModel();
            CargarViewBagSucursal();
            var respuestaCi = modelCi.TraerCita();
            var respAuto = modelAuto.ConsultarAutomoviles();
            var respCl = modelCl.ConsultarClientes();
            ViewBag.CantCitas = respuestaCi.Datos.Count();
            ViewBag.CantAutos = respAuto.Datos.Count();
            ViewBag.CantClientes = respCl.Datos.Count();
            
            return View();
        }
        private void CargarViewBagSucursal()
        {
            var respuesta = modelSu.ConsultarSucursal();
            var sucursales = new List<SelectListItem>();

            sucursales.Add(new SelectListItem { Text = "Seleccione una sucursal", Value = "" });
            foreach (var item in respuesta.Datos)
                sucursales.Add(new SelectListItem { Text = item.nombreSucursal, Value = item.idSucursal.ToString() });

            ViewBag.Sucursales = sucursales;
        }

    }
}