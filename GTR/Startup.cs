using GTR.Identity;
using GTR.Infrastructure;
using GTR.Services;
using GTR.Services.Authenticator;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace GTR
{
    public class Startup
    {
        private readonly List<CultureInfo> supportedCultures = new List<CultureInfo>
        {
            new CultureInfo("es-ES"),
            new CultureInfo("en-US"),
            new CultureInfo("fr-FR")
        };

        public IConfiguration Configuration { get; }

        public IHostingEnvironment Environment { get; }

        private const string defaultCulture = "es-ES";
        //private const string defaultCulture = "fr-FR";
        //private const string defaultCulture = "en-US";

        public Startup(IConfiguration configuration, IHostingEnvironment environment)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(environment.ContentRootPath)
                .AddJsonFile("appSettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appSettings.{environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
            Environment = environment;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLocalization(options => options.ResourcesPath = "Resources");

            services.AddHttpContextAccessor();
            services.AddDependencyInjectionCustom(Configuration, Environment);
            services.AddScoped<IClaimsUserInterpreter, ClaimsUserInterpreter>();
            services.AddScoped<IUserIdentity, UserIdentity>();
            services.AddScoped<IAuthenticator, Authenticator>();

            services.AddMvc()

                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization()
                .AddRazorPagesOptions(options =>
                {   //https://exceptionnotfound.net/setting-a-custom-default-page-in-asp-net-core-razor-pages/
                    options.Conventions.AddPageRoute("/Blogs/Index", string.Empty);
                });

            services.Configure<RequestLocalizationOptions>(
                options =>
                {
                    options.SupportedCultures = supportedCultures;
                    options.SupportedUICultures = supportedCultures;
                    options.DefaultRequestCulture = new RequestCulture(culture: defaultCulture, uiCulture: defaultCulture);
                });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(c =>
                {
                    c.LoginPath = new PathString("/Account/login");
                    c.LogoutPath = new PathString("/Account/Logout");
                    c.AccessDeniedPath = new PathString("/Forbidden");
                    c.ExpireTimeSpan = TimeSpan.FromHours(1);
                });

            services.AddAntiforgery(o => o.HeaderName = "XSRF-TOKEN");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddSerilog();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
                app.UseCookiePolicy();
            }

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(defaultCulture),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });

            app.UseWebExceptionHandler();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseMyMiddleware();
            app.UseAuthentication();

            app.UseMvc();
        }
    }
}