using AromaticGardener.Application.Common.Interfaces;
using AromaticGardener.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AromaticGardener.Web.Controllers
{
    public class GrowthHabitController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public GrowthHabitController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var growthHabits = _unitOfWork.GrowthHabit.GetAll();
            return View(growthHabits);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(GrowthHabit growthHabit)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.GrowthHabit.Add(growthHabit);
                _unitOfWork.Save();
                TempData["success"] = "The growth habit has been created successfully!";
                return RedirectToAction(nameof(Index));
            }
            TempData["error"] = "The growth habit could not be created...";
            return View(growthHabit);
        }

        public IActionResult Update(int id)
        {
            var growthHabit = _unitOfWork.GrowthHabit.Get(gh => gh.Id == id);
            if (growthHabit == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(growthHabit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(GrowthHabit growthHabit)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.GrowthHabit.Update(growthHabit);
                _unitOfWork.Save();
                TempData["success"] = "The growth habit has been updated successfully!";
                return RedirectToAction(nameof(Index));
            }
            TempData["error"] = "The growth habit could not be updated...";
            return View(growthHabit);
        }

        public IActionResult Delete(int id)
        {
            var growthHabit = _unitOfWork.GrowthHabit.Get(gh => gh.Id == id);
            if (growthHabit == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(growthHabit);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var growthHabit = _unitOfWork.GrowthHabit.Get(gh => gh.Id == id);
            if (growthHabit != null)
            {
                _unitOfWork.GrowthHabit.Remove(growthHabit);
                _unitOfWork.Save();
                TempData["success"] = "The growth habit has been deleted successfully!";
                return RedirectToAction(nameof(Index));
            }
            TempData["error"] = "The growth habit could not be deleted...";
            return RedirectToAction(nameof(Index));
        }
    }
}
