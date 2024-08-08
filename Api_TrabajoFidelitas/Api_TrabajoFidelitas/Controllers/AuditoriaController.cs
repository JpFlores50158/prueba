using Api_TrabajoFidelitas.Entidades;
using Api_TrabajoFidelitas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api_TrabajoFidelitas.Controllers
{
    public class AuditoriaController : ApiController
    {
        [HttpGet]
        [Route("Auditoria/ConsultarAuditoria")]
        public ConfirmacionAuditoria ConsultarAuditoria()
        {
            var respuesta = new ConfirmacionAuditoria();

            try
            {
                using (var db = new MotoresBritanicosEntities())
                {
                    var datos = db.GetAuditLog().ToList();

                    if (datos.Count > 0)
                    {


                        respuesta.Codigo = 0;
                        respuesta.Detalle = string.Empty;
                        respuesta.Datos = datos;

                    }
                    else
                    {
                        respuesta.Codigo = -1;
                        respuesta.Detalle = "No se encontro informacion";
                    }
                }
            }
            catch (Exception)
            {
                respuesta.Codigo = -1;
                respuesta.Detalle = "Se presentó un error en el sistema,InicioSesion";
            }

            return respuesta;
        }
        [HttpPost]
        [Route("Auditoria/AgregarAuditoria")]
        public ConfirmacionAuditoria AgregarAuditoria(Auditoria entidad)
        {
            var respuesta = new ConfirmacionAuditoria();

            try
            {
                using (var db = new MotoresBritanicosEntities())
                {
                    var resp = db.AddAuditLog(entidad.TableName, entidad.Action, entidad.Usuario);

                    if (resp > 0)
                    {
                        respuesta.Codigo = 0;
                        respuesta.Detalle = string.Empty;
                    }
                    else
                    {
                        respuesta.Codigo = -1;
                        respuesta.Detalle = "No se pudo agregar";
                    }
                }
            }
            catch (Exception)
            {
                respuesta.Codigo = -1;
                respuesta.Detalle = "Se presentó un error en el sistema,InicioSesion";
            }

            return respuesta;
        }
    }
}
