using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_TrabajoFidelitas.Entidades
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
            public List<Usuario> Datos { get; set; }
            public Usuario Dato { get; set; }
        }
    }
