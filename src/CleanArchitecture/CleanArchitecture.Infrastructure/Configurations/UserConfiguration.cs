using CleanArchitecture.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Configurations;

internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");

        builder.HasKey(user => user.Id);

        builder.Property(user => user.Id)
            .HasConversion(userId => userId!.Value, value => new UserId(value));

        builder.Property(user => user.Nombre)
            .HasMaxLength(200);


        builder.Property(user => user.Apellido)
        .HasMaxLength(200);

        builder.Property(user => user.Email)
        .HasMaxLength(400);

        builder.HasIndex(user => user.Email).IsUnique();
    }
}