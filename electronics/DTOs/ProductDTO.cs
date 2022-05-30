using electronics.Models;
using System;

namespace electronics.DTOs
{
    public class ProductDTO
    {
        public string MakerName { get; set; } // Samsung

        public string SubName { get; set; }    // Note 10

        public string AboutProduct { get; set; }    // Storage, ram

        public double Price { get; set; }

        public DateTime ReleaseDate { get; set; }

        public Category Category { get; set; }
    }
}
