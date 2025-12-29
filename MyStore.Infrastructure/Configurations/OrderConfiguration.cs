using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyStore.Domain.Entities;

namespace MyStore.Infrastructure.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            builder.HasKey(o => o.Id);

            builder.Property(o => o.CreateDate)
                   .IsRequired();

            builder.Property(o => o.UpdateDate)
                   .IsRequired();

            builder.Property(o => o.Description)
                   .HasMaxLength(300);

            builder.HasOne(o => o.CreateByUser)
                   .WithMany(u => u.Orders)
                   .HasForeignKey(o => o.CreateByUserId)
                   .IsRequired();
        }
    }
}
