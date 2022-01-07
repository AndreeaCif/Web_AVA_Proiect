using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web_AVA_Proiect.Data;

namespace Web_AVA_Proiect.Models
{
    public class MasajCategoriePageModel : PageModel
    {
        public List<CategorieMasajAsignata> CategorieMasajAsignataList;
        public void PopulateCategorieMasajAsignata(Web_AVA_ProiectContext context, Programare programare)
        {
            var allMasaje = context.Masaj;
            var masajCategorii = new HashSet<int>(programare.TipMasaj.Select(c => c.MasajID)); //
            CategorieMasajAsignataList = new List<CategorieMasajAsignata>();
            foreach (var mas in allMasaje)
            {
                CategorieMasajAsignataList.Add(new CategorieMasajAsignata
                {
                    MasajID = mas.ID,
                    Denumire = mas.Denumire,
                    Durata =mas.Durata,
                    Pret = mas.Pret,
                    Asignata = masajCategorii.Contains(mas.ID)
                });
            }
        }
        public void UpdateMasajCategorii(Web_AVA_ProiectContext context, string[] selectedCategories, Programare programareToUpdate)
        {
            if (selectedCategories == null)
            {
                programareToUpdate.TipMasaj = new List<MasajCategorie>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var masajCategorii = new HashSet<int>(programareToUpdate.TipMasaj.Select(c => c.Masaj.ID));
            foreach (var mas in context.Masaj)
            {
                if (selectedCategoriesHS.Contains(mas.ID.ToString()))
                {
                    if (!masajCategorii.Contains(mas.ID))
                    {
                        programareToUpdate.TipMasaj.Add(
                        new MasajCategorie
                        {
                            ProgramareID = programareToUpdate.ID,
                            MasajID = mas.ID
                        });
                    }
                }
                else
                {
                    if (masajCategorii.Contains(mas.ID))
                    {
                        MasajCategorie courseToRemove
                        = programareToUpdate
                        .TipMasaj
                       .SingleOrDefault(i => i.MasajID == mas.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
