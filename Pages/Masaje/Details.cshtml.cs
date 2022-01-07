using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Web_AVA_Proiect.Data;
using Web_AVA_Proiect.Models;

namespace Web_AVA_Proiect.Pages.Masaje
{
    public class DetailsModel : PageModel
    {
        private readonly Web_AVA_Proiect.Data.Web_AVA_ProiectContext _context;

        public DetailsModel(Web_AVA_Proiect.Data.Web_AVA_ProiectContext context)
        {
            _context = context;
        }

        public Masaj Masaj { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Masaj = await _context.Masaj.FirstOrDefaultAsync(m => m.ID == id);

            if (Masaj == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
