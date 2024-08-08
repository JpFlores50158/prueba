using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_TrabajoFidelitas.Entidades
{
    public class Rol
    {
        public int idRol { get; set; }
        public string nombreRol { get; set; }

    }
    public class ConfirmacionRol
    {
        public int Codigo { get; set; }
        public string Detalle { get; set; }
        public List<Rol> Datos { get; set; }
        public object Dato { get; set; }
    }
}