namespace WebApi
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using WebApi.Core;
    using Microsoft.EntityFrameworkCore;
    using WebApi.Core.Services;
    using WebApi.Common.Helpers;
    using WebApi.Common.Factories;

    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();

            HelperAppSettings appSettings = new HelperAppSettings(Configuration);
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            AutoMapperConfiguration.Config();

            services.AddMvc();

            services.AddDbContext<NORTHWNDContext>(options => options.UseSqlServer(HelperAppSettings.ConnectionString));

            RegisterIoC(services);

            //services.Configure<AppSettings>(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseCors(
              builder => builder.WithOrigins("*")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowAnyOrigin()
              .AllowCredentials()
          );

            // Only uncomment this line to insert fake Quizz data to SQL
            // app.FakeQuizzData();

            app.UseMvc();
        }
        
        private void RegisterIoC(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddSingleton<ICategoryService, CategoryService>();

            services.AddSingleton<ICustomerCustomerDemoService, CustomerCustomerDemoService>();

            services.AddSingleton<ICustomerDemographicsService, CustomerDemographicsService>();

            services.AddSingleton<ICustomersService, CustomersService>();

            services.AddSingleton<IEmployeesService, EmployeesService>();

            services.AddSingleton<IEmployeeTerritoriesService, EmployeeTerritoriesService>();

            services.AddSingleton<IOrderDetailsService, OrderDetailsService>();

            services.AddSingleton<IOrdersService, OrdersService>();

            services.AddSingleton<IProductsService, ProductsService>();

            services.AddSingleton<IRegionService, RegionService>();

            services.AddSingleton<IShippersService, ShippersService>();

            services.AddSingleton<ISuppliersService, SuppliersService>();

            services.AddSingleton<ITerritoriesService, TerritoriesService>();

            ResolverFactory.SetProvider(services.BuildServiceProvider());
        }
    }
}
