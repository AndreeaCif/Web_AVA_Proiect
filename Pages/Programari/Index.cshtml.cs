using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Web_AVA_Proiect.Data;
using Web_AVA_Proiect.Models;

namespace Web_AVA_Proiect.Pages.Programari
{
    public class IndexModel : PageModel
    {
        private readonly Web_AVA_Proiect.Data.Web_AVA_ProiectContext _context;

        public IndexModel(Web_AVA_Proiect.Data.Web_AVA_ProiectContext context)
        {
            _context = context;
        }

        public IList<Programare> Programare { get;set; }
        public ProgramareData ProgramareD { get; set; }
        public int ProgramareID { get; set; }
        public int MasajID { get; set; }
        public string DateSort { get; set; }
        public async Task OnGetAsync(int? id, int? MasajID, string sortOrder)
        {
            
            ProgramareD = new ProgramareData();

            DateSort = sortOrder == "Date" ? "date_desc" : "Date";
      
            IQueryable<Programare> program = from s in _context.Programare select s;
           
            switch (sortOrder)
            {
                case "date_desc":
                    program = program.OrderByDescending(s => s.Ora_Data);
                    break;
                default:
                    program = program.OrderBy(s => s.Ora_Data);
                    break;
            }

            ProgramareD.Programari = await program
            .Include(b => b.Angajat)
            .Include(b => b.Sala)
            .Include(b => b.TipMasaj)
            .ThenInclude(b => b.Masaj)
            .AsNoTracking()
            //.OrderBy(b=> b.Ora_Data)
            .ToListAsync();
            if (id != null)
            {
                ProgramareID = id.Value;
                Programare programare = ProgramareD.Programari
                .Where(i => i.ID == id.Value).Single();
                ProgramareD.Masaje = programare.TipMasaj.Select(s => s.Masaj);
            }
        }
    }
}
