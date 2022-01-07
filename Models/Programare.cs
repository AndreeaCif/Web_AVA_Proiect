using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_AVA_Proiect.Models
{
    public class Programare
    {
        public int ID { get; set; }
        [Display(Name = "Data Si Ora")]
        public DateTime Ora_Data { get; set; }
        public int AngajatID { get; set; }
        public Angajat Angajat { get; set; }
        public int SalaID { get; set; }
        public Sala Sala { get; set; }
        public ICollection<MasajCategorie> TipMasaj { get; set; }
    }
}
