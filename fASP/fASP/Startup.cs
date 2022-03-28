using Microsoft.AspNetCore.Mvc;

namespace fASP
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services) 
        {
            services.AddControllersWithViews()
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0).AddSessionStateTempDataProvider();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) 
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //маршрутизация
            app.UseRouting();
            //поддержка статических файлов проекта (wwwroot)
            app.UseStaticFiles();
            //регистрация маршрутов
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
