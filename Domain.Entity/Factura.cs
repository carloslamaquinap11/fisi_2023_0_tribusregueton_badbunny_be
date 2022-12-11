using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Factura
    {
        public int FacturaId { get; set; }
        public int PacienteId { get; set; }
        public DateTime FechaPago { get; set; }
        public string MetodoPago { get; set; }
        public decimal Total { get; set; }
    }
}
