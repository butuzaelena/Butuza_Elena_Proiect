using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Butuza_Elena_Proiect.Data;
using Butuza_Elena_Proiect.Models;


namespace Butuza_Elena_Proiect.Pages.Bikes
{
    public class CreateModel : BikeCategoriesPageModel
    {
        private readonly Butuza_Elena_Proiect.Data.Butuza_Elena_ProiectContext _context;

        public CreateModel(Butuza_Elena_Proiect.Data.Butuza_Elena_ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["StoreID"] = new SelectList(_context.Set<Store>(), "ID", "StoreName");
            var bike = new Bike();
            bike.BikeCategories = new List<BikeCategory>();
            PopulateAssignedCategoryData(_context, bike);
            return Page();
        }

        [BindProperty]
        public Bike Bike { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newBike = new Bike();
            
                if (selectedCategories != null)
                {
                    newBike.BikeCategories = new List<BikeCategory>();
                    foreach (var cat in selectedCategories)
                    {
                        var catToAdd = new BikeCategory
                        {
                            CategoryID = int.Parse(cat)
                        };
                        newBike.BikeCategories.Add(catToAdd);
                    }
                }
                if (await TryUpdateModelAsync<Bike>(
                newBike,
                "Bike",
                i => i.Series, i => i.Brand,
                i => i.Price, i => i.AparitionDate,i=>i.Size, i => i.StoreID))
                {
                    _context.Bike.Add(newBike);
                    await _context.SaveChangesAsync();
                    return RedirectToPage("./Index");
                }
                PopulateAssignedCategoryData(_context, newBike);
                return Page();

            
        }
    }
}
