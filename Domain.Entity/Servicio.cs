using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    [Table("SERVICIO")]
    public class Servicio
    {
        [Key] 
        public int ServicioId { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int EsSuscripcion { get; set; }
    }
}
