using KisaanCafe.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KisaanCafe.Repository
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
            base(options)
        {

        }

        public DbSet<ProductCommand> ProductDetails { get; set; }
        public DbSet<InvoiceDetails> InvoiceDetails { get; set; }
        public DbSet<UserCommand> userDetails { get; set; }
        public DbSet<InvoiceProductDetails> InvoiceProductDetails { get; set; }

    //    protected override void OnModelCreating(ModelBuilder modelBuilder)
    //    {
    //        base.OnModelCreating(modelBuilder);

    //        modelBuilder.Entity<InvoiceDetails>()
    // .HasKey(d => d.Id);

    //        modelBuilder.Entity<InvoiceProductDetails>()
    //            .HasKey(p => p.Id);

    //        //modelBuilder.Entity<InvoiceProductDetails>()
    //        //    .HasOne(p => p.InvoiceDetails)
    //        //    .WithMany(d => d.InvoiceProductDetails)
    //        //    .HasForeignKey(p => p.InvoiceDetailsId)
    //        //    .OnDelete(DeleteBehavior.Cascade);
    //    }
      }
}
