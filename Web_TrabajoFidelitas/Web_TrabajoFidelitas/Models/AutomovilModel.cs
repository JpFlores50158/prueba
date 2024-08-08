using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Web;
using Web_TrabajoFidelitas.Entidades;

namespace Web_TrabajoFidelitas.Models
{
    public class AutomovilModel
    {
        // ---------------------- MOSTRAR -----------------------
        public ConfirmacionAutomovil ConsultarAutomoviles() 
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlWebApi"] + "Automovil/ConsultarAutomoviles";
                var respuesta = client.GetAsync(url).Result;

                if(respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<ConfirmacionAutomovil>().Result;
                else
                    return null;
            }
        }

        // ---------------------- REGISTRO ----------------------
        public ConfirmacionAutomovil ConsultarIdsClientes()
        {
            // LLAMAR A LA API
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlWebApi"] + "Automovil/ConsultarIdsClientes";
                var respuesta = client.GetAsync(url).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadFromJsonAsync<ConfirmacionAutomovil>().Result;
                }
                return null;
            }
        }

        public ConfirmacionAutomovil AgregarAutomovil(Automovil entidad)
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlWebApi"] + "Automovil/AgregarAutomovil";
                JsonContent jsonEntidad = JsonContent.Create(entidad);
                var respuesta = client.PostAsync(url, jsonEntidad).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<ConfirmacionAutomovil>().Result;
                else
                    return null;
            }
        }

        // --------------------- ACTUALIZAR ---------------------
        public ConfirmacionAutomovil ConsultarAutomovil(long id)
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlWebApi"] + "Automovil/ConsultarAutomovil?id=" + id;
                var respuesta = client.GetAsync(url).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<ConfirmacionAutomovil>().Result;
                else
                    return null;
            }
        }

        public ConfirmacionAutomovil ActualizarAutomovil(Automovil entidad)
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlWebApi"] + "Automovil/ActualizarAutomovil";
                JsonContent jsonEntidad = JsonContent.Create(entidad);
                var respuesta = client.PutAsync(url, jsonEntidad).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<ConfirmacionAutomovil>().Result;
                else
                    return null;
            }
        }

        // ---------------------- ELIMINAR ----------------------
        public Confirmacion EliminarAutomovil(long id)
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlWebApi"] + "Automovil/EliminarAutomovil?id=" + id;
                var respuesta = client.DeleteAsync(url).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<Confirmacion>().Result;
                else
                    return null;
            }
        }
    }
}