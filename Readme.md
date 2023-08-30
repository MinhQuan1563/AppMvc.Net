## Controller
- Là 1 lớp kế thừa từ lớp Controller: Microsoft.AspNetCore.Mvc.Controller
- Action trong Controller là 1 phương thức public (không được static)
- Action trả về bất kỳ kiểu dữ liệu nào, thường là IActionResult
- Các dịch vụ inject vào Controller qua hàm tạo

## View
- Là file .cshtml
- View trong Action lưu tại: /View/ControllerName/ActionName.cshtml
- Thêm thư mục lưu trữ View:
```
// {0}: Tên Action
// {1}: Tên Controller
// {2}: Tên Area
options.ViewLocationFormats.Add("/MyView/{1}/{0}" + RazorViewEngine.ViewExtension);
```

## Truyền dữ liệu sang View
- Model
- ViewData
- ViewBag
- TempData

## Areas
- Là tên dùng để routing
- Là cấu trúc thư mục chứa MVC
- Thiết lập Area cho controller bằng ```[Area("AreaName")]```

## Route
- app.MapControllerRoute
- app.MapAreaControllerRoute
- [AcceptVerbs("POST", "Get")]
- [Route("pattern")]
- [HttpGet] [HttpPost]

## Url Generation
### UrlHelper : Action, ActionLink, RouteUrl, Link
```
Url.Action("PlaneInfo", "Planet", new {id = 3}, Context.Request.Scheme)

Url.RouteUrl("default", new {action="HelloView", Controller="Home", id=123, name="MinhQuan"})
```
### HtmlTagHelper: <a> <button> <form>
Sử dụng thuộc tính:
```
asp-area="Area"
asp-action="Action"
asp-controller="Product"
asp-route-...="123"
asp-route="default"
```



