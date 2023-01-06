using MVCCoffeeShop.Models;

namespace MVCCoffeeShop

{
    public class ProductRepository
    {
        private List<ProductViewModel> _mockProducts;

        public ProductRepository()
        {
            CreateMockProjectList();
        }
        private void CreateMockProjectList()
        {
            _mockProducts = new List<ProductViewModel>();
            _mockProducts.Add(new ProductViewModel() { Id = 1, Name = "Latte", Description = "Coffee beverage of Italian origin made with espresso and steamed milk", Price = 3.00, Category = "Hot Drinks"});
            _mockProducts.Add(new ProductViewModel() { Id = 2, Name = "Espresso", Description = "Concentrated form of coffee served in small, strong shots and is the base for many coffee drinks" , Price = 2.50, Category = "Hot Drinks"});
            _mockProducts.Add(new ProductViewModel() { Id = 3, Name = "Ice Coffee",Description = "Iced coffee - Coffee and Ice Cubes", Price = 6.00, Category = "Cold Drinks"});
            _mockProducts.Add(new ProductViewModel() { Id = 4, Name = "Frappuccino", Description = "Blended iced coffee drinks sold by Starbucks", Price = 4.50, Category = "Cold Drinks" });
            _mockProducts.Add(new ProductViewModel() { Id = 5, Name = "Bagel", Description = "Round Ball of Dough boiled then baked and topped with flavoring", Price = 3.00, Category = "Hot Food" });
            _mockProducts.Add(new ProductViewModel() { Id = 6, Name = "CakePop", Description = "Cake baked onto a sucker stick then coated and chilled", Price = 2.50, Category = "Cold Food" });
            _mockProducts.Add(new ProductViewModel() { Id = 7, Name = "Brownie", Description = "Hot Hot Brownie what else is there to say", Price = 6.00, Category = "Hot Food" });
            _mockProducts.Add(new ProductViewModel() { Id = 8, Name = "Dough Nut", Description = "Circles of Joy and Holes of goodness for you to consume", Price = 4.50, Category = "Cold Food" });
        }

        public IEnumerable<ProductViewModel> GetMockProducts()
        {
            return _mockProducts;
        }

        public void UpdateProduct(ProductViewModel product)
        {
            int index = _mockProducts.FindIndex(x => x.Id == product.Id);
            _mockProducts[index] = product;
        }


        public void DeleteProduct(int id)
        {
            int index = _mockProducts.FindIndex(x => x.Id == id);
            _mockProducts.RemoveAt(index);
        }
        public void CreateProduct(ProductViewModel product)
        {
            product.Id = _mockProducts.Max(x => x.Id) + 1;
            _mockProducts.Add(product);
        }


    }
}
