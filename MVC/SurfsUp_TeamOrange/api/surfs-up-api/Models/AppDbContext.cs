using Microsoft.EntityFrameworkCore;

namespace surfs_up_api.Models
{
    public class AppDbContext : DbContext
    {
        // KIG HER
        public DbSet<Product> Products { get; set; }
        

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        
        // OnModelCreating SEEDING LOGIC (måske)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //var products = ProductRepository.GetProducts();
            
            //modelBuilder.Entity<Product>().HasData(

            
            //base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Product>().HasData
                //(
                //new Product(1, "The Minilog", "/images/the_minilog.webp", 6, 21, 2.75, 38.8, "Shortboard", 565),
                //new Product(2, "The Wide Glider", "/images/the_wide_glider.webp", 7.1, 21.75, 2.75, 44.16, "Funboard", 685),
                //new Product(11, "The Golden Ratio", "/images/the_golden_ratio.webp", 6.3, 21.85, 2.9, 43.22, "Funboard", 695),
                //new Product(12, "Mahi Mahi", "/images/mahi_mahi.webp", 5.4, 20.75, 2.3, 29.39, "Fish", 645)
                //);
            base.OnModelCreating(modelBuilder);
            
        }
        
    }
}

    

