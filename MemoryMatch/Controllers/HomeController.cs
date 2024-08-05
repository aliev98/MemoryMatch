using MemoryGame.Data;
using MemoryMatch.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MemoryMatch.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MemoryGameContext _context;
        private readonly List<string> _themes = new List<string> { "Cars", "Game", "Arrows", "Nature", "Social media" };
        public HomeController(ILogger<HomeController> logger, MemoryGameContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            _context.ClearTable();
            ViewBag.themes = _themes;

            return View();
        }

        [HttpPost]
        public IActionResult Index(string theme)
        {
            HttpContext.Session.SetString("Theme",theme);

            return RedirectToAction("Index", "MemoryGame");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}