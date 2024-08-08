using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_TrabajoFidelitas.Entidades
{
    public class Cita
    {
        public int idCita { get; set; }
        public int idCliente { get; set; }
        public int idAutomovil { get; set; }
        public int idSucursal { get; set; }
        public int idServicio { get; set; }
        public DateTime fechaHora { get; set;}
        public string comentarios { get; set; }
        public bool estado { get; set; }
        public string correoElect { get; set; }

        public string nombreSucursal { get; set; }
        public string placa { get; set; }
        public string nombreServicio { get; set; }
        public string nombreCliente { get; set; }

        public string correotipo { get; set; }


    }

    public class ConfirmacionCita
    {
        public int Codigo { get; set; }
        public string Detalle { get; set; }
        public object Datos { get; set; }
        public object Dato { get; set; }
    }
}