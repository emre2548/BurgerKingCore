using BurgerKingCore.Data;
using BurgerKingCore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BurgerKingCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {

        // Bağlantıyı çek sadece burada ve okunabiilr olarak kullan
        private readonly ApplicationDbContext _dbContext;

        // constructor yapıcı method diyoruz
        /* bağlantıyı okudukdan sonra yapıcı kontroller bir kere çalışacak ve parantez içine yeni servisler ileride ekleyebileceğiz
         * ve oluşturduğumuz bu nesneyi hazır hale getiriyor. */
        public CategoryController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            // kategorile listele

            var list = _dbContext.Categories.ToList();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Add(category);
                _dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(category);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guncelle = _dbContext.Categories.Find(id);

            if (guncelle == null)
            {
                return NotFound();
            }

            return View(guncelle);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Update(category);
                _dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(category);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var delete = _dbContext.Categories.Find(id);

            if (delete == null)
            {
                return NotFound();
            }

            return View(delete);
        }

        /* Yukarıda Delete adı olduğu için hata verdi bu şekilde yapılıyor */
        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteConfirmed(int? id)
        {
            var delete = _dbContext.Categories.Find(id);

            if (delete == null)
            {
                return View();
            }

            _dbContext.Remove(delete);
            _dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            if (id == null)
            {
                    return NotFound();
            }

            var detail = _dbContext.Categories.Find(id);

            if (detail == null)
            {
                return NotFound();
            }

            return View(detail);

        }

    }
}
