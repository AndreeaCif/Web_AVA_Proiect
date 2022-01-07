using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Web_AVA_Proiect.Models;

namespace Web_AVA_Proiect.Data
{
    public class Web_AVA_ProiectContext : DbContext
    {
        public Web_AVA_ProiectContext (DbContextOptions<Web_AVA_ProiectContext> options)
            : base(options)
        {
        }

        public DbSet<Web_AVA_Proiect.Models.Programare> Programare { get; set; }

        public DbSet<Web_AVA_Proiect.Models.Angajat> Angajat { get; set; }

        public DbSet<Web_AVA_Proiect.Models.Masaj> Masaj { get; set; }

        public DbSet<Web_AVA_Proiect.Models.Sala> Sala { get; set; }
    }
}
