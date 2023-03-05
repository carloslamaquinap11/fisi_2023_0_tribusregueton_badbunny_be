using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    [Table("Cliente")]
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }
        public string UserId { get; set; }
        public string Dni { get; set; }
        public string Nombres { get; set; }
        public string Apepat { get; set; }
        public string Apemat { get; set; }
        public string Celular { get; set; }
    }
}
