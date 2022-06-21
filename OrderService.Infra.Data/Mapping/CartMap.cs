using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderService.Domain.Models;

namespace OrderService.Infra.Data.Mapper;

public class CartMap : IEntityTypeConfiguration<Cart> 
{
    public void Configure(EntityTypeBuilder<Cart> builder)
    {
        builder.Property(prop => prop.id)
            .HasColumnName("Id")
            .IsRequired();
               
        builder.Property(prop => prop.quantity)
            .IsRequired();

        builder.Property(prop => prop.price)
            .IsRequired();

        builder.Property(prop => prop.title)
            .IsRequired();

        builder.Property(prop => prop.image)
            .IsRequired();

    }
}
