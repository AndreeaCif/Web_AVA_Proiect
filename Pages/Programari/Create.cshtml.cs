using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web_AVA_Proiect.Data;
using Web_AVA_Proiect.Models;

namespace Web_AVA_Proiect.Pages.Programari
{
    public class CreateModel : MasajCategoriePageModel
    {
        private readonly Web_AVA_Proiect.Data.Web_AVA_ProiectContext _context;

        public CreateModel(Web_AVA_Proiect.Data.Web_AVA_ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["AngajatID"] = new SelectList(_context.Set<Angajat>(), "ID", "Nume", "ID", "Prenume");
            ViewData["SalaID"] = new SelectList(_context.Set<Sala>(), "ID", "Strada", "ID", "Numar");
            var programare = new Programare();
            programare.TipMasaj = new List<MasajCategorie>();
            PopulateCategorieMasajAsignata(_context, programare);
            return Page();
        }

        [BindProperty]
        public Programare Programare { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newProgramare = new Programare();
            if (selectedCategories != null)
            {
                newProgramare.TipMasaj = new List<MasajCategorie>();
                foreach (var mas in selectedCategories)
                {
                    var masToAdd = new MasajCategorie
                    {
                        MasajID = int.Parse(mas)
                    };
                    newProgramare.TipMasaj.Add(masToAdd);
                }
            }
            if (await TryUpdateModelAsync<Programare>(
            newProgramare,
            "Programare",
            i => i.Ora_Data, i => i.AngajatID, i => i.SalaID))
            {
                _context.Programare.Add(newProgramare);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateCategorieMasajAsignata(_context, newProgramare);
            return Page();
        }
    }
}
