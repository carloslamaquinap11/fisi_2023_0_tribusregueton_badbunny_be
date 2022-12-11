using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Servicio
    {
        public int ServicioId { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int EsSuscripcion { get; set; }
    }
}
