
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using surfs_up_api.Data;
using surfs_up_api.Models;

namespace surfs_up_api
{

    public class Program
    {

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var connectionString = builder.Configuration.GetConnectionString("CustomerConnection");

            var connectionString1 = builder.Configuration.GetConnectionString("DbConnectionString");
            builder.Services.AddDbContext<AppDbContext>(
                options => options.UseSqlServer(connectionString1));

            builder.Services.AddDbContext<CustomerDbContext>(options => options.UseSqlServer(connectionString));

            builder.Services.AddIdentity<AppUser, IdentityRole>(
                options =>
                {
                    options.Password.RequiredUniqueChars = 0;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequiredLength = 8;
                    options.Password.RequireNonAlphanumeric = false;
                }
                )
                .AddEntityFrameworkStores<CustomerDbContext>().AddDefaultTokenProviders();

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
