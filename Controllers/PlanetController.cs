using AppMvc.Net.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppMvc.Net.Controllers
{
    [Route("he-mat-troi/[action]")]
    public class PlanetController : Controller
    {
        private readonly PlanetService _planetService;
        private readonly ILogger<PlanetController> _logger;
        public PlanetController(PlanetService planetService, ILogger<PlanetController> logger)
        {
            _planetService = planetService;
            _logger = logger;
        }

        [Route("/danh-sach-cac-hanh-tinh.html")]
        // Neu co dau "/" (Dia chi tuyet doi) thi truy cap /danh-sach-cac-hanh-tinh.html
        // Khong quan tam dia chi Route o controller
        public IActionResult Index() // he-mat-troi/danh-sach-cac-hanh-tinh.html
        {
            return View();
        }

        // route: action
        [BindProperty(SupportsGet = true, Name = "action")]
        public string Name { get; set; } // Action ~ PlanetModel

        public IActionResult Mercury()
        {
            var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
            return View("Detail", planet);
        }

        public IActionResult Venus()
        {
            var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
            return View("Detail", planet);
        }

        public IActionResult Earth()
        {
            var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
            return View("Detail", planet);
        }

        public IActionResult Mars()
        {
            var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
            return View("Detail", planet);
        }

        [HttpGet("/sao-moc.html")]
        public IActionResult Jupiter()
        {
            var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
            return View("Detail", planet);
        }

        public IActionResult Saturn()
        {
            var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
            return View("Detail", planet);
        }

        public IActionResult Uranus()
        {
            var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
            return View("Detail", planet);
        }

        [Route("sao/[action]", Order = 2, Name = "neptune1")]                 // sao/Neptune
        [Route("sao/[controller]/[action]", Order = 3, Name = "neptune2")]    // * sao/Planet/Neptune
        [Route("[controller]-[action].html", Order = 1, Name = "neptune3")]   // Planet-Neptune.html
        public IActionResult Neptune()
        {
            var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
            return View("Detail", planet);
        }

        [Route("hanh-tinh/{id:int}")] // hanh-tinh/1
        public IActionResult PlanetInfo(int id)
        {
            var planet = _planetService.Where(p => p.Id == id).FirstOrDefault();
            return View("Detail", planet);
        }
    }
}
