using AppMvc.Net.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppMvc.Net.Areas.Database.Controllers
{
    [Area("Database")]
    [Route("/database-manage/[action]")]
    public class DbManageController : Controller
    {
        private readonly AppDbContext _context;
        public DbManageController(AppDbContext context)
        {
            _context = context;
        }

        [TempData]
        public string StatusMessage { get; set; }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult DeleteDb()
        {
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> DeleteDbAsync()
        {
            var success = await _context.Database.EnsureDeletedAsync();
            StatusMessage = success ? "Xoa Database thanh cong" : "Khong the xoa Database";

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> AddMigrationAsync()
        {
            await _context.Database.MigrateAsync();
            StatusMessage = "Cap nhat Database thanh cong";

            return RedirectToAction(nameof(Index));
        }
    }
}
