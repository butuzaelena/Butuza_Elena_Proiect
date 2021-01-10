using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Butuza_Elena_Proiect.Models;

namespace Butuza_Elena_Proiect.Data
{
    public class Butuza_Elena_ProiectContext : DbContext
    {
        public Butuza_Elena_ProiectContext (DbContextOptions<Butuza_Elena_ProiectContext> options)
            : base(options)
        {
        }

        public DbSet<Butuza_Elena_Proiect.Models.Bike> Bike { get; set; }

        public DbSet<Butuza_Elena_Proiect.Models.Store> Store { get; set; }

        public DbSet<Butuza_Elena_Proiect.Models.Category> Category { get; set; }
    }
}
