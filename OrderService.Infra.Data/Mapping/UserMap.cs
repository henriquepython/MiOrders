using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderService.Domain.Models;

namespace OrderService.Infra.Data.Mapper;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(prop => prop.id)
            .HasColumnName("Id");

        builder.Property(prop => prop.name)
            .HasColumnType("varchar(100)")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(prop => prop.email)
            .HasColumnType("varchar(100)")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(prop => prop.phoneNumber)
            .IsRequired();

        builder.Property(prop => prop.roles)
            .IsRequired();

        builder.HasMany(prop => prop.carts)
            .WithOne()
            .HasForeignKey(prop => prop.userId);

    }
}
