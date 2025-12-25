using Microsoft.AspNetCore.Mvc;
using OnlineUrunYonetimi.Data;
using OnlineUrunYonetimi.Models;

namespace OnlineUrunYonetimi.Controllers
{
    public class ProductsController : Controller
    {
        private readonly AppDbContext _context;

        // Constructor – Dependency Injection
        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        // READ Ürün Listeleme
        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
        }

        // CREATE Formu göster
        public IActionResult Create()
        {
            return View();
        }

        // CREATE  Formdan gelen veriyi kaydet
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                product.CreatedDate = DateTime.Now;
                _context.Products.Add(product);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // UPDATE  Düzenleme formu
        public IActionResult Edit(int id)
        {
            var product = _context.Products.Find(id);
            return View(product);
        }

        // UPDATE  Güncelle
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Update(product);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // DELETE  Silme onayı
        public IActionResult Delete(int id)
        {
            var product = _context.Products.Find(id);
            return View(product);
        }

        // DELETE  Sil
        [HttpPost]
        public IActionResult Delete(Product product)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // DETAILS Detay sayfası
        public IActionResult Details(int id)
        {
            var product = _context.Products.Find(id);
            return View(product);
        }
    }
}
