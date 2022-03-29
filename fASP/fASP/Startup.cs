using fASP.Domain;
using fASP.Domain.Repositories.Abstract;
using fASP.Domain.Repositories.EntityFramework;
using fASP.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace fASP
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public void ConfigureServices(IServiceCollection services) 
        {
            //подключаем конфиги
            Configuration.Bind("Project", new Config());

            //подключаем нужный функционал приложения в качестве сервисов
            services.AddTransient<ITextFieldRepository, EFTextFieldsRepository>();
            services.AddTransient<IServiceItemsRepository, EFServiceItemsRepository>();
            services.AddTransient<DataManager>();

            //подключаем контекст БД
            services.AddDbContext<AppDbContext>(x => x.UseSqlServer(Config.ConnectionString));

            //настройка identity системы
            services.AddIdentity<IdentityUser, IdentityRole>(opts =>
            {
                opts.User.RequireUniqueEmail = true;
                opts.Password.RequiredLength = 128;

            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

            //настраиваем cookie
            services.ConfigureApplicationCookie(opts =>
            {
                opts.Cookie.Name = "testAuth";
                opts.Cookie.HttpOnly = true;
                opts.LoginPath = "/account/login";
                opts.AccessDeniedPath = "/account/accessdenied";
                opts.SlidingExpiration = true;
            });

            services.AddControllersWithViews()
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0).AddSessionStateTempDataProvider();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) 
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //поддержка статических файлов проекта (wwwroot)
            app.UseStaticFiles();

            //маршрутизация
            app.UseRouting();

            //аутентификация и авторизация
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();
            
            //регистрация маршрутов
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
