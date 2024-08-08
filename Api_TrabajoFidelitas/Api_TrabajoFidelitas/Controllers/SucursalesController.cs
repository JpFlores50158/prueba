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
    public class SucursalesController : ApiController
    {

        [HttpGet]
        [Route("Sucursal/ConsultarSucursal")]
        public ConfirmacionSucursal ConsultarSucursal()
        {
            var respuesta = new ConfirmacionSucursal();

            try
            {
                using (var db = new MotoresBritanicosEntities())
                {
                    var datos = db.ConsultarSucursales().ToList();

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
        [Route("Sucursal/AgregarSucursal")]
        public ConfirmacionSucursal AgregarSucursal(Sucursal entidad)
        {
            var respuesta = new ConfirmacionSucursal();

            try
            {
                using (var db = new MotoresBritanicosEntities())
                {
                    var resp = db.AgregarSucursal(entidad.nombreSucursal, entidad.direccionSucursal, entidad.idCiudadSucursal);

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

        [Route("Sucursal/TraerSucursal")]
        [HttpGet]
        public ConfirmacionSucursal TraerSucursal(long id)
        {
            var respuesta = new ConfirmacionSucursal();

            try
            {
                using (var db = new MotoresBritanicosEntities())
                {
                    var datos = db.ObtenerSucursalPorId(id).FirstOrDefault();

                    if (datos != null)
                    {
                        respuesta.Codigo = 0;
                        respuesta.Detalle = string.Empty;
                        respuesta.Dato = datos;
                    }
                    else
                    {
                        respuesta.Codigo = -1;
                        respuesta.Detalle = "No se encontró la información respectiva";
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


        [HttpPut]
        [Route("Sucursal/ActualizarSucursal")]
        public ConfirmacionSucursal ActualizarSucursal(Sucursal entidad)
        {
            var respuesta = new ConfirmacionSucursal();

            try
            {
                using (var db = new MotoresBritanicosEntities())
                {
                    var resp = db.ActualizarSucursal(entidad.idSucursal, entidad.nombreSucursal, entidad.direccionSucursal, entidad.idCiudadSucursal, entidad.estado);

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
        [Route("Sucursal/InactivarSucursal")]
        public ConfirmacionSucursal InactivarSucursal(long id)
        {
            var respuesta = new ConfirmacionSucursal();

            try
            {
                using (var db = new MotoresBritanicosEntities())
                {
                    
                    var resp = db.InactivarSucursal(id);

                    if (resp > 0)
                    {
                        respuesta.Codigo = 0;
                        respuesta.Detalle = "Sucursal inactivada exitosamente";
                    }
                    else
                    {
                        respuesta.Codigo = -1;
                        respuesta.Detalle = "No se pudo inactivar la sucursal";
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
        [HttpGet]
        [Route("Sucursal/ConsultarCuidades")]
        public ConfirmacionCuidades ConsultarCuidades()
        {
            var respuesta = new ConfirmacionCuidades();

            try
            {
                using (var db = new MotoresBritanicosEntities())
                {
                    var datos = db.ConsultarCuidades().ToList();

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

    }
}
