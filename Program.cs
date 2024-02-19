
using Microsoft.EntityFrameworkCore;
using ProductShop.DBContexts;
using ProductShop.Repositories;
using Serilog;
using System.Security.Authentication;

namespace ProductShop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("/logs/productShop.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
            var builder = WebApplication.CreateBuilder(args);
            builder.Host.UseSerilog();

            builder.WebHost.ConfigureKestrel(serverOptions =>
            {
                serverOptions.ConfigureHttpsDefaults(listenOptions =>
                {
                    listenOptions.SslProtocols = SslProtocols.Tls13;
                });
            });

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("localhostPolicy", policy => { 
                    policy.WithOrigins("http://localhost:8005/").AllowAnyHeader().AllowAnyMethod(); ;
                    policy.AllowAnyOrigin(); 
                });
            });
            builder.Services.AddDbContext<ProductShopContext>( dbContextOptions => dbContextOptions.UseNpgsql(
                builder.Configuration["ConnectionStrings:ProductShopConnectionString"]
                ));
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<IPositionRepository, PositionRepository>();
            builder.Services.AddScoped<IProductGroupRepository, ProductGroupRepository>();
            builder.Services.AddScoped<IProviderRepository, ProviderRepository>();
            builder.Services.AddScoped<IReasonReturnRepository, ReasonReturnRepository>();
            builder.Services.AddScoped<ISupplyRepository, SupplyRepository>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<ISoltProductRepository, SoltProductRepository>();
            builder.Services.AddScoped<IOverdueProductRepository, OverdueProductRepository>();
            builder.Services.AddScoped<IReturnedProductRepository, ReturnedProductRepository>();
            builder.Services.AddControllers(options =>
            {
                options.ReturnHttpNotAcceptable = true;
            }).AddNewtonsoftJson().AddXmlDataContractSerializerFormatters();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors("localhostPolicy");
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            //app.MapControllers();
            var options = new DefaultFilesOptions();
            options.DefaultFileNames.Clear();
            options.DefaultFileNames.Add("index.html");
            app.UseDefaultFiles(options);

            app.UseStaticFiles();
            app.Run();
        }
    }
}
