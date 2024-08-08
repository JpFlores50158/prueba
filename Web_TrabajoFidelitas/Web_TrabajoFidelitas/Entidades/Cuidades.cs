using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_TrabajoFidelitas.Entidades
{
    public class Cuidades
    {
        public int IdCiudad { get; set; }
        public string NombreCiudad { get; set; }
        public bool Estado { get; set; }
    }
    public class ConfirmacionCuidades
    {
        public int Codigo { get; set; }
        public string Detalle { get; set; }
        public List<Cuidades> Datos { get; set; }
        public Cuidades Dato { get; set; }
    }
}