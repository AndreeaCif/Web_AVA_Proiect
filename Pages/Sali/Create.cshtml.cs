using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web_AVA_Proiect.Data;
using Web_AVA_Proiect.Models;

namespace Web_AVA_Proiect.Pages.Sali
{
    public class CreateModel : PageModel
    {
        private readonly Web_AVA_Proiect.Data.Web_AVA_ProiectContext _context;

        public CreateModel(Web_AVA_Proiect.Data.Web_AVA_ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Sala Sala { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Sala.Add(Sala);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
