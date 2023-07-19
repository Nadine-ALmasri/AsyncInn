using AsyncInnManagementSystem.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
namespace AsyncInnManagementSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            string ConnString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<HotelDbContext>(options => options.UseSqlServer(ConnString));
            builder.Services.AddControllers();
            // Other service registrations...

            var app = builder.Build();
            app.MapControllers();
            app.MapGet("/", () => "Hello World!");
            app.MapGet("/test", () => "Hello from test !");

            app.Run();
        }
    }
}