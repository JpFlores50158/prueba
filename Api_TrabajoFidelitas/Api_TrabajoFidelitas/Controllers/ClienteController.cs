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
    public class ClienteController : ApiController
    {
        [HttpGet]
        [Route("Cliente/ConsultarClientes")]
        public ConfirmacionCliente ConsultarClientes()
        {
            var respuesta = new ConfirmacionCliente();

            try
            {
                using (var db = new MotoresBritanicosEntities())
                {
                    var datos = db.ConsultarClientes().ToList();

                    if (datos.Count >0)
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
        [HttpGet]
        [Route("Cliente/ConsultarCliente")]
        public ConfirmacionCliente ConsultarCliente(long id)
        {
            var respuesta = new ConfirmacionCliente();

            try
            {
                using (var db = new MotoresBritanicosEntities())
                {
                    var datos = db.ConsultarCliente(id).FirstOrDefault();

                    if (datos != null)
                    {


                        respuesta.Codigo = 0;
                        respuesta.Detalle = string.Empty;
                        respuesta.Dato = datos;

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
        [Route("Cliente/AgregarCliente")]
        public ConfirmacionCliente AgregarCliente(Cliente entidad)
        {
            var respuesta = new ConfirmacionCliente();

            try
            {
                using (var db = new MotoresBritanicosEntities())
                {
                    var resp = db.AgregarCliente(entidad.nombreCliente,entidad.telefonoCliente,entidad.direccionCliente,entidad.emailCliente);

                    if (resp>0)
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
    
    [HttpPut]
    [Route("Cliente/ActualizarCliente")]
    public ConfirmacionCliente ActualizarCliente(Cliente entidad)
    {
        var respuesta = new ConfirmacionCliente();

        try
        {
            using (var db = new MotoresBritanicosEntities())
            {
                var resp = db.ActualizarCliente(entidad.idCliente,entidad.nombreCliente, entidad.telefonoCliente, entidad.direccionCliente, entidad.emailCliente,entidad.estado);

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
        [HttpDelete]
        [Route("Cliente/EliminarCliente")]
        public Confirmacion EliminarCliente(long id)
        {
            var respuesta = new Confirmacion();

            try
            {
                using (var db = new MotoresBritanicosEntities())
                {
                    var resp = db.EliminarCliente(id);

                    if (resp > 0)
                    {
                        respuesta.Codigo = 0;
                        respuesta.Detalle = string.Empty;
                    }
                    else
                    {
                        respuesta.Codigo = -1;
                        respuesta.Detalle = "El producto no se pudo eliminar";
                    }
                }
            }
            catch (Exception)
            {
                respuesta.Codigo = -1;
                respuesta.Detalle = "Se presentó un error en el sistema";
            }

            return respuesta;
        }
    }

}

