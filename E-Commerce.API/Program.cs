
using Domain.Contracts;
using E_Commerce.API.Factories;
using E_Commerce.API.MiddleWare;
using Microsoft.AspNetCore.Mvc;
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
            builder.Services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = ApiResponseFactory.CustomeValidation;

            });
            #region Conection service

            builder.Services.AddDbContext<ApplicatonDbcontext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            #endregion
            #region UnitOFWork-ServiceManger


            builder.Services.AddScoped<IDataSeed, DataSeed>();
            builder.Services.AddScoped<IUnitOfWork, UnitOFWork>();
            builder.Services.AddScoped<IServiceManager, ServiceManager>();

            #endregion
            #region Mapping Service 
            builder.Services.AddAutoMapper(cfg => { }, typeof(ServiceReferance).Assembly);

            #endregion
            var app = builder.Build();

          using var scope = app.Services.CreateScope();
           var Object = scope.ServiceProvider.GetRequiredService<IDataSeed>();
           await Object.DataSeedAsync();
         
            app.UseMiddleware<GlobalExceptionHandlingMiddleWare>(); 

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
