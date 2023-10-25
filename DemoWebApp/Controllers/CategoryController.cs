using DemoWebApp.Data;
using DemoWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoWebApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var objCategoryList = _db.tbl_category.ToList();
            return View(objCategoryList);
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name.Equals("test"))
            {
                ModelState.AddModelError("Name", "You Can Not Add test Name!");
            }
            if (ModelState.IsValid)
            {
                _db.tbl_category.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Successfully Saved Record!";
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null && id == 0)
                return NotFound();
            Category? categoryFromDB = _db.tbl_category.Find(id);
            if (categoryFromDB == null)
                return NotFound();
            return View(categoryFromDB);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {

            if (ModelState.IsValid)
            {
                _db.tbl_category.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Successfully Update Record!";
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null && id == 0)
                return NotFound();
            Category? categoryFromDB = _db.tbl_category.Find(id);
            if (categoryFromDB == null)
                return NotFound();
            return View(categoryFromDB);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Category? categoryFromDB = _db.tbl_category.Find(id);
            _db.tbl_category.Remove(categoryFromDB);
            _db.SaveChanges();
            TempData["success"] = "Successfully Delete Record!";
            return RedirectToAction("Index");
        }


    }
}
