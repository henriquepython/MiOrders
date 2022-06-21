using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderService.Domain.Models;

namespace OrderService.Infra.Data.Mapper;

public class ProductMap : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(prop => prop.id)
            .HasColumnName("Id")
            .IsRequired();

        builder.Property(prop => prop.title)
            .HasColumnType("varchar(50)")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(prop => prop.image)
            .IsRequired();

        builder.Property(prop => prop.description)
            .IsRequired();

        builder.Property(prop => prop.category)
            .IsRequired();

        builder.Property(prop => prop.quantity)
             .IsRequired();

        builder.Property(prop => prop.price)
            .HasPrecision(18,2)
            .IsRequired();

        builder.Property(prop => prop.created)
            .IsRequired();

        builder.Property(prop => prop.updated)
            .IsRequired();

     }
}
