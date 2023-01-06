using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCCoffeeShop.Models;

namespace MVCCoffeeShop.Controllers
{
    public class ProductController : Controller
    {
        ProductRepository repo;

        public ProductController()
        {
            repo = new ProductRepository();
        }

        // GET: ProductController
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            return View(repo.GetMockProducts());

        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            ProductViewModel product = repo.GetMockProducts().FirstOrDefault(x => x.Id == id);
            return View(product);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                ProductViewModel newProduct = new ProductViewModel()
                {
                    Name = collection["Name"],
                    Description = collection["Description"],
                    Category = collection["Category"],
                    Price = int.Parse(collection["Price"])
                };

                repo.CreateProduct(newProduct);
                return RedirectToAction(nameof(List));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            ProductViewModel product = repo.GetMockProducts().FirstOrDefault(x => x.Id == id);
            return View(product);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                ProductViewModel updatedProduct = new ProductViewModel()
                {
                    Id = int.Parse(collection["Id"]),
                    Name = collection["Name"],
                    Description = collection["Description"],
                    Category = collection["Category"],
                    Price = int.Parse(collection["Price"])
                };
                repo.UpdateProduct(updatedProduct);
                return RedirectToAction(nameof(List));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            ProductViewModel product = repo.GetMockProducts().FirstOrDefault(x => x.Id == id);
            return View(product);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                repo.DeleteProduct(id);
                return RedirectToAction(nameof(List));
            }
            catch
            {
                return View();
            }
        }
    }
}
