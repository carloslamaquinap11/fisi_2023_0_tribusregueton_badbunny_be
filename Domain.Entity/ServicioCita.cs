using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    [Table("SERVICIOCITA")]
    public class ServicioCita
    {
        [Key] 
        public int ServicioId { get; set; }
        public int CitaId { get; set; }
        public string Diagnostico { get; set; }
    }
}
