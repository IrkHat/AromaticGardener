using AromaticGardener.Application.Common.Interfaces;
using AromaticGardener.Domain.Entities;
using AromaticGardener.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AromaticGardener.Web.Controllers
{
    public class HerbKitController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HerbKitController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var herbKits = _unitOfWork.HerbKit.GetAll(includeProperties: "Herb");
            return View(herbKits);
        }

        public IActionResult Create()
        {
            HerbKitVM herbKitVM = new()
            {
                HerbList = _unitOfWork.Herb.GetAll().Select(h => new SelectListItem
                {
                    Text = h.CommonName,
                    Value = h.Id.ToString()
                })
            };
            return View(herbKitVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(HerbKitVM obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.HerbKit.Add(obj.HerbKit);
                _unitOfWork.Save();
                TempData["success"] = "The herb kit has been created successfully!";
                return RedirectToAction(nameof(Index));
            }
            TempData["error"] = "The herb kit could not be created...";
            obj.HerbList = _unitOfWork.Herb.GetAll().Select(h => new SelectListItem
            {
                Text = h.CommonName,
                Value = h.Id.ToString()
            });
            return View(obj);
        }

        public IActionResult Update(int id)
        {
            HerbKitVM herbKitVM = new()
            {
                HerbList = _unitOfWork.Herb.GetAll().Select(h => new SelectListItem
                {
                    Text = h.CommonName,
                    Value = h.Id.ToString()
                }),
                HerbKit = _unitOfWork.HerbKit.Get(hk => hk.Id == id)
            };

            if (herbKitVM.HerbKit == null)
            {
                return RedirectToAction("Error", "Home");
            }

            return View(herbKitVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(HerbKitVM herbKitVM)
        {
            if (ModelState.IsValid && herbKitVM.HerbKit.Id > 0)
            {
                _unitOfWork.HerbKit.Update(herbKitVM.HerbKit);
                _unitOfWork.Save();
                TempData["success"] = "The herb kit has been updated successfully!";
                return RedirectToAction(nameof(Index));
            }

            herbKitVM.HerbList = _unitOfWork.Herb.GetAll().Select(h => new SelectListItem
            {
                Text = h.CommonName,
                Value = h.Id.ToString()
            });

            TempData["error"] = "The herb kit could not be updated...";

            return View(herbKitVM);
        }

        public IActionResult Delete(int id)
        {
            HerbKitVM herbKitVM = new()
            {
                HerbList = _unitOfWork.Herb.GetAll().Select(h => new SelectListItem
                {
                    Text = h.CommonName,
                    Value = h.Id.ToString()
                }),
                HerbKit = _unitOfWork.HerbKit.Get(hk => hk.Id == id)
            };

            if (herbKitVM.HerbKit == null)
            {
                return RedirectToAction("Error", "Home");
            }

            return View(herbKitVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(HerbKitVM herbKitVM)
        {
            HerbKit? objFromDb = _unitOfWork.HerbKit.Get(hk => hk.Id == herbKitVM.HerbKit.Id);

            if (objFromDb != null)
            {
                _unitOfWork.HerbKit.Remove(objFromDb);
                _unitOfWork.Save();

                TempData["success"] = "The herb kit has been deleted successfully!";
                return RedirectToAction(nameof(Index));
            }

            TempData["error"] = "The herb kit could not be deleted...";
            return View(herbKitVM);
        }
    }
}
