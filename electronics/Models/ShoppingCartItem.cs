using System.ComponentModel.DataAnnotations;

namespace Electronics.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int Id { get; set; }

        public Product Product { get; set; }

        public int ProductAmount { get; set; }

        public string ShoppingCartId { get; set; }
    }
}
