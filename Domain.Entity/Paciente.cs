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
        public string Nombre { get; set; }
        public string ApePaterno { get; set; }
        public string ApeMaterno { get; set; }
        public string TipoSangre { get; set; }
        public string AlergicoMed1 { get; set; }
        public string AlergicoMed2 { get; set; }
        public string Diabetes { get; set; }
        public string Cardiaco { get; set; }
        public string Enfermedad1 { get; set; }
        public string Enfermedad2 { get; set; }
        public DateTime FechaNac { get; set; }
        public string Celular { get; set; }
        public string Telefono { get; set; }
        public string Genero { get; set; }
        public string Email { get; set; }
    }
}
