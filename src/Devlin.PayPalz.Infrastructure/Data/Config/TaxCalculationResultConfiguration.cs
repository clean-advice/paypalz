using Devlin.PayPalz.Core.TaxCalculation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Devlin.PayPalz.Infrastructure.Data.Config;

public class TaxCalculationResultConfiguration : IEntityTypeConfiguration<TaxCalculationResult>
{
    public void Configure(EntityTypeBuilder<TaxCalculationResult> builder)
    {
        builder.UsePropertyAccessMode(PropertyAccessMode.PreferProperty);

        builder.Property(t => t.CalculatedAt)
            .IsRequired();

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

        builder.OwnsOne(
            t => t.AnnualIncome,
            a =>
            {
                a.WithOwner();
                a.Property(a => a.TaxableAmount)
                    .HasColumnName("AnnualIncome")
                    .IsRequired();
            });

        builder.OwnsOne(
            t => t.TaxPayable,
            t =>
            {
                t.WithOwner();
                t.Property(a => a.Amount)
                    .HasColumnName("TaxPayable")
                    .IsRequired();
            });
    }
}
