using System.ComponentModel;

namespace MVCCoffeeShop.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [DisplayName("Product")]
        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public string Category { get; set; }


    }
}
