using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class ServicioCita
    {
        public int ServicioId { get; set; }
        public int CitaId { get; set; }
        public string Diagnostico { get; set; }
    }
}
