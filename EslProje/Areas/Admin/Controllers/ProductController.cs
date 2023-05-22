using EslProje.DAL;
using EslProje.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EslProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
           ICollection<Product> product= await _context.Products.ToListAsync();
            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            Product ProductNew = new Product()
            {
                Name = product.Name,
                Price = product.Price,
                ImagePath = product.ImagePath,

            };
            await _context.Products.AddAsync(ProductNew);
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Update(int Id)
        {
            Product? products= await _context.Products.FindAsync(Id);
            return View(products);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Product Prop)
        {
         
            if (ModelState.IsValid)
            {
                return View();
            }
            bool IsExisits = await _context.Products.AnyAsync(p => p.Id == Prop.Id);
            if (!IsExisits)
            {
                return RedirectToAction(nameof(Index));
            }
            Product? NewProduct = await _context.Products.FindAsync(Prop.Id);
            NewProduct.Name = Prop.Name;
            NewProduct.Price = Prop.Price;
            NewProduct.ImagePath = Prop.ImagePath;



             _context.Products.Update(NewProduct);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int ID)
        {
            Product? product = await _context.Products.FindAsync(ID);
             _context.Products.Remove(product);
            _context.SaveChanges();
            return View();
        }



    }
}
