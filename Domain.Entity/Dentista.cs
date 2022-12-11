using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Dentista
    {
        public int DentistaId { get; set; }
        public string Nombre { get; set; }
        public int ApePaterno { get; set; }
        public int ApeMaterno { get; set; }
        public DateTime FechaNac { get; set; }
        public string Celular { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Especialidad { get; set; }

    }
}
