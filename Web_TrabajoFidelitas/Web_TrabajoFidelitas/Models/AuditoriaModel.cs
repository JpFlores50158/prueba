using System.Configuration;

using System.Net.Http;
using System.Net.Http.Json;

using Web_TrabajoFidelitas.Entidades;
namespace Web_TrabajoFidelitas.Models
{
    public class AuditoriaModel
    {
        public ConfirmacionAuditoria ConsultarAuditoria()
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlWebApi"] + "Auditoria/ConsultarAuditoria";
                var respuesta = client.GetAsync(url).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<ConfirmacionAuditoria>().Result;
                else
                    return null;
            }
        }

        public ConfirmacionAuditoria AgregarAuditoria(Auditoria entidad)
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlWebApi"] + "Auditoria/AgregarAuditoria";
                JsonContent jsonEntidad = JsonContent.Create(entidad);
                var respuesta = client.PostAsync(url, jsonEntidad).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<ConfirmacionAuditoria>().Result;
                else
                    return null;
            }
        }

    }
}