﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Butuza_Elena_Proiect.Data;
using Butuza_Elena_Proiect.Models;

namespace Butuza_Elena_Proiect.Pages.Bikes
{
    public class DetailsModel : PageModel
    {
        private readonly Butuza_Elena_Proiect.Data.Butuza_Elena_ProiectContext _context;

        public DetailsModel(Butuza_Elena_Proiect.Data.Butuza_Elena_ProiectContext context)
        {
            _context = context;
        }

        public Bike Bike { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Bike = await _context.Bike.FirstOrDefaultAsync(m => m.ID == id);

            if (Bike == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
