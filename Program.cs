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
          
            // Other service registrations...
            builder.Services.AddTransient<IHotels, HotelsServies>();
            builder.Services.AddTransient<IRoom, RoomServies>();
            builder.Services.AddTransient<IAmenities, AmenitiesServies>();

            var app = builder.Build();
            app.MapControllers();
            app.MapGet("/", () => "Hello World!");
            app.MapGet("/test", () => "Hello from test !");

            app.Run();
        }
    }
}