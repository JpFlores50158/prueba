using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_TrabajoFidelitas.Entidades
{
    public class IdsClientes
    {
        public int IdsCliente { get; set; }
        public string NombreCliente { get; set; }
    }
    public class ConfirmacionIdsClientes
    {
        public int Codigo { get; set; }
        public string Detalle { get; set; }
        public object Datos { get; set; }
        public object Dato { get; set; }
    }
}