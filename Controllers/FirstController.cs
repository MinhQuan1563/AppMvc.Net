using AppMvc.Net.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppMvc.Net.Controllers
{
    public class FirstController : Controller
    {
        private readonly ILogger<FirstController> _logger;
        private readonly IWebHostEnvironment _env;
        private readonly ProductService _productService;
        public FirstController(ILogger<FirstController> logger, IWebHostEnvironment env, ProductService productService)
        {
            _logger = logger;
            _env = env;
            _productService = productService;
        }

        public string Index()
        {
            /*
                this.HttpContext
                this.Request
                this.Response
                this.RouteData

                this.User
                this.ModelState
                this.ViewData
                this.ViewBag
                this.TempData
                this.Url
            */

            _logger.LogDebug("Log Debug");
            _logger.LogInformation("Thong tin cua FirstController");
            _logger.LogWarning("Log Warning");
            _logger.LogError("Log Error");
            _logger.LogCritical("Log Critical");


            return "Toi la Index cua First";
        }

        public object Anything() => new int[] { 1, 2, 3, 4 };

        /*
            Kiểu trả về                 | Phương thức
            ------------------------------------------------
            ContentResult               | Content()
            EmptyResult                 | new EmptyResult()
            FileResult                  | File()
            ForbidResult                | Forbid()
            JsonResult                  | Json()
            LocalRedirectResult         | LocalRedirect()
            RedirectResult              | Redirect()
            RedirectToActionResult      | RedirectToAction()
            RedirectToPageResult        | RedirectToRoute()
            RedirectToRouteResult       | RedirectToPage()
            PartialViewResult           | PartialView()
            ViewComponentResult         | ViewComponent()
            StatusCodeResult            | StatusCode()
            ViewResult                  | View() 
        */

        public IActionResult Readme()
        {
            var content = @"
                Xin chao cac ban,
                Cac ban dang hoc ve ASP.NET MVC
                


        

                XUANTHULAB.NET
            ";
            return Content(content, "text/html");
        }

        public IActionResult MonsterImg()
        {
            // _env.ContentRootPath
            string filePath = Path.Combine(_env.ContentRootPath, "Files", "anh1.png");
            var bytes = System.IO.File.ReadAllBytes(filePath);

            return File(bytes, "image/png");
        }

        public IActionResult IphonePrice()
        {
            return Json(new
            {
                ProductName = "Iphone 11",
                Price = 12000
            });
        }

        public IActionResult Privacy()
        {
            var url = Url.Action("Privacy", "Home"); // O trang Privacy tai controller Home
            _logger.LogInformation($"Chuyen huong den: {url}");
            return LocalRedirect(url); // local ~ host
        }

        public IActionResult Google()
        {
            var url = "https://google.com";
            _logger.LogInformation($"Chuyen huong den: {url}");
            return Redirect(url); // chuyen huong den trang ben ngoai
        }

        // ViewResult  |  View()
        public IActionResult HelloView(string username)
        {
            if (string.IsNullOrEmpty(username))
                username = "Khach";

            // View() -> Razor Engine, doc .cshtml (template)
            // ----------------------------------------------
            // View(template) -> template la duong dan tuyet doi toi .cshtml
            // View(template, model)

            //return View("/MyView/xinchao1.cshtml", username);

            // xinchao2 -> /View/First/xinchao2.cshtml
            //return View("xinchao2", username);

            // HelloView -> /View/First/HelloView.cshtml
            //return View((object)username);

            // Cau truc chung => /View/Controller/Action.cshtml

            return View("xinchao3", username);
        }

        [TempData]
        public string StatusMessage { get; set; }

        public IActionResult ViewProduct(int? id)
        {
            var products = _productService.Where(p => p.Id == id).FirstOrDefault();
            if (products == null)
            {
                //TempData["StatusMessage"] = $"Khong tim thay san pham co id = {id}";
                StatusMessage = $"Khong tim thay san pham co id = {id}";
                return Redirect(Url.Action("Index", "Home"));
            }

            

            // Razor engine se tim theo cach: /View/First/ViewProduct.cshtml
            // Neu ko thay thi tiep tuc tim o: /MyView/First/ViewProduct.cshtml

            // Model
            //return View(products);

            // ViewData
            /*ViewData["products"] = products;
            return View("ViewProduct2");*/

            // ViewBag
            ViewBag.product = products;
            return View("ViewProduct3");
        }
    }
}
