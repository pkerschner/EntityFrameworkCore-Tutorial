using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCore_Tutorial.Models {
    // to allow AppDbContext class to inherit DbContext class
    public class AppDbContext : DbContext {
        // properties
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        // constructors
        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        // method uses protected access modifier to match protected access modifier in DbContext class
        protected override void OnConfiguring(DbContextOptionsBuilder builder) {

            if(!builder.IsConfigured) {
                builder.UseSqlServer("server=localhost\\sqlexpress;database=SalesDb1;trusted_connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder) {
            // makes Code unique
            builder.Entity<Item>(
                e => e.HasIndex(x => x.Code)
                        .IsUnique(true)
            );
        }
    }
}
