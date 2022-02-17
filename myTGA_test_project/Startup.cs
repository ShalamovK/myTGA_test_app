using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using myTGA.BLL.Services;
using myTGA.DAL;
using myTGA_Common.Contracts;
using myTGA_Common.Contracts.Services;
using myTGA_test_project.App_Start;

namespace myTGA_test_project {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services) {
            // Init DB settings
            services.AddDbContextFactory<myTGADbContext>(opts => 
            opts.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("MyTgaDatabase")), ServiceLifetime.Scoped);

            services.AddControllersWithViews();

            // Services
            services.AddScoped<IReportService, ReportService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<ITaskService, TaskService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Auto Mapper Configurations
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutomapperProfile());
            });

            mapperConfig.AssertConfigurationIsValid();

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            } else {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            DbSeed.SeedData(app.ApplicationServices);
        }
    }
}
