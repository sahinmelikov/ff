using EslProje.DAL;
using EslProje.Models;
using EslProje.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EslProje.Areas.Admin.Controllers
{
        [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _cont;
        public CategoryController(AppDbContext cont)
        {
            _cont = cont;
        }

      
        public async Task<IActionResult> Index()
        {
           
            ICollection<Category> categories = await _cont.Categories.ToListAsync();
          
              
            return View(categories);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            if (ModelState.IsValid)
            {
                return View(category);
            }

            bool Cixandeyer = await _cont.Categories.AnyAsync(c =>
            c.Name.ToLower().Trim() == category.Name.ToLower().Trim());

            if (Cixandeyer)
            {
                ModelState.AddModelError("Name", "Category name already exists");
                return View();
            }
            await _cont.Categories.AddAsync(category);
            await _cont.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }



        [HttpGet]  
        public async Task<IActionResult> Delete(int id)
        {
            Category? category =  _cont.Categories.Find(id);
             _cont.Categories.Remove(category);
            await _cont.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Update(int Id)
        {
            Category? category = _cont.Categories.Find(Id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        public IActionResult Update(Category category)
        {
            Category? editedCategory = _cont.Categories.Find(category.Id);
            if (editedCategory ==null)
            {
                return NotFound();

            }
            
            editedCategory.Name = category.Name;
            _cont.Categories.Update(editedCategory);
            _cont.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        //[HttpGet]
        //public async Task<IActionResult> Update(int Id)
        //{
        //    Category? category = _cont.Categories.Find(Id);
        //    if (category==null)
        //    {
        //        //await _cont.Categories.AddAsync(category);
        //        //return RedirectToAction(nameof(Update));
        //        return NotFound();   //////////////Erroru Qaytarir Id ni tapmayanda;
        //    }
        //    return View(category);
        //}
        //[HttpPost]
        //public IActionResult Update()
        //{

        //    return RedirectToAction(nameof(Index));
        //}
    }
}
