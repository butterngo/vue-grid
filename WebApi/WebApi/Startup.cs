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
    using Microsoft.IdentityModel.Tokens;
    using System;
    using System.Text;
    using WebApi.JWT;
    using Microsoft.Extensions.Options;
    using WebApi.Core.Identity;

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

            AutoMapperConfiguration.Config();

            HelperAppSettings appSettings = new HelperAppSettings(Configuration);
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            services.AddMvc();

            services.AddDbContext<NORTHWNDContext>(options => options.UseSqlServer(HelperAppSettings.ConnectionString, b => b.MigrationsAssembly("WebApi.Core")));

            services.AddIdentity<User, Roles>(Options => WebApiUserManager.CreateOptions(Options))
                    .AddEntityFrameworkStores<NORTHWNDContext>();

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
            app.UseIdentity();

            SetupOauth(app);

            app.UseMvc();
        }

        private void SetupOauth(IApplicationBuilder app)
        {
            // Add JWT generation endpoint:
            var secretKey = "mysupersecret_secretkey!123";
            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));
            var options = new TokenProviderOptions
            {
                Audience = "ExampleAudience",
                Issuer = "ExampleIssuer",
                SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256),
            };

            app.UseMiddleware<TokenProviderMiddleware>(Options.Create(options));

            var tokenValidationParameters = new TokenValidationParameters
            {
                // The signing key must match!
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,

                // Validate the JWT Issuer (iss) claim
                ValidateIssuer = true,
                ValidIssuer = "ExampleIssuer",

                // Validate the JWT Audience (aud) claim
                ValidateAudience = true,
                ValidAudience = "ExampleAudience",

                // Validate the token expiry
                ValidateLifetime = true,

                // If you want to allow a certain amount of clock drift, set that here:
                ClockSkew = TimeSpan.Zero,

            };

            app.UseJwtBearerAuthentication(new JwtBearerOptions
            {
                AutomaticAuthenticate = true,
                AutomaticChallenge = true,
                TokenValidationParameters = tokenValidationParameters,
                Events = new JwtEvents(tokenValidationParameters)
        });
        }

        private void RegisterIoC(IServiceCollection services)
        {
            
            services.AddScoped<WebApiUserManager, WebApiUserManager>();

            services.AddScoped<WebApiRoleManager, WebApiRoleManager>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ICategoryService, CategoryService>();

            services.AddScoped<ICustomerCustomerDemoService, CustomerCustomerDemoService>();

            services.AddScoped<ICustomerDemographicsService, CustomerDemographicsService>();

            services.AddScoped<ICustomersService, CustomersService>();

            services.AddScoped<IEmployeesService, EmployeesService>();

            services.AddScoped<IEmployeeTerritoriesService, EmployeeTerritoriesService>();

            services.AddScoped<IOrderDetailsService, OrderDetailsService>();

            services.AddScoped<IOrdersService, OrdersService>();

            services.AddScoped<IProductsService, ProductsService>();

            services.AddScoped<IRegionService, RegionService>();

            services.AddScoped<IShippersService, ShippersService>();

            services.AddScoped<ISuppliersService, SuppliersService>();

            services.AddScoped<ITerritoriesService, TerritoriesService>();

            services.AddScoped<IClientService, ClientService>();

            ResolverFactory.SetProvider(services.BuildServiceProvider());
        }
    }
}
