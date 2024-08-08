using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_TrabajoFidelitas.Entidades
{
    public class Servicios
    {

        public int IdServicio { get; set; }

        public string NombreServicio { get; set; }

        public decimal PrecioServicio { get; set; }

        public string DescripcionServicio { get; set; }

        public bool Estado { get; set; }
    }
    public class ConfirmacionServicios
    {
        public int Codigo { get; set; }
        public string Detalle { get; set; }
        public object Datos { get; set; }
        public object Dato { get; set; }
    }
}