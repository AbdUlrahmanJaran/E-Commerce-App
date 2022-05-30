using System.Collections.Generic;

namespace electronics.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Info { get; set; }

        public List<Product> Products { get; set; }
    }
}
