using System;
using System.ComponentModel.DataAnnotations;

namespace Electronics.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        public int CategoryId { get; set; }

        [Display(Name = "Maker Name")]
        public string MakerName { get; set; } // Samsung

        [Display(Name = "Sub Name")]
        public string SubName { get; set; }    // Note 10

        [Display(Name = "About Product")]
        public string AboutProduct { get; set; }    // Storage, ram, bla bla bla

        [DisplayFormat(DataFormatString = "{0:yyyy}")]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        public Category Category { get; set; }

        public double Price { get; set; }
        [Display(Name = "Image")]
        public string URL { get; set; }

    }
}
