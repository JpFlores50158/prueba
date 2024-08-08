using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_TrabajoFidelitas.Entidades
{
    public class Reporte
    {
        public DateTime Fecha { get; set; }
        public int CantidadCitas { get; set; }
        public string NombreSucursal { get; set; }
        public string NombreServicio { get; set; }
        public string Placa { get; set; }
    }
    public class ConfirmacionReporte
    {

        public int Codigo { get; set; }
        public string Detalle { get; set; }
        public object Datos { get; set; }
        public object Dato { get; set; }
    }
}