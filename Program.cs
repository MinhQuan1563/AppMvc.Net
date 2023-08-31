using AppMvc.Net.ExtendMethods;
using AppMvc.Net.Models;
using AppMvc.Net.Services;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace AppMvc.Net
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var services = builder.Services;

            // Add services to the container.
            services.AddControllersWithViews();
            services.AddRazorPages();

            //services.AddTransient(typeof(ILogger<>), typeof(Logger<>)); // Dich vu nay tu dong dk vao he thong
            services.Configure<RazorViewEngineOptions>(options =>
            {
                // /View/Controller/Action.cshtml
                // Neu tim ko thay dia chi tren thi -> /MyView/Controller/Action.cshtml

                // {0} -> Ten Action
                // {1} -> Ten Controller
                // {2} -> Ten Area
                options.ViewLocationFormats.Add("/MyView/{1}/{0}" + RazorViewEngine.ViewExtension);
            });

            // Co nhieu cach dk dich vu
            services.AddSingleton<ProductService>();
            //services.AddSingleton<ProductService, ProductService>();
            //services.AddSingleton(typeof(ProductService));
            //services.AddSingleton(typeof(ProductService), typeof(ProductService));

            services.AddSingleton<PlanetService>();

            // Database
            services.AddDbContext<AppDbContext>(options =>
            {
                var connectString = builder.Configuration.GetConnectionString("AppMvcConnectionString");
                options.UseSqlServer(connectString);
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles(); // Truy cap cac file tinh trong wwwroot

            app.AddStaticCodePage(); // Tao ra noi dung response tra ve khi co loi tu 400 - 599
            
            app.UseRouting(); // EndpointRoutingMiddleware

            app.UseAuthentication(); // Xac thuc danh tinh
            app.UseAuthorization(); // Xac thuc quyen truy cap

            app.MapRazorPages();

            // URL: /{controller}/{action}/{id?}
            // Abc/Xyz => Controller=Abc, goi method Xyz
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapGet("/sayhi", async context =>
            {
                await context.Response.WriteAsync($"Hello Asp.Net MVC {DateTime.Now}");
            });

            // app.MapControllers
            // app.MapControllerRoute
            // app.MapDefaultControllerRoute
            // app.MapAreaControllerRoute

            app.MapControllerRoute(
                name: "first",
                pattern: "{url:regex(^((xemsanpham)|(viewproduct))$)}/{id:range(2,4)}",
                defaults: new
                {
                    controller = "First",
                    action = "ViewProduct"
                }
                /*constraints: new // IRouteConstraint: rang buoc
                {
                    url = "xemsanpham",
                    id = new RangeRouteConstraint(2, 4)
                }*/);

            // Cac attribute thuong dung
            /*
                [AcceptVerbs]
                [Route]
                [HttpGet]
                [HttpPost]
                [HttpPut]
                [HttpDelete]
                [HttpHead]
                [HttpPatch]
            */


            // URL = start-here
            // controller => 
            // action => 
            // area => 
            // start-here/Home/Privacy
            // start-here/First/ViewProduct/2
            app.MapControllerRoute(
                name: "firstroute",
                pattern: "start-here/{controller=First}/{action=HelloView}/{id?}"
                /*defaults: new // Cach gan mac dinh
                {
                    controller = "First",
                    action = "ViewProduct",
                    id = 3
                }*/
                );

            app.MapAreaControllerRoute(
                name: "product",
                pattern: "{controller}/{action=Index}/{id?}",
                areaName: "ProductManage");

            app.Run();
        }
    }
}