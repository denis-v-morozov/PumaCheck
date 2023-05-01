using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Identity.Client;
using System.Reflection.Metadata;

namespace WebApplication1.Models.Repository
{
    public class PantherDbContext : DbContext
    {
        public PantherDbContext(DbContextOptions<PantherDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //denis note: creating foreign key relationships

            //from MSDN blog class 'posts' - 'post' has a 'blog' as a relationship
            //modelBuilder.Entity<Blog>()
            //            .HasMany(e => e.Posts)
            //            .WithOne(e => e.Blog)
            //            .HasForeignKey(e => e.BlogId)
            //            .HasPrincipalKey(e => e.Id);
            //--------------------------------------------------------------------
            // - don't think I need it, looks like it got done by default
            //modelBuilder.Entity<Customer>()
            //            .HasMany(e => e.Orders)
            //            .WithOne(e => e.Customer)
            //            .HasForeignKey(e => e.CustomerId)
            //            .HasPrincipalKey(e => e.CustomerId);

            //don't think need these any more - commenting out as I reworked the DB Model
            //modelBuilder.Entity<Order>()
            //            .HasOne<Customer>(o => o.Customer)
            //            .WithMany()
            //.HasForeignKey(o => o.Customer.CustomerId);

            //modelBuilder.Entity<OrderDetailedTask>()
            //            .HasOne<Order>(o => o.Order)
            //            .WithMany()
            //            .HasForeignKey(o => o.OrderId);
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetailedTask> OrderDetailedTasks { get; set; }

    }
}
