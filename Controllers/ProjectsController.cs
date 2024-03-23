using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Controllers
{
    [Authorize]
    public class ProjectsController : Controller
    {
        private readonly AppDbContext _db;
        public ProjectsController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Projects> objProjectsList = _db.Projects.ToList();
            return View(objProjectsList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Projects obj)
        {
            if (obj.Name == obj.Description)
            {
                ModelState.AddModelError("Name", "the category name and displayorder can not be the same");
            }
            if (ModelState.IsValid)
            {
                _db.Projects.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "The Category Was Created Successfuly";
                return RedirectToAction("index");
            }
            return View();
        }
        public IActionResult Edit(int? Id)
        {
            if (Id == 0 || Id == null)
            {
                return NotFound();
            }
            Projects? Projectsfromdb = _db.Projects.Find(Id);
            if (Projectsfromdb == null)
            {
                return NotFound();
            }
            return View(Projectsfromdb);
        }
        [HttpPost]
        public IActionResult Edit(Projects obj)
        {
            if (ModelState.IsValid)
            {
                _db.Projects.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "the category was Updated successfuly";
                return RedirectToAction("index");
            }
            return View();
        }
        public IActionResult Delete(int? Id)
        {
            if (Id == 0 || Id == null)
            {
                return NotFound();
            }
            Projects? Projectsfromdb = _db.Projects.Find(Id);
            if (Projectsfromdb == null)
            {
                return NotFound();
            }
            return View(Projectsfromdb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Projects? obj = _db.Projects.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Projects.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "the category was Deleted successfuly";
            return RedirectToAction("index");
        }
    }
}

