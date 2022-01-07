using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_AVA_Proiect.Models
{
    public class Sala
    {
        public int ID { get; set; }
        public int Numar { get; set; }
        public int Etaj { get; set; }
        [RegularExpression(@"^[A-Z][a-z]*$", ErrorMessage = "Strada trebuie sa inceapa cu majuscula"), Required, StringLength(50, MinimumLength = 3)]
        public string Strada { get; set; }
        public ICollection<Programare> Programari { get; set; }
    }
}
