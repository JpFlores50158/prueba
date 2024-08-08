using Api_TrabajoFidelitas.Entidades;
using Api_TrabajoFidelitas.Models;
using System;
using System.Linq;
using System.Web.Http;

namespace Api_TrabajoFidelitas.Controllers
{
    public class AutomovilController : ApiController
    {
        // ----------------------- MOSTRAR
        [Route("Automovil/ConsultarAutomoviles")]
        [HttpGet]
        public ConfirmacionAutomovil ConsultarAutomoviles()
        {
            var respuesta = new ConfirmacionAutomovil();

            try
            {
                using (var db = new MotoresBritanicosEntities())
                {
                    var datos = db.ConsultarAutomoviles().ToList();

                    if (datos.Count > 0)
                    {                      
                            respuesta.Codigo = 0;
                            respuesta.Detalle = string.Empty;
                            respuesta.Datos = datos;
                        
                    }
                    else
                    {
                        respuesta.Codigo = -1;
                        respuesta.Detalle = "No se encontró información de los automoviles";
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

        // ----------------------- AGREGAR

        [Route("Automovil/ConsultarIdsClientes")]
        [HttpGet]
        public ConfirmacionIdsClientes ConsultarIdsClientes()
        {
            var respuesta = new ConfirmacionIdsClientes();

            try
            {
                using (var db = new MotoresBritanicosEntities())
                {
                    var datos = db.ConsultarIdsClientes().ToList();

                    if (datos.Count > 0)
                    {
                        respuesta.Codigo = 0;
                        respuesta.Detalle = string.Empty;
                        respuesta.Datos = datos;
                    }
                    else
                    {
                        respuesta.Codigo = -1;
                        respuesta.Detalle = "No se encontraron resultados";
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

        [Route("Automovil/AgregarAutomovil")]
        [HttpPost]
        public ConfirmacionAutomovil AgregarAutomovil(Automovil entidad)
        {
            var respuesta = new ConfirmacionAutomovil();

            try
            {
                using (var db = new MotoresBritanicosEntities())
                {
                    var resp = db.AgregarAutomovil(entidad.idCliente, entidad.placa, entidad.marca, entidad.modelo, entidad.ano);

                    if (resp > 0)
                    {
                        respuesta.Codigo = 0;
                        respuesta.Detalle = string.Empty;
                    }
                    else
                    {
                        respuesta.Codigo = -1;
                        respuesta.Detalle = "No se pudo agregar un Automovil";
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

        // ----------------------- ACTUALIZAR
        [Route("Automovil/ConsultarAutomovil")]
        [HttpGet]
        public ConfirmacionAutomovil ConsultarAutomovil(long id)
        {
            var respuesta = new ConfirmacionAutomovil();

            try
            {
                using (var db = new MotoresBritanicosEntities())
                {
                    var datos = db.ConsultarAutomovil(id).FirstOrDefault();

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

        [Route("Automovil/ActualizarAutomovil")]
        [HttpPut]
        public ConfirmacionAutomovil ActualizarAutomovil(Automovil entidad)
        {
            var respuesta = new ConfirmacionAutomovil();

            try
            {
                using (var db = new MotoresBritanicosEntities())
                {
                    var resp = db.ActualizarAutomovil(entidad.idAutomovil, entidad.idCliente, entidad.placa, entidad.marca, entidad.modelo, entidad.ano ,entidad.estado);

                    if (resp > 0)
                    {
                        respuesta.Codigo = 0;
                        respuesta.Detalle = string.Empty;
                    }
                    else
                    {
                        respuesta.Codigo = -1;
                        respuesta.Detalle = "No se pudo editar el automovil";
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

        // ----------------------- ELIMINAR
        [Route("Automovil/EliminarAutomovil")]
        [HttpDelete]
        public Confirmacion EliminarProducto(long id)
        {
            var respuesta = new Confirmacion();

            try
            {
                using (var db = new MotoresBritanicosEntities())
                {
                    var resp = db.EliminarAutomovil(id);

                    if (resp > 0)
                    {
                        respuesta.Codigo = 0;
                        respuesta.Detalle = "El automovil se inactivó correctamente";
                    }
                    else
                    {
                        respuesta.Codigo = -1;
                        respuesta.Detalle = "El automovil no se pudo eliminar";
                    }
                }
            }
            catch (Exception)
            {
                respuesta.Codigo = -1;
                respuesta.Detalle = "Se presento un error en el sistema";
            }
            return respuesta;
        }
    }
}
