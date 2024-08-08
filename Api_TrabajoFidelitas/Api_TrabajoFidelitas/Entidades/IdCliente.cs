using Api_TrabajoFidelitas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_TrabajoFidelitas.Entidades
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
        public List<ConsultarIdsClientes_Result> Datos { get; set; }
        public ConsultarIdsClientes_Result Dato { get; set; }
    }
}