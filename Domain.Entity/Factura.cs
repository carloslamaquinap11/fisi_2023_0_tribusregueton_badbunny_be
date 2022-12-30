using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    [Table("FACTURA")]
    public class Factura
    {
        [Key] 
        public int FacturaId { get; set; }
        public int PacienteId { get; set; }
        public DateTime FechaPago { get; set; }
        public string MetodoPago { get; set; }
        public decimal Total { get; set; }
    }
}
