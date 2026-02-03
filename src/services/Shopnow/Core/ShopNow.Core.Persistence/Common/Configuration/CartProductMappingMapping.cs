using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShopNow.Core.Persistence.Common.Configuration
{
    public class CartProductMappingMapping : IEntityTypeConfiguration<Entities.CartProductMapping>
    {
        public void Configure(EntityTypeBuilder<Entities.CartProductMapping> builder)
        {
            builder.ToTable("OrderProductMapping", "Shopnow");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Uid).HasColumnName("Uid").HasColumnType("uniqueidentifier").IsRequired();
            builder.Property(x => x.CartFk).HasColumnName("CartFk").HasColumnType("uniqueidentifier").IsRequired();
            builder.Property(x => x.ProductFk).HasColumnName("ProductFk").HasColumnType("uniqueidentifier").IsRequired();
            builder.Property(x => x.PurchasePrice).HasColumnName("SubTotal").HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(x => x.Quantity).HasColumnName("TotalItem").HasColumnType("int").IsRequired();
            builder.Property(x => x.CreatedOn).HasColumnName("CreatedOn").HasColumnType("datetime2").IsRequired();
        }
    }
}