using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Butuza_Elena_Proiect.Data;
using Butuza_Elena_Proiect.Models;

namespace Butuza_Elena_Proiect.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Butuza_Elena_Proiect.Data.Butuza_Elena_ProiectContext _context;

        public IndexModel(Butuza_Elena_Proiect.Data.Butuza_Elena_ProiectContext context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; }

        public async Task OnGetAsync()
        {
            Category = await _context.Category.ToListAsync();
        }
    }
}
