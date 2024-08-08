using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_TrabajoFidelitas.Entidades
{
    public class Automovil
    {
        public int idAutomovil { get; set; }
        public int idCliente { get; set; }
        public string placa { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public int ano { get; set; }
        public bool estado { get; set; }
        public int IdsCliente { get; set; }
        public string NombreCliente { get; set; }
    }
    public class ConfirmacionAutomovil
    {
        public int Codigo { get; set; }
        public string Detalle { get; set; }
        public List<Automovil> Datos { get; set; }
        public Automovil Dato { get; set; }
    }
}