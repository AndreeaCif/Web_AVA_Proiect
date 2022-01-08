using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Web_AVA_Proiect.Data;
using Web_AVA_Proiect.Models;

namespace Web_AVA_Proiect.Pages.Angajati
{
    public class IndexModel : PageModel
    {
        private readonly Web_AVA_Proiect.Data.Web_AVA_ProiectContext _context;

        public IndexModel(Web_AVA_Proiect.Data.Web_AVA_ProiectContext context)
        {
            _context = context;
        }
        public string NameSort { get; set; }
        public string CurrentFilter { get; set; }
        public IList<Angajat> Angajat { get;set; }
      

        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            CurrentFilter = searchString;
            
            IQueryable<Angajat> angajat = from s in _context.Angajat
                                          select s;
            if (!String.IsNullOrEmpty(searchString))
            {
               
                angajat = angajat.Where(s => s.Nume.Contains(searchString)
                                       || s.Prenume.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    angajat = angajat.OrderByDescending(s => s.Nume);
                    break;
                default:
                    angajat = angajat.OrderBy(s => s.Nume);
                    break;
            }


            //Angajat = await _context.Angajat.ToListAsync();
            Angajat = await angajat.AsNoTracking().ToListAsync();
        }
    }
}
