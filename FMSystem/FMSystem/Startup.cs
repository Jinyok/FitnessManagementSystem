using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FMSystem.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Microsoft.OpenApi.Models;
using System.IO;
using System.Reflection;
using MySql.Data.MySqlClient;
using FMSystem.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Logging.Log4Net.AspNetCore.Entities;
using LogDashboard;
using FMSystem.Entity;
using FMSystem.Interface;
using FMSystem.Service;
using FMSystem.Entity.fms;

namespace FMSystem
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddHttpContextAccessor();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, o =>
            {
                o.LoginPath = new PathString("/Home/Login");
                o.AccessDeniedPath = new PathString("/Home/Privacy");

            });
            //mysql
            var builder = new MySqlConnectionStringBuilder(Configuration.GetConnectionString("DefaultConnection"))
            {
                Password = Configuration.GetSection("dbpassward")["default"],
                Database = "fms"
            };
            services.AddDbContextPool<fmsContext>(options => options
            .UseMySql(builder.ConnectionString, mySqlOptions => mySqlOptions
            .ServerVersion(Configuration.GetConnectionString("Version"))));

            //swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FMS API", Version = "v1" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services.AddLogging(logger =>
            {
                logger.ClearProviders();
                Log4NetProviderOptions options = new Log4NetProviderOptions("log4net.config");
                options.PropertyOverrides = new List<NodeInfo>{
                    //new NodeInfo() {
                    //    XPath = "/log4net/appender[@name='SQLAppender']/connectionString",
                    //    Attributes = new Dictionary<string, string> { { "value", $"{builder.ConnectionString}" } } },
                    new NodeInfo { 
                        XPath = "/log4net/appender/file[last()]", 
                        Attributes = new Dictionary<string, string> { { "value", $"{AppContext.BaseDirectory}LogFiles/" } } }
                };
                logger.AddLog4Net(options);
            });

            services.AddLogDashboard();

            //
            services.AddScoped<ICoachService, CoachService>();
            services.AddScoped<IMemberService, MemberService>();
            services.AddScoped<ISectionService, SectionService>();
            services.AddScoped<ITakeService, TakeService>();
            services.AddScoped<SectionService>();
            services.AddScoped<LessonService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            //swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "FMS API V1");
            });

            app.UseLogDashboard();

            //Auth
            var serviceProvider = app.ApplicationServices;
            AuthContext.Configure(serviceProvider.GetService<IHttpContextAccessor>());
        }
    }
}
