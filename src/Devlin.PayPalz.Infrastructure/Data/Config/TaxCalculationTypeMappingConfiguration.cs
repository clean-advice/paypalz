using Devlin.PayPalz.Core.TaxCalculation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Devlin.PayPalz.Infrastructure.Data.Config;

public class TaxCalculationTypeMappingConfiguration : IEntityTypeConfiguration<TaxCalculationTypeMapping>
{
    public void Configure(EntityTypeBuilder<TaxCalculationTypeMapping> builder)
    {
        builder.OwnsOne(
            t => t.PostalCode,
            p =>
            {
                p.WithOwner();
                p.Property(a => a.Code)
                    .HasColumnName("PostalCode")
                    .HasMaxLength(4)
                    .IsRequired();
            });

        builder.Property(p => p.TaxCalculationType)
            .HasColumnName("CalculationType")
            .HasConversion(
                p => p.Value,
                p => TaxCalculationType.FromValue(p))
            .IsRequired();
    }
}
