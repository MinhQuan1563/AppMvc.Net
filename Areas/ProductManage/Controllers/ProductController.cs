using AppMvc.Net.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppMvc.Net.Areas.ProductManage.Controllers
{
    [Area("ProductManage")]
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly ProductService _productService;

        public ProductController(ILogger<ProductController> logger, ProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [Route("cac-san-pham.html")]
        // /Areas/AreaName/Views/ControllerName/Action.cshtml
        public IActionResult Index()
        {
            var product = _productService.OrderBy(p => p.Name).ToList();
            return View(product); // -> /Areas/ProductManage/Views/Product/Index.cshtml
        }
    }
}
