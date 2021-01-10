using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Butuza_Elena_Proiect.Models
{
    public class BikeData
    {
        public IEnumerable<Bike> Bikes { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<BikeCategory> BikeCategories { get; set; }
    }
}
