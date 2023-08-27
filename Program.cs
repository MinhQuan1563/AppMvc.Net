using AppMvc.Net.Services;
using Microsoft.AspNetCore.Mvc.Razor;

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

            app.UseRouting();

            app.UseAuthentication(); // Xac thuc danh tinh
            app.UseAuthorization(); // Xac thuc quyen truy cap

            // URL: /{controller}/{action}/{id?}
            // Abc/Xyz => Controller=Abc, goi method Xyz
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapRazorPages();

            app.Run();
        }
    }
}