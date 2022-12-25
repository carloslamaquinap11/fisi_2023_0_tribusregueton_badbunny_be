using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    [Table("PACIENTE")]
    public class Paciente
    {
        [Key]
        public int PacienteId { get; set; }
        public string DNI { get; set; }
        public string Nombre { get; set; }
        public string ApePaterno { get; set; }
        public string ApeMaterno { get; set; }
        public DateTime FechaNac { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Contrasena { get; set; }
    }
}
