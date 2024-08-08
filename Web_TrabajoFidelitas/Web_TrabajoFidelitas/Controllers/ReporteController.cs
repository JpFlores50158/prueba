using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_TrabajoFidelitas.Models;
using Web_TrabajoFidelitas.Entidades;
using System.Reflection;

namespace Web_TrabajoFidelitas.Controllers
{
    [FiltroSeguridad]
    public class ReporteController : Controller
    {
        public async Task<ActionResult> MostrarReportes()
        {
            //ReporteModel model = new ReporteModel();

            //try
            //{
            //    var reporteBytes = await model.ObtenerReporteAsync();

            //    return File(reporteBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Reporte.xlsx");
            //}
            //catch (Exception ex)
            //{
            //    ViewBag.Error = ex.Message;
            //    return View("Error");
            //}
            CitasModel modelCi = new CitasModel();
            AutomovilModel modelAuto = new AutomovilModel();
            ClienteModel modelCl = new ClienteModel();
            

            var respuesta = modelCi.CitaSemanaActual();
            if (respuesta.Codigo == 0)
            {
                var respuestaCi = modelCi.TraerCita();
                var respAuto = modelAuto.ConsultarAutomoviles();
                var respCl = modelCl.ConsultarClientes();
                ViewBag.CantCitas = respuestaCi.Datos.Count();
                ViewBag.CantAutos = respAuto.Datos.Count();
                ViewBag.CantClientes = respCl.Datos.Count();

                return View(respuesta.Datos);
            }
            else
            {
                var respuestaCi = modelCi.TraerCita();
                var respAuto = modelAuto.ConsultarAutomoviles();
                var respCl = modelCl.ConsultarClientes();
                ViewBag.CantCitas = respuestaCi.Datos.Count();
                ViewBag.CantAutos = respAuto.Datos.Count();
                ViewBag.CantClientes = respCl.Datos.Count();
                return View(new List<Citas>());
            }

            return View();
        }
    }
}