﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Web_AVA_Proiect.Data;
using Web_AVA_Proiect.Models;

namespace Web_AVA_Proiect.Pages.Sali
{
    public class IndexModel : PageModel
    {
        private readonly Web_AVA_Proiect.Data.Web_AVA_ProiectContext _context;

        public IndexModel(Web_AVA_Proiect.Data.Web_AVA_ProiectContext context)
        {
            _context = context;
        }

        public string CurrentFilter { get; set; }
        public IList<Sala> Sala { get;set; }

        public async Task OnGetAsync(string searchString)
        {
            CurrentFilter = searchString;
            IQueryable<Sala> sala = from s in _context.Sala select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                sala = sala.Where(s => s.Strada.Contains(searchString));
                                       
            }
            Sala = await sala.AsNoTracking().ToListAsync();
        }
    }
}
