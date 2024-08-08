using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Web_TrabajoFidelitas.Entidades;

namespace Web_TrabajoFidelitas.Models
{
    public class ReporteModel
    {
        public async Task<byte[]> ObtenerReporteAsync()
        {
            using (var client = new HttpClient())
            {
                // Configura la URL del endpoint
                string url = "http://localhost:5024/api/Reporte/conexionDocker";

                // Realiza la solicitud GET al endpoint
                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    // Lee el contenido del archivo como un array de bytes
                    return await response.Content.ReadAsByteArrayAsync();
                }
                else
                {
                    // Maneja el caso en que la solicitud no fue exitosa
                    throw new Exception($"Error al obtener el reporte: {response.ReasonPhrase}");
                }
            }
        }

    }
}