using electronics.Models;
using System.Collections.Generic;

namespace electronics.DTOs
{
    public class CategoryDTO
    {
        public string Name { get; set; }

        public string Info { get; set; }

        public List<Product> Products { get; set; }

    }
}
