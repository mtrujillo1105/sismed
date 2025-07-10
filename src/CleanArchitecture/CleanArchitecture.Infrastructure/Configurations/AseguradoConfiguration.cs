using CleanArchitecture.Domain.AcreditacionDB.Accidentes;
using CleanArchitecture.Domain.CoreDB.Asegurados;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Configurations;

internal sealed class AseguradoConfiguration : IEntityTypeConfiguration<Asegurado>
{
    public void Configure(EntityTypeBuilder<Asegurado> builder)
    {
        builder.ToTable("Asegurados");
        builder.HasKey(accidente => accidente.Id);

        builder.Property(accidente => accidente.Id)
            .HasConversion(aseguradoId => aseguradoId!.Value, value => new AseguradoId(value));

        builder.Property(a => a.CodigoParentesco)
            .HasColumnName("CodigoParentesco")
            .HasMaxLength(200)
            .IsRequired(false);

        builder.Property(a => a.NumeroContrato)
            .HasColumnName("NumeroContrato")
            .HasMaxLength(200)
            .IsRequired(false);

    }
}