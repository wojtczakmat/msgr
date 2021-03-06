﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using msgr.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using msgr.Models;
using msgr.Services;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Http;
using msgr.Providers;

namespace msgr
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; set; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddMvc();
            services.AddTransient<IRepository<User>, UserRepository>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ICurrentUserProvider, CurrentUserProvider>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCookieAuthentication(new CookieAuthenticationOptions()
                {
                    AuthenticationScheme = "Cookies",
                    LoginPath = new PathString("/Account/Login"),
                    AccessDeniedPath = new PathString("/Account/Forbidden"),
                    AutomaticAuthenticate = true,
                    AutomaticChallenge = true
                });

            app.UseMvc(routes => 
                {
                    routes.MapRoute(
                        name: "default",
                        template: "{controller=Home}/{action=Index}/{id?}");
                });

            // app.Run(async (context) =>
            // {
            //     await context.Response.WriteAsync("Hello Alicia!");
            // });
        }
    }
}
