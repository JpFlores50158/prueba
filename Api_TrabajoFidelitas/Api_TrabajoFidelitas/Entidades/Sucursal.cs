using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_TrabajoFidelitas.Entidades
{
    public class Sucursal
    {

        public int idSucursal { get; set; }

        public string nombreSucursal { get; set;}

        public string direccionSucursal { get;set; }

        public int idCiudadSucursal { get; set; }

        public bool estado { get; set; }
        public string nombreCiudad { get; set; }
    }

    public class ConfirmacionSucursal
    {
        public int Codigo { get; set; }
        public string Detalle { get; set; }
        public object Datos { get; set; }
        public object Dato { get; set; }
    }
}