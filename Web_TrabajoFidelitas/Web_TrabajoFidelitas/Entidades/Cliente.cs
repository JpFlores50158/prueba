using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_TrabajoFidelitas.Entidades
{
    public class Cliente
    {
        public int idCliente { get; set; }

        public string nombreCliente { get; set; }

        public long telefonoCliente { get; set; }

        public string direccionCliente { get; set; }

        public string emailCliente { get; set; }

        public bool estado { get; set; }
    }
    public class ConfirmacionCliente
    {
        public int Codigo { get; set; }
        public string Detalle { get; set; }
        public List<Cliente> Datos { get; set; }
        public Cliente Dato { get; set; }
    }
}