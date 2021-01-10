using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Butuza_Elena_Proiect.Models
{
    public class BikeCategory
    {
        public int ID { get; set; }
        public int BikeID { get; set; }
        public Bike Bike { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
