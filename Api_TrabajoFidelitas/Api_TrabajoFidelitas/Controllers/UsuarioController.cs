using Api_TrabajoFidelitas.Entidades;
using Api_TrabajoFidelitas.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api_TrabajoFidelitas.Controllers
{
    public class UsuarioController : ApiController
    {
        [HttpPost]
        [Route("Usuarios/InicioSesion")]
        public ConfirmacionUsuarios IniciarSesionUsuario(Usuario entidad)
        {
            var respuesta = new ConfirmacionUsuarios();

            try
            {
                using (var db = new MotoresBritanicosEntities())
                {
                    var datos = db.IniciarSesionUsuario(entidad.emailUsuario, entidad.contrasenaUsuario).FirstOrDefault();

                    if (datos != null)
                    {


                        respuesta.Codigo = 0;
                        respuesta.Detalle = string.Empty;
                        respuesta.Dato = datos;




                    }
                    else
                    {
                        respuesta.Codigo = -1;
                        respuesta.Detalle = "No se pudo validar su información en el inicio sesion";
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

        [HttpPost]
        [Route("Usuarios/RegistrarUsuario")]
        public Confirmacion RegistrarUsuario(Usuario entidad)
        {
            var respuesta = new Confirmacion();

            try
            {
                using (var db = new MotoresBritanicosEntities())
                {
                    var resp = db.RegistrarUsuario(entidad.contrasenaUsuario, entidad.nombreUsuario, entidad.emailUsuario);

                    if (resp > 0)
                    {
                        respuesta.Codigo = 0;
                        respuesta.Detalle = string.Empty;
                    }
                    else
                    {
                        respuesta.Codigo = -1;
                        respuesta.Detalle = "Su información ya se encuentra registrada";
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
        [Route("Usuarios/ConsultarUsuarios")]
        public ConfirmacionUsuarios ConsultarUsuarios()
        {
            var respuesta = new ConfirmacionUsuarios();

            try
            {
                using (var db = new MotoresBritanicosEntities())
                {
                    var datos = db.ConsultarUsuarios().ToList();

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
                respuesta.Detalle = "Se presentó un error en el sistema";
            }

            return respuesta;
        }
        [HttpGet]
        [Route("Usuarios/ConsultarUsuario")]
        public ConfirmacionUsuarios ConsultarUsuario(long id)
        {
            var respuesta = new ConfirmacionUsuarios();

            try
            {
                using (var db = new MotoresBritanicosEntities())
                {
                    var datos = db.ConsultarUsuario(id).FirstOrDefault();

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
        [HttpDelete]
        [Route("Usuarios/EliminarUsuario")]
        public Confirmacion EliminarUsuario(long id)
        {
            var respuesta = new Confirmacion();

            try
            {
                using (var db = new MotoresBritanicosEntities())
                {
                    var resp = db.EliminarUsuario(id);

                    if (resp > 0)
                    {


                        respuesta.Codigo = 0;
                        respuesta.Detalle = string.Empty;


                    }
                    else
                    {
                        respuesta.Codigo = -1;
                        respuesta.Detalle = "No se pudo eliminar";
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
        [HttpDelete]
        [Route("Usuarios/InactivarUsuario")]
        public Confirmacion InactivarUsuario(long id)
        {
            var respuesta = new Confirmacion();

            try
            {
                using (var db = new MotoresBritanicosEntities())
                {
                    var resp = db.InactivarUsuario(id);

                    if (resp > 0)
                    {


                        respuesta.Codigo = 0;
                        respuesta.Detalle = string.Empty;


                    }
                    else
                    {
                        respuesta.Codigo = -1;
                        respuesta.Detalle = "No se pudo inactivar";
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
        [Route("Usuarios/ConsultarRoles")]
        public ConfirmacionRol ConsultarRoles()
        {
            var respuesta = new ConfirmacionRol();

            try
            {
                using (var db = new MotoresBritanicosEntities())
                {
                    var datos = db.consultarRoles().ToList();

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
                respuesta.Detalle = "Se presentó un error en el sistema";
            }

            return respuesta;
        }
        [HttpPut]
        [Route("Usuarios/ActualizarUsuario")]
        public Confirmacion ActualizarUsuario(Usuario entidad)
        {
            var respuesta = new Confirmacion();

            try
            {
                using (var db = new MotoresBritanicosEntities())
                {
                    var resp = db.ActualizarUsuario(entidad.idUsuario, entidad.nombreUsuario, entidad.contrasenaUsuario, entidad.emailUsuario, Convert.ToInt32(entidad.idRol), entidad.estado);

                    if (resp > 0)
                    {
                        respuesta.Codigo = 0;
                        respuesta.Detalle = string.Empty;
                    }
                    else
                    {
                        respuesta.Codigo = -1;
                        respuesta.Detalle = "Su información ya se encuentra registrada";
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