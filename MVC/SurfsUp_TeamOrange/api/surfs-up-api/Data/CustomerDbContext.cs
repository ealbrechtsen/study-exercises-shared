using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using surfs_up_api.Models.ViewModels;
using surfs_up_api.Models;
using System;

namespace surfs_up_api.Data
{
    public class CustomerDbContext:IdentityDbContext<AppUser>
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options):base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
    }
}
