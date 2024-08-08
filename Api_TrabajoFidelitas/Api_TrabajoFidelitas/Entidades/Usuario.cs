using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_TrabajoFidelitas.Entidades
{
    public class Usuario
    {
        public long idUsuario { get; set; }
        public string nombreUsuario { get; set; }
        public string emailUsuario { get; set; }
        public string contrasenaUsuario { get; set; }
        public bool estado { get; set; }
        public long idRol { get; set; }
        public string nombreRol { get; set; }

    }
    public class ConfirmacionUsuarios
    {
        public int Codigo { get; set; }
        public string Detalle { get; set; }
        public object Datos { get; set; }
        public object Dato { get; set; }
    }

}