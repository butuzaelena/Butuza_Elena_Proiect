using System;
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
    public class IndexModel : PageModel
    {
        private readonly Butuza_Elena_Proiect.Data.Butuza_Elena_ProiectContext _context;

        public IndexModel(Butuza_Elena_Proiect.Data.Butuza_Elena_ProiectContext context)
        {
            _context = context;
        }

        public IList<Bike> Bike { get; set; }

        public BikeData BikeD { get; set; }
        public int BikeID { get; set; }
        public int CategoryID { get; set; }
        public async Task OnGetAsync(int? id, int? categoryID)
        {
            BikeD = new BikeData();

            BikeD.Bikes = await _context.Bike
            .Include(b => b.Store)
            .Include(b => b.BikeCategories)
            .ThenInclude(b => b.Category)
            .AsNoTracking()
            .OrderBy(b => b.Series)
            .ToListAsync();
            if (id != null)
            {
                BikeID = id.Value;
                Bike bike = BikeD.Bikes
                .Where(i => i.ID == id.Value).Single();
                BikeD.Categories = bike.BikeCategories.Select(s => s.Category);
            }
        }

    }
}
