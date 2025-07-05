using CleanArchitecture.Domain.AcreditacionDB.Accidentes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Configurations;

internal sealed class AccidenteConfiguration : IEntityTypeConfiguration<Accidente>
{
    public void Configure(EntityTypeBuilder<Accidente> builder)
    {
        builder.ToTable("Accidentes");
        builder.HasKey(accidente => accidente.Id);

        builder.Property(a => a.IdAsegurado)
             .HasColumnName("IdAsegurado");

        builder.Property(a => a.Descripcion)
            .HasColumnName("Descripcion")
            .HasMaxLength(100)
            .IsRequired(false);

        builder.Property(a => a.CodIpress)
            .HasColumnName("CodIpress")
            .HasMaxLength(100)
            .IsRequired(false);

    }
    
}