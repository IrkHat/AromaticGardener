using AromaticGardener.Application.Common.Interfaces;
using AromaticGardener.Domain.Entities;
using AromaticGardener.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace AromaticGardener.Web.Controllers
{
    public class HerbController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;

        public HerbController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            var herbs = _unitOfWork.Herb.GetAll(includeProperties: "LifeCycle,GrowthHabit");
            return View(herbs);
        }

        public IActionResult Create()
        {
            HerbVM herbVM = new()
            {
                LifeCycleList = _unitOfWork.LifeCycle.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Cycle,
                    Value = u.Id.ToString(),
                }),
                GrowthHabitList = _unitOfWork.GrowthHabit.GetAll().Select(y => new SelectListItem
                {
                    Text = y.Habit,
                    Value = y.Id.ToString(),
                })
            };

            return View(herbVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(HerbVM obj, IFormFile? ImageFile)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                if (ImageFile != null && ImageFile.Length > 0)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(ImageFile.FileName);
                    string path = Path.Combine(wwwRootPath, "images/HerbImages", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        ImageFile.CopyTo(fileStream);
                    }
                    obj.Herb.ImageUrl = "/images/HerbImages/" + fileName;
                }
                else
                {
                    obj.Herb.ImageUrl = "/images/HerbImages/default.png";
                }

                _unitOfWork.Herb.Add(obj.Herb);
                _unitOfWork.Save();
                TempData["success"] = "The herb record has been created successfully!";
                return RedirectToAction(nameof(Index));
            }
            TempData["error"] = "The herb record could not be created...";

            obj.LifeCycleList = _unitOfWork.LifeCycle.GetAll().Select(u => new SelectListItem
            {
                Text = u.Cycle,
                Value = u.Id.ToString(),
            });
            obj.GrowthHabitList = _unitOfWork.GrowthHabit.GetAll().Select(y => new SelectListItem
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
                LifeCycleList = _unitOfWork.LifeCycle.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Cycle,
                    Value = u.Id.ToString(),
                }),
                GrowthHabitList = _unitOfWork.GrowthHabit.GetAll().Select(y => new SelectListItem
                {
                    Text = y.Habit,
                    Value = y.Id.ToString(),
                }),
                Herb = _unitOfWork.Herb.Get(h => h.Id == herbId, includeProperties: "LifeCycle,GrowthHabit")
            };

            if (herbVM.Herb == null)
            {
                return RedirectToAction("Error", "Home");
            }

            return View(herbVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(HerbVM herbVM, IFormFile? ImageFile)
        {
            if (ModelState.IsValid && herbVM.Herb.Id > 0)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                var oldHerb = _unitOfWork.Herb.Get(h => h.Id == herbVM.Herb.Id);
                if (ImageFile != null && ImageFile.Length > 0)
                {
                    if (oldHerb != null && oldHerb.ImageUrl != "/images/HerbImages/default.png")
                    {
                        var oldImagePath = Path.Combine(wwwRootPath, oldHerb.ImageUrl.TrimStart('/'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(ImageFile.FileName);
                    string path = Path.Combine(wwwRootPath, "images/HerbImages", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        ImageFile.CopyTo(fileStream);
                    }
                    herbVM.Herb.ImageUrl = "/images/HerbImages/" + fileName;
                }
                else
                {
                    herbVM.Herb.ImageUrl = oldHerb?.ImageUrl ?? "/images/HerbImages/default.png";
                }

                _unitOfWork.Herb.Update(herbVM.Herb);
                _unitOfWork.Save();
                TempData["success"] = "The herb record has been updated successfully!";
                return RedirectToAction(nameof(Index));
            }

            herbVM.LifeCycleList = _unitOfWork.LifeCycle.GetAll().Select(u => new SelectListItem
            {
                Text = u.Cycle,
                Value = u.Id.ToString(),
            });
            herbVM.GrowthHabitList = _unitOfWork.GrowthHabit.GetAll().Select(y => new SelectListItem
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
                LifeCycleList = _unitOfWork.LifeCycle.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Cycle,
                    Value = u.Id.ToString(),
                }),
                GrowthHabitList = _unitOfWork.GrowthHabit.GetAll().Select(y => new SelectListItem
                {
                    Text = y.Habit,
                    Value = y.Id.ToString(),
                }),
                Herb = _unitOfWork.Herb.Get(h => h.Id == herbId, includeProperties: "LifeCycle,GrowthHabit")
            };

            if (herbVM.Herb == null)
            {
                return RedirectToAction("Error", "Home");
            }

            return View(herbVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(HerbVM herbVM)
        {
            Herb? objFromDb = _unitOfWork.Herb.Get(h => h.Id == herbVM.Herb.Id);

            if (objFromDb != null)
            {
                if (objFromDb.ImageUrl != "/images/HerbImages/default.png")
                {
                    var oldImagePath = Path.Combine(_hostEnvironment.WebRootPath, objFromDb.ImageUrl.TrimStart('/'));
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }

                _unitOfWork.Herb.Remove(objFromDb);
                _unitOfWork.Save();

                TempData["success"] = "The herb record has been deleted successfully!";
                return RedirectToAction(nameof(Index));
            }

            TempData["error"] = "The herb record could not be deleted...";
            return View(herbVM);
        }
    }
}
