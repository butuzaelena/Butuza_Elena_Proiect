﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Butuza_Elena_Proiect.Models
{
    public class Store
    {
        public int ID { get; set; }
        public string StoreName { get; set; }
        public ICollection<Bike> Bikes { get; set; }
    }
}
