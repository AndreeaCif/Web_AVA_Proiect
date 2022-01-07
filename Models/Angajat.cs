using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_AVA_Proiect.Models
{
    public class Angajat
    {
        public int ID { get; set; }
        [RegularExpression(@"^[A-Z][a-z]*$", ErrorMessage = "Numele trebuie sa inceapa cu majuscula"), Required, StringLength(50, MinimumLength = 3)]
        public string Nume { get; set; }
        [RegularExpression(@"^[A-Z][a-z]*$", ErrorMessage = "Prenumele trebuie sa inceapa cu majuscula"), Required, StringLength(50, MinimumLength = 3)]
        public string Prenume { get; set; }
        [Required, StringLength(150, MinimumLength = 10, ErrorMessage = "Numarul de telefon trebuie sa fie format din cel putin 10 cifre")]
        public string Nr_telefon { get; set; }
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Salariu { get; set; }
        public ICollection<Programare> Programari { get; set; }
    }
}
