using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    [Table("DENTISTA")]
    public class Dentista
    {
        [Key]
        public int DentistaId { get; set; }
        public string DNI { get; set; }
        public string Nombre { get; set; }
        public int ApePaterno { get; set; }
        public int ApeMaterno { get; set; }
        public DateTime FechaNac { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Contrasena { get; set; }

    }
}
