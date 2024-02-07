using Ecommerce.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.DataAccess.Contexts;

public class AlizonDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=.;Database=AlizonEcommberce;Trusted_Connection=true;TrustServerCertificate=true;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasIndex(u => u.UserName)
            .IsUnique();

        modelBuilder.Entity<User>()

            .HasIndex(u => u.Email)
            .IsUnique();
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Phone)
            .IsUnique();

        modelBuilder.Entity<Wallet>()
            .HasIndex(w => w.CardNumber)
            .IsUnique();

        modelBuilder.Entity<Product>()
            .HasIndex(p => p.Name)
            .IsUnique();

        modelBuilder.Entity<DeliveryAddress>()
            .HasIndex(da => da.Address)
            .IsUnique();

        modelBuilder.Entity<Category>()
            .HasIndex(c => c.Name)
            .IsUnique();

        modelBuilder.Entity<Brand>()
            .HasIndex(b => b.Name)
            .IsUnique();



        modelBuilder.Entity<User>()
            .HasMany(u => u.DeliveryAddresses)
            .WithOne(da => da.User)
            .HasForeignKey(da => da.UserId);

        modelBuilder.Entity<User>()
            .HasMany(u => u.Wallets)
            .WithOne(w => w.User)
            .HasForeignKey(w => w.UserId);

        modelBuilder.Entity<User>()
            .HasOne(u => u.Basket)
            .WithOne(b => b.User)
            .HasForeignKey<Basket>(b => b.UserId);

        modelBuilder.Entity<User>()
            .HasMany(u => u.Invoices)
            .WithOne(i => i.User)
            .HasForeignKey(i => i.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Wallet>()
            .HasMany(w => w.Invoices)
            .WithOne(i => i.Wallet)
            .HasForeignKey(i => i.WalletId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<BasketProduct>()
            .HasKey(bp => bp.Id);

        modelBuilder.Entity<BasketProduct>()
            .HasOne(bp => bp.Basket)
            .WithMany(b => b.BasketProducts)
            .HasForeignKey(bp => bp.BasketId);

        modelBuilder.Entity<BasketProduct>()
            .HasOne(bp => bp.Product)
            .WithMany(p => p.BasketProducts)
            .HasForeignKey(bp => bp.ProductId);

        modelBuilder.Entity<ProductInvoice>()
           .HasKey(pi => pi.Id);

        modelBuilder.Entity<ProductInvoice>()
            .HasOne(pi => pi.Product)
            .WithMany(p => p.ProductInvoices)
            .HasForeignKey(pi => pi.ProductId);

        modelBuilder.Entity<ProductInvoice>()
            .HasOne(pi => pi.Invoice)
            .WithMany(i => i.ProductInvoices)
            .HasForeignKey(pi => pi.InvoiceId);

        modelBuilder.Entity<Category>()
            .HasMany(c => c.Products)
            .WithOne(p => p.Category)
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Brand>()
            .HasMany(b => b.Products)
            .WithOne(p => p.Brand)
            .HasForeignKey(p => p.BrandId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Discount>()
            .HasMany(d => d.Products)
            .WithOne(p => p.Discount)
            .HasForeignKey(p => p.DiscountId);
    }

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Wallet> Wallets { get; set; } = null!;
    public DbSet<DeliveryAddress> DeliveryAddresses { get; set; } = null!;
    public DbSet<Basket> Baskets { get; set; } = null!;
    public DbSet<BasketProduct> BasketProducts { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Invoice> Invoices { get; set; } = null!;
    public DbSet<ProductInvoice> ProductInvoices { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Brand> Brands { get; set; } = null!;
    public DbSet<Discount> Discounts { get; set; } = null!;
}
