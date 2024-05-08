using AromaticGardener.Domain.Entities;
using AromaticGardener.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace AromaticGardener.Web.Controllers
{
    public class HerbController : Controller
    {
        private readonly ApplicationDbContext _db;
        public HerbController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var herbs = _db.Herbs.ToList();
            return View(herbs);
        }

        //          GET
        public IActionResult Create()
        {
            return View();
        }

        //          POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Herb obj)
        {
            if (ModelState.IsValid)
            {
                _db.Herbs.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "The herb record has been created successfully!";
                return RedirectToAction(nameof(Index));
            }
            TempData["error"] = "The herb record could not be created...";
            return View(obj);
        }
        public IActionResult Update(int herbId)
        {
            Herb? obj = _db.Herbs.FirstOrDefault(_ => _.Id == herbId);
            if (obj is null)
            {
                return RedirectToAction("Error", "Home");
            }

            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Herb obj)
        {
            if (ModelState.IsValid && obj.Id > 0)
            {
                _db.Herbs.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "The herb record has been updated successfully!";
                return RedirectToAction(nameof(Index));
            }

            TempData["error"] = "The herb record could not be updated...";
            return View(obj);
        }
        public IActionResult Delete(int herbId)
        {
            Herb? obj = _db.Herbs.FirstOrDefault(_ => _.Id == herbId);

            if (obj is null)
            {
                return RedirectToAction("Error", "Home");
            }

            return View(obj);
        }
        [HttpPost]
        public IActionResult Delete(Herb obj)
        {
            Herb? objFromDb = _db.Herbs.FirstOrDefault(_ => _.Id == obj.Id);

            if (objFromDb is not null)
            {
                _db.Herbs.Remove(objFromDb);
                _db.SaveChanges();

                TempData["success"] = "The herb record has been deleted successfully!";

                return RedirectToAction(nameof(Index));
            }

            TempData["error"] = "The herb record could not be deleted...";
            return View(obj);
        }
    }
}
