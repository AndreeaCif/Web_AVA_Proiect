using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web_AVA_Proiect.Data;
using Web_AVA_Proiect.Models;

namespace Web_AVA_Proiect.Pages.Masaje
{
    public class EditModel : PageModel
    {
        private readonly Web_AVA_Proiect.Data.Web_AVA_ProiectContext _context;

        public EditModel(Web_AVA_Proiect.Data.Web_AVA_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Masaj).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MasajExists(Masaj.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MasajExists(int id)
        {
            return _context.Masaj.Any(e => e.ID == id);
        }
    }
}
