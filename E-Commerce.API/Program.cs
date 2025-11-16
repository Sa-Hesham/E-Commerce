
using Domain.Contracts;
using Microsoft.EntityFrameworkCore;

using Presistance.Data;
using Presistance.Repositries;
using Services;
using Services.Abstracion.ServicesManger;
using Services.ServiceManger;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace E_Commerce.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().
                AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            }); ;
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<ApplicatonDbcontext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddScoped<IDataSeed, DataSeed>();  
            builder.Services.AddScoped<IUnitOfWork,UnitOFWork>();
            builder.Services.AddAutoMapper(cfg => { },typeof(ServiceReferance).Assembly);
            builder.Services.AddScoped<IServiceManager,ServiceManager>();
            
            var app = builder.Build();

          using var scope = app.Services.CreateScope();
           var Object = scope.ServiceProvider.GetRequiredService<IDataSeed>();
           await Object.DataSeedAsync();
         

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseStaticFiles();   
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
