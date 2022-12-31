using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public int Estado { get; set; } 
    }
    public enum KDAppointmentState
    { // 0: por atender, 1: atendido, 2: cancelado
        [Description("PORATENDER")]
        PORATENDER=0,
        [Description("ATENDIDO")]
        ATENDIDO =1,
        [Description("CANCELADO")]
        CANCELADO =2
    }
}
