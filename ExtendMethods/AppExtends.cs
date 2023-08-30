using Microsoft.AspNetCore.Builder;
using System.Net;

namespace AppMvc.Net.ExtendMethods
{
    public static class AppExtends
    {
        public static void AddStaticCodePage(this IApplicationBuilder app)
        {
            app.UseStatusCodePages(appError =>
            {
                appError.Run(async context =>
                {
                    var response = context.Response;
                    var code = response.StatusCode;

                    var content = $@"
                    <html>
                        <head>
                            <meta charset='utf-8' />
                            <title>Loi {code}</title>
                        </head>
                        <body>
                            <p style='color: red; font-size: 30px;'>
                                Co loi xay ra: {code} - {(HttpStatusCode)code}
                            </p>
                        </body>
                    </html>";

                    await response.WriteAsync(content);
                });

            }); // Tao ra noi dung response tra ve khi co loi tu 400 - 599
        }
    }
}
