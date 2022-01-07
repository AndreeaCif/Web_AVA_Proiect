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

        public IList<Angajat> Angajat { get;set; }

        public async Task OnGetAsync()
        {
            Angajat = await _context.Angajat.ToListAsync();
        }
    }
}
