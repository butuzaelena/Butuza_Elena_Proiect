using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Butuza_Elena_Proiect.Data;
using Butuza_Elena_Proiect.Models;

namespace Butuza_Elena_Proiect.Pages.Bikes
{
    public class EditModel : BikeCategoriesPageModel
    {
        private readonly Butuza_Elena_Proiect.Data.Butuza_Elena_ProiectContext _context;

        public EditModel(Butuza_Elena_Proiect.Data.Butuza_Elena_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Bike Bike { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Bike = await _context.Bike.Include(b => b.Store).Include(b => b.BikeCategories).ThenInclude(b =>b.Category).AsNoTracking().FirstOrDefaultAsync(m => m.ID == id);

            if (Bike == null)
            {
                return NotFound();
            }
            PopulateAssignedCategoryData(_context, Bike);
            ViewData["StoreID"] = new SelectList(_context.Set<Store>(), "ID", "StoreName");  
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[]selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            var bikeToUpdate = await _context.Bike
            .Include(i => i.Store)
            .Include(i => i.BikeCategories)
            .ThenInclude(i => i.Category)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (bikeToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Bike>(
            bikeToUpdate,
            "Bike",
            i => i.Series, i => i.Brand,
            i => i.Price, i => i.AparitionDate,i=> i.Size, i => i.StoreID))
            {
                UpdateBikeCategories(_context, selectedCategories, bikeToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateBookCategories pentru a aplica informatiile din checkboxuri la entitatea Books care
            //este editata
            UpdateBikeCategories(_context, selectedCategories, bikeToUpdate);
            PopulateAssignedCategoryData(_context, bikeToUpdate);
            return Page();
        }
        private bool BikeExists(int id)
        {
            return _context.Bike.Any(e => e.ID == id);
        }
    }

}
