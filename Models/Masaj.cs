using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_AVA_Proiect.Models
{
    public class Masaj
    {
        public int ID { get; set; }
        public string Denumire { get; set; }
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Pret { get; set; }
        public int Durata { get; set; }
        public ICollection<MasajCategorie> Masaje { get; set; }
    }
}
