using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNetMVCTesting.Models;
using ASPNetMVCTesting.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ASPNetMVCTesting
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                CreateDBIfNotExists();
            }

            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        private void CreateDBIfNotExists()
        {
            using (Database db = new Database())
            {
                if (db.Database.EnsureCreated())
                {
                    var course1 = new Course("Programming", "Mario Rossi");
                    var course2 = new Course("Operation Systems", "Giuseppe Verdi");
                    var course1Exam1 = new Exam { Course = course1, ExamDate = new DateTime(2017, 6, 13) };
                    var course1Exam2 = new Exam { Course = course1, ExamDate = new DateTime(2017, 6, 16) };
                    var course2Exam1 = new Exam { Course = course2, ExamDate = new DateTime(2017, 7, 3) };
                    db.Exams.Add(course1Exam1);
                    db.Exams.Add(course1Exam2);
                    db.Exams.Add(course2Exam1);
                    db.SaveChanges();

                }
            }
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();
            services.AddScoped(typeof(Database));
            services.AddScoped(typeof(ICoursesService), typeof(Database));
            services.AddScoped(typeof(IExamsService), typeof(Database));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
