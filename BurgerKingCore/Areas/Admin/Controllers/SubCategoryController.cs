using BurgerKingCore.Data;
using BurgerKingCore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BurgerKingCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SubCategoryController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public SubCategoryController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public IActionResult Index()
        {
            // kategori ve alt kategorileri birleştir

            var list = _dbContext.SubCategories.Include(i => i.Category).ToList();

            return View(list);
        }

        public IActionResult Create()
        {
            SubCategoryAndCategoryViewModel model = new SubCategoryAndCategoryViewModel()
            {
                CategoryList = _dbContext.Categories.ToList(),
                SubCategory = new Models.SubCategory(),
                SubCategoryList = _dbContext.SubCategories.OrderBy(i => i.Name)
                .Select(i => i.Name).Distinct().ToList() // Distinct() aynı isimdekiler gelmesin
            };
            return View(model);
        }
    }
}
