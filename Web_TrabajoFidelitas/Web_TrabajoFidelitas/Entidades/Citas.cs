using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_TrabajoFidelitas.Entidades
{
    public class Citas
    {
        public int idCita { get; set; }
        public int idCliente { get; set; }
        public int idAutomovil { get; set; }
        public int idSucursal { get; set; }
        public int idServicio { get; set; }
        public DateTime fechaHora { get; set; }
        public string comentarios { get; set; }
        public bool estado { get; set; }
        public string nombreSucursal { get; set; }
        public string placa { get; set; }
        public string nombreServicio { get; set; }
        public string nombreCliente { get; set; }
        public int HoraSeleccionada { get; set; }
        public string correoElect { get; set; }

        public string correotipo { get; set; }
    }

    public class ConfirmacionCita
    {
        public int Codigo { get; set; }
        public string Detalle { get; set; }
        public List<Citas> Datos { get; set; }
        public Citas Dato { get; set; }
    }
}
