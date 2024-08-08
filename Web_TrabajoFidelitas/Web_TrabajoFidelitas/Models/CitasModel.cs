using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Web;
using Web_TrabajoFidelitas.Entidades;
using WebGrease.Activities;

namespace Web_TrabajoFidelitas.Models
{
        public class CitasModel
        {
            public ConfirmacionCita TraerCita()
            {
                using (var client = new HttpClient())
                {
                    string url = ConfigurationManager.AppSettings["urlWebApi"] + "Citas/TraerCita";
                    var respuesta = client.GetAsync(url).Result;

                    if (respuesta.IsSuccessStatusCode)
                        return respuesta.Content.ReadFromJsonAsync<ConfirmacionCita>().Result;
                    else
                        return null;
                }
            }

         public ConfirmacionCita ConsultarCita(long id)
            {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlWebApi"] + "Citas/ConsultarCita?id=" + id;
                var respuesta = client.GetAsync(url).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<ConfirmacionCita>().Result;
                else
                    return null;
            }
         }

        public ConfirmacionCita Editarcita(Citas entidad)
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlWebApi"] + "Citas/EditarCita";
                JsonContent jsonEntidad = JsonContent.Create(entidad);
                var respuesta = client.PutAsync(url, jsonEntidad).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<ConfirmacionCita>().Result;
                else
                    return null;
            }
        }

        public ConfirmacionCita InactivarCita(long id)
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlWebApi"] + "Citas/sp_EliminarCita?id=" + id;
                var respuesta = client.DeleteAsync(url).Result;
                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<ConfirmacionCita>().Result;
                else
                    return null;
            }
        }
        public ConfirmacionCita EliminarCita(long id)
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlWebApi"] + "Citas/EliminarCitaTotal?id=" + id;
                var respuesta = client.DeleteAsync(url).Result;
                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<ConfirmacionCita>().Result;
                else
                    return null;
            }
        }

        public ConfirmacionCita Agregarcita(Citas entidad)
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlWebApi"] + "Citas/AgregarCita";
                JsonContent jsonEntidad = JsonContent.Create(entidad);
                var respuesta = client.PostAsync(url, jsonEntidad).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<ConfirmacionCita>().Result;
                else
                    return null;
            }
        }
        public ConfirmacionServicios ConsultarServicios()
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlWebApi"] + "Servicios/ConsultarServicios";
                var respuesta = client.GetAsync(url).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<ConfirmacionServicios>().Result;
                else
                    return null;
            }
        }
        public ConfirmacionCita ConsultarCitaporSucursal(int idSucursal)
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlWebApi"] + "Citas/ConsultarCitasPorSucursal?idSucursal=" + idSucursal;
                var respuesta = client.GetAsync(url).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<ConfirmacionCita>().Result;
                else
                    return null;
            }
        }
            public Confirmacion ConfirmacionCita(Citas entidad)
        {
            // LLAMAR A LA API
            using (var client = new HttpClient())
            {

                string url = ConfigurationManager.AppSettings["urlWebApi"] + "Citas/ConfirmacionCita";
                JsonContent jsonEntidad = JsonContent.Create(entidad);
                var respuesta = client.PostAsync(url, jsonEntidad).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<Confirmacion>().Result;
                else
                    return null;
            }
        }

        public ConfirmacionServicios ConsultarServicio(long id)
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlWebApi"] + "Servicios/TraerServicio?id="+id;
                var respuesta = client.GetAsync(url).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<ConfirmacionServicios>().Result;
                else
                    return null;
            }
        }
        public ConfirmacionCita CitaSemanaActual()
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlWebApi"] + "Citas/CitasDeLaSemanaActual";
                var respuesta = client.GetAsync(url).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<ConfirmacionCita>().Result;
                else
                    return null;
            }
        }
    }

       
}