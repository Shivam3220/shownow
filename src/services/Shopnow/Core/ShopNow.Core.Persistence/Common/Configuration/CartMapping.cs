using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopNow.Core.Persistence.Common.Entities;

namespace ShopNow.Core.Persistence.Common.Configuration
{
    public class CartMapping : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.ToTable("Cart", "Shopnow");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Uid).HasColumnName("Uid").HasColumnType("uniqueidentifier").IsRequired();
            builder.Property(x => x.UserFk).HasColumnName("UserFk").HasColumnType("uniqueidentifier").IsRequired();
            builder.Property(x => x.Status).HasColumnName("Status").HasColumnType("nvarchar(50)").IsRequired();
            builder.Property(x => x.Coupon).HasColumnName("Coupon").HasColumnType("nvarchar(50)");
            builder.Property(x => x.SubTotal).HasColumnName("SubTotal").HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(x => x.Discount).HasColumnName("Discount").HasColumnType("decimal(18,2)");
            builder.Property(x => x.TotalItem).HasColumnName("TotalItem").HasColumnType("int").IsRequired();
            builder.Property(x => x.CreatedOn).HasColumnName("CreatedOn").HasColumnType("datetime2").IsRequired();

            builder.HasMany(c => c.CartProducts)
                    .WithOne(cp => cp.Cart)
                    .HasForeignKey(cp => cp.CartFk)
                    .HasPrincipalKey(c => c.Uid);
        }
    }
}