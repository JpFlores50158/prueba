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
    [FiltroAdmin]
    public class CitaController : Controller
    {
        AuditoriaModel modelA = new AuditoriaModel();
        ClienteModel modelCl = new ClienteModel();
        CitasModel model = new CitasModel();
        SucursalModel modelSu = new SucursalModel();
        AutomovilModel modelAu = new AutomovilModel();

        [HttpGet]
        public ActionResult MostrarCitas()
        {
            var respuesta = model.TraerCita();
            if (respuesta.Codigo == 0)
            {
                CargarViewBagSucursal();
                CargarViewBagSucursalNombre();


                return View(respuesta.Datos);
            }
            else
            {
                CargarViewBagSucursal();
                CargarViewBagSucursalNombre();
                return View(new List<Citas>());
            }
        }
        public ActionResult NuevoCita()
        {
            CargarViewBagAutomovil();
            CargarViewBagSucursal();
            CargarViewBagServicios();
            CargarViewBagHoras();
            return View();
        }
        [HttpPost]
        public ActionResult NuevoCita(Citas entidad)
        {
            CitasModel MODELADO = new CitasModel();

            var consulta = modelAu.ConsultarAutomovil(entidad.idAutomovil);
            entidad.idCliente = consulta.Dato.idCliente;

           
            entidad.fechaHora = new DateTime(entidad.fechaHora.Year, entidad.fechaHora.Month, entidad.fechaHora.Day, entidad.HoraSeleccionada, 0, 0);

            var respuesta = model.Agregarcita(entidad);
            if (respuesta.Codigo == 0)
            {
                Auditoria au = new Auditoria();
                au.TableName = "Citas";
                au.Action = "INSERT";
                au.Usuario = Session["NombreUsuario"].ToString();
                modelA.AgregarAuditoria(au);
                entidad.correotipo = "Confirmacion";
                var cliente = modelCl.ConsultarCliente(entidad.idCliente);
                entidad.correoElect = cliente.Dato.emailCliente;

                var sucursal = modelSu.TraerSucursal(entidad.idSucursal);
                entidad.nombreSucursal = sucursal.Dato.nombreSucursal;

                var servicio = model.ConsultarServicio(entidad.idServicio);
                entidad.nombreServicio = servicio.Dato.NombreServicio;

                var placa = modelAu.ConsultarAutomovil(entidad.idAutomovil);
                entidad.placa = placa.Dato.placa;

                var mandar = MODELADO.ConfirmacionCita(entidad);

                return RedirectToAction("MostrarCitas");
            }
            else
            {
                ViewBag.MsjPantalla = "Debe seleccionar una hora entre 7am y 5pm, o ya hay una cita programada en esta hora.";
                CargarViewBagAutomovil();
                CargarViewBagSucursal();
                CargarViewBagServicios();
                CargarViewBagHoras(); // Asegúrate de cargar las opciones para el DropDownList de horas
                return View();
            }
        }

        [HttpGet]
        public ActionResult EditarCita(long id)
        {
            var respuesta = model.ConsultarCita(id);
            CargarViewBagAutomovil();
            CargarViewBagSucursal();
            CargarViewBagServicios();
            return View(respuesta.Dato);
        }
        [HttpPost]
        public ActionResult EditarCita(Citas entidad)
        {
            CitasModel MODELADO = new CitasModel();
            var consulta = modelAu.ConsultarAutomovil(entidad.idAutomovil);
            entidad.idCliente = consulta.Dato.idCliente;
            var respuesta = model.Editarcita(entidad);
            if (respuesta.Codigo == 0)
            {
                Auditoria au = new Auditoria();
                au.TableName = "Citas";
                au.Action = "UPDATE";
                au.Usuario = Session["NombreUsuario"].ToString();
                modelA.AgregarAuditoria(au);
                if (entidad.estado) {
                    entidad.correotipo = "Edicion";
                    var cliente = modelCl.ConsultarCliente(entidad.idCliente);
                    entidad.correoElect = cliente.Dato.emailCliente;

                    var sucursal = modelSu.TraerSucursal(entidad.idSucursal);
                    entidad.nombreSucursal = sucursal.Dato.nombreSucursal;

                    var servicio = model.ConsultarServicio(entidad.idServicio);
                    entidad.nombreServicio = servicio.Dato.NombreServicio;

                    var placa = modelAu.ConsultarAutomovil(entidad.idAutomovil);
                    entidad.placa = placa.Dato.placa;

                    var mandar = MODELADO.ConfirmacionCita(entidad);
                }
               
                return RedirectToAction("MostrarCitas");
            }
            else
            {
                ViewBag.MsjPantalla = "Tiene que ser de 7am a 5pm o ya hay una cita en esta hora ";
                CargarViewBagAutomovil();
                CargarViewBagSucursal();
                CargarViewBagServicios();
                return View();
            }
        }

        [HttpGet]
        public ActionResult InactivarCita(long id)
        {
            var respuesta = model.InactivarCita(id);

            if (respuesta.Codigo == 0)
            {
                Auditoria au = new Auditoria();
                au.TableName = "Citas";
                au.Action = "INACTIVAR";
                au.Usuario = Session["NombreUsuario"].ToString();
                modelA.AgregarAuditoria(au);
                return RedirectToAction("MostrarCitas");
            }
            else
            {
                return View();
            }

        }
        [HttpGet]
        public ActionResult Calendario(int idSucursal)
        {
            ViewBag.IdSucursal = idSucursal;
            return View();
        }

        [HttpGet]
        public ActionResult EliminarCita(long id)
        {
            var respuesta = model.EliminarCita(id);

            if (respuesta.Codigo == 0)
            {
                Auditoria au = new Auditoria();
                au.TableName = "Citas";
                au.Action = "DELETE";
                au.Usuario = Session["NombreUsuario"].ToString();
                modelA.AgregarAuditoria(au);
                return RedirectToAction("MostrarCitas");
            }
            else
            {
                return View();
            }

        }
        public ActionResult ObtenerEventos(DateTime start, DateTime end, int idSucursal)
        {
            try
            {
                var respuesta = model.ConsultarCitaporSucursal(idSucursal);

                if (respuesta.Codigo == 0)
                {
                    var eventos = respuesta.Datos
                        .Where(c => c.fechaHora >= start && c.fechaHora <= end)
                        .Select(c => new {
                            title = $"{c.nombreCliente} - {c.nombreServicio}",
                            start = c.fechaHora.ToString("yyyy-MM-ddTHH:mm:ss"),
                            description = $"Cliente: {c.nombreCliente}<br>Sucursal: {c.nombreSucursal}<br>Vehículo placa: {c.placa}<br>Comentarios: {c.comentarios}",
                            id = c.idCita
                        })
                        .ToList();

                    return Json(eventos, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new List<object>(), JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                return Json(new { error = ex.Message });
            }
        }


        private void CargarViewBagSucursal()
        {
            var respuesta = modelSu.ConsultarSucursal();
            var sucursales = new List<SelectListItem>();

            sucursales.Add(new SelectListItem { Text = "Seleccione una sucursal", Value = "" });
            foreach (var item in respuesta.Datos.Where(a => a.estado))
                sucursales.Add(new SelectListItem { Text = item.nombreSucursal, Value = item.idSucursal.ToString() });

            ViewBag.Sucursales = sucursales;
        }
        private void CargarViewBagSucursalNombre()
        {
            var respuesta = modelSu.ConsultarSucursal();
            var sucursales = new List<SelectListItem>();

            sucursales.Add(new SelectListItem { Text = "Seleccione una sucursal", Value = "" });
            foreach (var item in respuesta.Datos.Where(a => a.estado))
                sucursales.Add(new SelectListItem { Text = item.nombreSucursal, Value = item.nombreSucursal.ToString() });

            ViewBag.SucursalesNombre = sucursales;
        }
        private void CargarViewBagAutomovil()
        {
            var respuesta = modelAu.ConsultarAutomoviles();
            var automoviles = new List<SelectListItem>();

            automoviles.Add(new SelectListItem { Text = "Seleccione un automovil", Value = "" });
            foreach (var item in respuesta.Datos.Where(a => a.estado))
            {
                automoviles.Add(new SelectListItem { Text = item.placa, Value = item.idAutomovil.ToString() });
            }

            ViewBag.Automoviles = automoviles;
        }
        private void CargarViewBagServicios()
        {
            var respuesta = model.ConsultarServicios();
            var Servicios = new List<SelectListItem>();

            Servicios.Add(new SelectListItem { Text = "Seleccione un servicio", Value = "" });
            foreach (var item in respuesta.Datos.Where(a => a.estado))
                Servicios.Add(new SelectListItem { Text = item.NombreServicio, Value = item.IdServicio.ToString() });

            ViewBag.Servicios = Servicios;
        }
        private void CargarViewBagHoras()
        {
            // Crear una lista de SelectListItem para las horas disponibles (de 7am a 5pm)
            var horas = new List<SelectListItem>();
            for (int hora = 7; hora <= 17; hora++) // 17 = 5pm
            {
                horas.Add(new SelectListItem { Text = $"{hora}:00", Value = hora.ToString() });
            }
            ViewBag.Horas = horas;
        }

    }


    }
