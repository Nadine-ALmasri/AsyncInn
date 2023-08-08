using AsyncInnManagementSystem.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AsyncInnManagementSystem.Models.Interfaces;
using AsyncInnManagementSystem.Models.Services;

namespace AsyncInnManagementSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args); 
            builder.Services.AddControllers();
            string ConnString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<HotelDbContext>(options => options.UseSqlServer(ConnString));
            builder.Services.AddControllers().AddNewtonsoftJson(options =>
         options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
       );
            // Other service registrations...
            builder.Services.AddTransient<IHotels, HotelsServies>();
            builder.Services.AddTransient<IRoom, RoomServies>();
            builder.Services.AddTransient<IAmenities, AmenitiesServies>();
          builder.Services.AddTransient<IHotelRoom, HotelRoomServies>();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title = "hotel API",
                    Version = "v1",
                });
            });
            var app = builder.Build();
            app.UseSwagger(aptions =>
            {
                aptions.RouteTemplate = "/api/{documentName}/swagger.json";
            });
            app.UseSwaggerUI(aptions =>
            {
                aptions.SwaggerEndpoint("/api/v1/swagger.json", "Hotel API");
                aptions.RoutePrefix = "docs";
            });
            app.MapControllers();
            app.MapGet("/", () => "Hello World!");
            app.MapGet("/test", () => "Hello from test !");

            app.Run();
        }
    }
}