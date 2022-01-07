using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_AVA_Proiect.Models
{
    public class ProgramareData
    {

            public IEnumerable<Programare> Programari { get; set; }
            public IEnumerable<Masaj> Masaje { get; set; }
            public IEnumerable<MasajCategorie> TipMasaj { get; set; }

    }
}
