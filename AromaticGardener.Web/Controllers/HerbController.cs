using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AromaticGardener.Domain.Entities;
using AromaticGardener.Infrastructure.Data;
using AromaticGardener.Web.ViewModels;

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
            var herbs = _db.Herbs
                 .Include(u => u.LifeCycle)
                 .Include(x => x.GrowthHabit)
                 .ToList();

            return View(herbs);
        }

        //          GET
        public IActionResult Create()
        {
            HerbVM herbVM = new()
            {
                LifeCycleList = _db.LifeCycles.ToList().Select(u => new SelectListItem
                {
                    Text = u.Cycle,
                    Value = u.Id.ToString(),
                }),
                GrowthHabitList = _db.GrowthHabits.ToList().Select(y => new SelectListItem
                {
                    Text = y.Habit,
                    Value = y.Id.ToString(),
                })
            };

            return View(herbVM);
        }

        //          POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(HerbVM obj)
        {
            if (ModelState.IsValid)
            {
                _db.Herbs.Add(obj.Herb);
                _db.SaveChanges();
                TempData["success"] = "The herb record has been created successfully!";
                return RedirectToAction(nameof(Index));
            }
            TempData["error"] = "The herb record could not be created...";

            obj.LifeCycleList = _db.LifeCycles.ToList().Select(u => new SelectListItem
            {
                Text = u.Cycle,
                Value = u.Id.ToString(),
            });
            obj.GrowthHabitList = _db.GrowthHabits.ToList().Select(y => new SelectListItem
            {
                Text = y.Habit,
                Value = y.Id.ToString(),
            });


            return View(obj);
        }
        public IActionResult Update(int herbId)
        {
            HerbVM herbVM = new()
            {
                LifeCycleList = _db.LifeCycles.ToList().Select(u => new SelectListItem
                {
                    Text = u.Cycle,
                    Value = u.Id.ToString(),
                }),
                GrowthHabitList = _db.GrowthHabits.ToList().Select(y => new SelectListItem
                {
                    Text = y.Habit,
                    Value = y.Id.ToString(),
                }),
                Herb = _db.Herbs.FirstOrDefault(_ => _.Id == herbId)!
            };

            if (herbVM.Herb is null)
            {
                return RedirectToAction("Error", "Home");
            }

            return View(herbVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(HerbVM herbVM)
        {
            if (ModelState.IsValid && herbVM.Herb.Id > 0)
            {
                _db.Herbs.Update(herbVM.Herb);
                _db.SaveChanges();
                TempData["success"] = "The herb record has been updated successfully!";
                return RedirectToAction(nameof(Index));
            }


            herbVM.LifeCycleList = _db.LifeCycles.ToList().Select(u => new SelectListItem
            {
                Text = u.Cycle,
                Value = u.Id.ToString(),
            });
            herbVM.GrowthHabitList = _db.GrowthHabits.ToList().Select(y => new SelectListItem
            {
                Text = y.Habit,
                Value = y.Id.ToString(),
            });

            TempData["error"] = "The herb record could not be updated...";

            return View(herbVM);
        }
        public IActionResult Delete(int herbId)
        {
            HerbVM herbVM = new()
            {
                LifeCycleList = _db.LifeCycles.ToList().Select(u => new SelectListItem
                {
                    Text = u.Cycle,
                    Value = u.Id.ToString(),
                }),
                GrowthHabitList = _db.GrowthHabits.ToList().Select(y => new SelectListItem
                {
                    Text = y.Habit,
                    Value = y.Id.ToString(),
                }),
                Herb = _db.Herbs.FirstOrDefault(_ => _.Id == herbId)!
            };

            if (herbVM.Herb is null)
            {
                return RedirectToAction("Error", "Home");
            }

            return View(herbVM);

        }
        [HttpPost]
        public IActionResult Delete(HerbVM herbVM)
        {
            Herb? objFromDb = _db.Herbs.FirstOrDefault(_ => _.Id == herbVM.Herb.Id);

            if (objFromDb is not null)
            {
                _db.Herbs.Remove(objFromDb);
                _db.SaveChanges();

                TempData["success"] = "The herb record has been deleted successfully!";

                return RedirectToAction(nameof(Index));
            }

            TempData["error"] = "The herb record could not be deleted...";
            return View(herbVM);
        }
    }
}
