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
        public int DoctorId { get; set; }
        public int ClienteId { get; set; }
        public string NombreDoctor { get; set; }
        public string NombreCliente { get; set; }
        public string Observacion { get; set; }
        public string Motivo { get; set; }
        public DateTime FechaCita { get; set; }
        public int HoraCita { get; set; }
        public string Local { get; set; }
        public double PrecioInicial { get; set; }
        public double? Descuento { get; set; }
        public double PrecioFinal { get; set; }
        public int Estado { get; set; }
        public string MotivoEstado { get; set; }
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
