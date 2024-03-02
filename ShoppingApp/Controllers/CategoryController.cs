using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using ShoppingApp.Models;
using ShoppingApp.Repository.Base;

namespace ShoppingApp.Controllers
{
    public class CategoryController : Controller
    {
        public CategoryController(IRepository<Category> repository)
        {
            _repository = repository;
        }
        private readonly IRepository<Category> _repository;
        public IActionResult Index()
        {
            var categories = _repository.FindAll();
            return View(categories);
        }
        //Get
        public IActionResult Add ()
        {
            return View();
        }
        //POST 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Category category)
        {
            if (ModelState.IsValid)
            {
                _repository.AddCat(category);
                TempData["successCat"] = "You added category successfully";
                return RedirectToAction("Index");
            }
            else
            {
                return View(category);
            }
           
        }
        //GET
        public IActionResult Edit (int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var category = _repository.FindById(id.Value);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit (Category category)
        {
            if (ModelState.IsValid)
            {
                _repository.UpdateCat(category);
                TempData["successUp"] = "you update category successfully";
                return RedirectToAction("Index");
            }
            else
            {
                return View(category);
            }
        }
        //Get 
        public IActionResult Delete(int? id)
        {
            if(id==0 || id == null)
            {
                return NotFound();
            }
            var category = _repository.FindById(id.Value);
            if(category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Category category)
        {
                _repository.DeleteCat(category);
            TempData["SuccessDel"] = "you deleted Category successfully";
            return RedirectToAction("Index");
        }
    }
}
