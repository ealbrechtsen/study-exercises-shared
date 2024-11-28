using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using surfs_up_project.Models;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

//SeedDatabase(app);


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
}

app.Run();


/*
// Program.cs SEEDING LOGIC (Måske)
void SeedDatabase(IHost app)
{
    using (var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        //dbContext.Database.Migrate();

        if (!dbContext.Products.Any())
        {
            var products = ProductRepository.GetProducts();
            //dbContext.Products.AddRange(ProductRepository.GetProducts());
            dbContext.Products.AddRange(products);
            dbContext.SaveChanges();
        }


    }

}

*/