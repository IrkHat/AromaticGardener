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
    }
}
