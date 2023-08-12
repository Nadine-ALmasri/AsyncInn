using AsyncInnManagementSystem.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AsyncInnManagementSystem.Models.Interfaces;
using AsyncInnManagementSystem.Models.Services;
using AsyncInnManagementSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;

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
            /// regstor the identty
          builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                
                // There are other options like this
            })
.AddEntityFrameworkStores<HotelDbContext>();
            builder.Services.AddTransient<IUser, UserServies>();

            builder.Services.AddTransient<IHotels, HotelsServies>();
            builder.Services.AddTransient<IRoom, RoomServies>();
            builder.Services.AddTransient<IAmenities, AmenitiesServies>();
          builder.Services.AddTransient<IHotelRoom, HotelRoomServies>();
            builder.Services.AddScoped<JWTServies>();

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = JWTServies.GetValidationPerameters(builder.Configuration);
            });

            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title = "hotel API",
                    Version = "v1",
                });
            });

            var app = builder.Build();
            app.UseAuthentication();
            app.UseAuthorization();
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