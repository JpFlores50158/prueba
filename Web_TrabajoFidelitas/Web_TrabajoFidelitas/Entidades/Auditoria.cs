using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_TrabajoFidelitas.Entidades
{
    public class Auditoria
    {
        public int AuditID { get; set; }
        public string TableName { get; set; }
        public string Action { get; set; }
        public string Usuario { get; set; }

        public DateTime ActionTime { get; set; }
    }
    public class ConfirmacionAuditoria
    {
        public int Codigo { get; set; }
        public string Detalle { get; set; }
        public List<Auditoria> Datos { get; set; }
        public object Dato { get; set; }
    }
}