using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderService.Domain.Models;

namespace OrderService.Infra.Data.Mapper;

public class OrderMap : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.Property(prop => prop.id)
            .HasColumnName("Id")
            .IsRequired();

        builder.Property(prop => prop.userId)
            .IsRequired();

        builder.Property(prop => prop.status)
            .IsRequired();


        builder.Property(prop => prop.totalPrice)
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(prop => prop.createdDate)
            .IsRequired();

        builder.HasOne(prop => prop.user)
            .WithMany()
            .HasForeignKey(prop => prop.userId);

    }
}