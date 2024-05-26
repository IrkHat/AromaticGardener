using AromaticGardener.Application.Common.Interfaces;
using AromaticGardener.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AromaticGardener.Web.Controllers
{
    public class LifeCycleController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public LifeCycleController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var lifeCycles = _unitOfWork.LifeCycle.GetAll();
            return View(lifeCycles);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(LifeCycle lifeCycle)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.LifeCycle.Add(lifeCycle);
                _unitOfWork.Save();
                TempData["success"] = "The life cycle has been created successfully!";
                return RedirectToAction(nameof(Index));
            }
            TempData["error"] = "The life cycle could not be created...";
            return View(lifeCycle);
        }

        public IActionResult Update(int id)
        {
            var lifeCycle = _unitOfWork.LifeCycle.Get(lc => lc.Id == id);
            if (lifeCycle == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(lifeCycle);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(LifeCycle lifeCycle)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.LifeCycle.Update(lifeCycle);
                _unitOfWork.Save();
                TempData["success"] = "The life cycle has been updated successfully!";
                return RedirectToAction(nameof(Index));
            }
            TempData["error"] = "The life cycle could not be updated...";
            return View(lifeCycle);
        }

        public IActionResult Delete(int id)
        {
            var lifeCycle = _unitOfWork.LifeCycle.Get(lc => lc.Id == id);
            if (lifeCycle == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(lifeCycle);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var lifeCycle = _unitOfWork.LifeCycle.Get(lc => lc.Id == id);
            if (lifeCycle != null)
            {
                _unitOfWork.LifeCycle.Remove(lifeCycle);
                _unitOfWork.Save();
                TempData["success"] = "The life cycle has been deleted successfully!";
                return RedirectToAction(nameof(Index));
            }
            TempData["error"] = "The life cycle could not be deleted...";
            return RedirectToAction(nameof(Index));
        }
    }
}
