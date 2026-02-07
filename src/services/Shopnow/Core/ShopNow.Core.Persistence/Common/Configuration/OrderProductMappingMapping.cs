using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShopNow.Core.Persistence.Common.Configuration
{
    public class OrderProductMappingMapping : IEntityTypeConfiguration<Entities.OrderProductMapping>
    {
        public void Configure(EntityTypeBuilder<Entities.OrderProductMapping> builder)
        {
            builder.ToTable("OrderProductMapping", "Shopnow");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Uid).HasColumnName("Uid").HasColumnType("uniqueidentifier").IsRequired();
            builder.Property(x => x.OrderFk).HasColumnName("OrderFk").HasColumnType("uniqueidentifier").IsRequired();
            builder.Property(x => x.ProductFk).HasColumnName("ProductFk").HasColumnType("uniqueidentifier").IsRequired();
            builder.Property(x => x.PurchasePrice).HasColumnName("SubTotal").HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(x => x.Quantity).HasColumnName("TotalItem").HasColumnType("int").IsRequired();
            builder.Property(x => x.CreatedOn).HasColumnName("CreatedOn").HasColumnType("datetime2").IsRequired();

            builder.HasOne(cp => cp.Order)
                .WithMany(c => c.OrderProducts)
                .HasForeignKey(cp => cp.OrderFk)
                .HasPrincipalKey(c => c.Uid);

            builder.HasOne(cp => cp.Product)
                .WithMany(p => p.OrderProducts)
                .HasForeignKey(cp => cp.ProductFk)
                .HasPrincipalKey(p => p.Uid);
        }
    }
}