using EFWithValueObject.Api.Db.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFWithValueObject.Api.Db.EntityTypeConfiguration
{
    public class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(user => user.Id);

            builder.Property(user => user.Username)
                   .HasColumnName("Username");

            builder.OwnsOne(user => user.Address,
                            navigationBuilder =>
                            {
                                navigationBuilder.Property(hash => hash.Country)
                                                 .HasColumnName("Country");
                                navigationBuilder.Property(hash => hash.City)
                                                 .HasColumnName("City");
                            });
        }
    }
}