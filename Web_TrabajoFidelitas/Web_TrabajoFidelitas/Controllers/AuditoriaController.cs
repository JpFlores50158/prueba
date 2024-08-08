using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Web;
using System.Web.Mvc;
using Web_TrabajoFidelitas.Entidades;
using Web_TrabajoFidelitas.Models;

namespace Web_TrabajoFidelitas.Controllers
{
    [FiltroSeguridad]
    public class AuditoriaController : Controller
    {
        AuditoriaModel model = new AuditoriaModel();

        [HttpGet]
        public ActionResult MostrarAuditoria()
        {
            var respuesta = model.ConsultarAuditoria();
            if (respuesta.Codigo == 0)
            {
                return View(respuesta.Datos);
            }
            else
            {
                return View(new List<Auditoria>());
            }
        }
    }
}