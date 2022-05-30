using System;

namespace electronics.Models
{
    public class Product
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public string MakerName { get; set; } // Samsung

        public string SubName { get; set; }    // Note 10

        public string AboutProduct { get; set; }    // Storage, ram, bla bla bla

        public DateTime ReleaseDate { get; set; }

        public double Price { get; set; }

        public Category Category { get; set; }
    }
}
