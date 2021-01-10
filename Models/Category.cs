using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Butuza_Elena_Proiect.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public ICollection<BikeCategory> BikeCategories { get; set; }
    }
}
