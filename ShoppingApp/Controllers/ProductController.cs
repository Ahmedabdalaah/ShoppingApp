using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShoppingApp.Data;
using ShoppingApp.Models;

namespace ShoppingApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDBContext _dbContext;
        public ProductController(AppDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        public IActionResult Index()
        {
            IEnumerable<Product> products = _dbContext.products.ToList();
            return View(products);
        }
        //GET
        public IActionResult Add()
        {
            createSelect();
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Product product)
        {
            if (ModelState.IsValid)
            {
                _dbContext.products.Add(product);
                _dbContext.SaveChanges();
                TempData["succesData"] = "You have been added product succefully";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["failData"] = "Error , try again";
                return View(product);
            }
        }

        public void createSelect(int selectedCat=1)
        {
            List<Category> categ = _dbContext.categories.ToList();
            SelectList catItem = new SelectList(categ, "Id", "Name", selectedCat);
            ViewBag.catItem = catItem;
        }
        //GET
        public IActionResult Edit(int? id)
        {
            if(id==0 || id == null)
            {
                return NotFound();
            }
            var item = _dbContext.products.Find(id);
            if(item == null)
            {
                return NotFound();
            }
            createSelect(item.CategoryId);
            return View(item);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _dbContext.products.Update(product);
                _dbContext.SaveChanges();
                TempData["SuccessEdit"] = "You have updata data successfully";
                return RedirectToAction("Index");
            }
            return View(product);
        }
        //GET
        public IActionResult Delete(int? id)
        {
            if(id==0 || id==null)
            {
                return NotFound();
            }
            var item = _dbContext.products.Find(id);
            if(item == null)
            {
                return NotFound();
            }
            createSelect(item.CategoryId);
            return View(item);
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteProduct(int? id)
        {
            var item = _dbContext.products.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            _dbContext.Remove(item);
            _dbContext.SaveChanges();
            TempData["successDelete"] = "you have delete product successfuly";
            return RedirectToAction("Index");
        }
    }
}
