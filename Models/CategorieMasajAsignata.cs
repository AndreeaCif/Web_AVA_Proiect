using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_AVA_Proiect.Models
{
    public class CategorieMasajAsignata
    {
        public int MasajID { get; set; }
        public string Denumire { get; set; }
        public int Durata { get; set; }
        public decimal Pret { get; set; }
        public bool Asignata { get; set; }
    }
}
