
using HOSPITAL.DOMAIN.Data;
using HOSPITAL.DOMAIN.Interfaces;
using HOSPITAL.DOMAIN.Services;
using Microsoft.EntityFrameworkCore;

namespace HOSPITAL.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            string connString = builder.Configuration.GetConnectionString("DefaultConnection")!;
            builder.Services.AddDbContext<AppDbContext>(o => o.UseNpgsql(connString));
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IHospitalizationService, HospitalizationService>();
            builder.Services.AddScoped<IHealingEventService, HealingEventService>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
