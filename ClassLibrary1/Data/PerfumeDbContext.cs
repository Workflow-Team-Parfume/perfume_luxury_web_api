using Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace Infrustructure.Data
{
    public class RecipeDbContext : IdentityDbContext<User>
    {
        public RecipeDbContext() : base() { }
        public RecipeDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ----------- Set Configurations -----------
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            string connStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PerfumeDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            optionsBuilder.UseSqlServer(connStr);
        }

        // ---------------- Data Collections ----------------
        public DbSet<Amount> Amounts { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Care> Cares { get; set; }
        public DbSet<Parfume> Parfumes { get; set; }
    }
}