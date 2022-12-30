using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    [Table("CITA")]
    public class Cita
    {
        [Key]
        public int CitaId { get; set; }
        public int DentistaId { get; set; }
        public int PacienteId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public String DescripcionCita { get; set; }
        public String Localizacion { get; set; }
    }
}
