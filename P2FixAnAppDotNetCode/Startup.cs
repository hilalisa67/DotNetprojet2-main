using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using P2FixAnAppDotNetCode.Models;
using P2FixAnAppDotNetCode.Models.Repositories;
using P2FixAnAppDotNetCode.Models.Services;
using CultureInfo = System.Globalization.CultureInfo;

namespace P2FixAnAppDotNetCode
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLocalization(opts => { opts.ResourcesPath = "Resources"; });
            services.AddSingleton<ICart, Cart>();
            services.AddSingleton<ILanguageService, LanguageService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddSingleton<IProductRepository, ProductRepository>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddMemoryCache();
            services.AddSession();
            services.AddControllersWithViews();
            services.AddMvc()
                .AddViewLocalization(
                    LanguageViewLocationExpanderFormat.Suffix,
                    opts => { opts.ResourcesPath = "Resources"; })
                .AddDataAnnotationsLocalization();

            services.Configure<RequestLocalizationOptions>(opts =>
            { 
                var supportedCultures = new[]
                {
                    new CultureInfo("en-GB"),
                    new CultureInfo("en-US"),
                    new CultureInfo("en"),
                    new CultureInfo("fr-FR"),
                    new CultureInfo("fr"),
                    new CultureInfo("es-ES"),
                    new CultureInfo("es")
                };

                opts.DefaultRequestCulture = new RequestCulture("en-US");
                opts.SupportedCultures = supportedCultures;
                opts.SupportedUICultures = supportedCultures;
                
            });
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var localizationOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>().Value;
            app.UseRequestLocalization(localizationOptions);
            
            app.UseStaticFiles();
            var options = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(options.Value);
            app.UseSession();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Product}/{action=Index}/{id?}");
            });
        }
    }
}
