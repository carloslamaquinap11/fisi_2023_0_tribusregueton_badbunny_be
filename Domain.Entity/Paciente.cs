using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Paciente
    {
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
