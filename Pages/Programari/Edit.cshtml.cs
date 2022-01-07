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

namespace Web_AVA_Proiect.Pages.Programari
{
    public class EditModel : MasajCategoriePageModel
    {
        private readonly Web_AVA_Proiect.Data.Web_AVA_ProiectContext _context;
        public EditModel(Web_AVA_Proiect.Data.Web_AVA_ProiectContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Programare Programare { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Programare = await _context.Programare
            .Include(b => b.Angajat)
            .Include(b => b.Sala)
            .Include(b => b.TipMasaj).ThenInclude(b => b.Masaj)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.ID == id);
            if (Programare == null)
            {
                return NotFound();
            }
            //apelam PopulateAssignedCategoryData pentru o obtine informatiile necesare checkbox-
            //urilor folosind clasa AssignedCategoryData
            PopulateCategorieMasajAsignata(_context, Programare);
            ViewData["AngajatID"] = new SelectList(_context.Angajat, "ID","Nume", "ID", "Prenume");
            ViewData["SalaID"] = new SelectList(_context.Sala, "ID", "Strada", "ID", "Numar");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id, string[]selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            var programareToUpdate = await _context.Programare
            .Include(i => i.Angajat)
            .Include(i => i.Sala)
            .Include(i => i.TipMasaj)
            .ThenInclude(i => i.Masaj)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (programareToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Programare>(
            programareToUpdate,
            "Programare",
            i => i.Ora_Data, i => i.Angajat,
            i => i.Sala))
            {
                UpdateMasajCategorii(_context, selectedCategories, programareToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateBookCategories pentru a aplica informatiile din checkboxuri la entitatea Books care
            //este editata
            UpdateMasajCategorii(_context, selectedCategories, programareToUpdate);
            PopulateCategorieMasajAsignata(_context, programareToUpdate);
            return Page();
        }
    }
}