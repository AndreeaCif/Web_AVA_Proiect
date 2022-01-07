using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_AVA_Proiect.Models
{
    public class MasajCategorie
    {
        public int ID { get; set; }
        public int ProgramareID { get; set; }
        public Programare Programare { get; set; }
        public int MasajID { get; set; }
        public Masaj Masaj { get; set; }
    }
}
