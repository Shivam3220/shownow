using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopNow.Core.Persistence.Common.Entities;

namespace ShopNow.Core.Persistence.Common.Configuration
{
    public class CategoryMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product", "Shopnow");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Uid).HasColumnName("Uid").HasColumnType("uniqueidentifier").IsRequired();
            builder.Property(x => x.Name).HasColumnName("Name").HasColumnType("nvarchar(300)").IsRequired();
            builder.Property(x => x.Description).HasColumnName("Description").HasColumnType("nvarchar(300)").IsRequired();
            builder.Property(x => x.Image).HasColumnName("Image").HasColumnType("nvarchar(300)");
            builder.Property(x => x.Price).HasColumnName("Price").HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(x => x.Stock).HasColumnName("Stock").HasColumnType("int").IsRequired();
            builder.Property(x => x.CreatedOn).HasColumnName("CreatedOn").HasColumnType("datetime2").IsRequired();

            builder.HasMany(p => p.CartProducts)
                    .WithOne(cp => cp.Product)
                    .HasForeignKey(cp => cp.ProductFk)
                    .HasPrincipalKey(p => p.Uid);

            builder.HasMany(p => p.OrderProducts)
                    .WithOne(cp => cp.Product)
                    .HasForeignKey(cp => cp.ProductFk)
                    .HasPrincipalKey(p => p.Uid);
        }
    }
}