using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.DAL.Entities;

namespace Talabat.DAL.Data.Configrations
{
    public class ProductConfigration : IEntityTypeConfiguration<Product>
    {

        public void Configure(EntityTypeBuilder<Product> builder)
        {

            builder.Property(P=>P.Name).IsRequired().HasMaxLength(100);
            builder.Property(P=>P.Description).IsRequired();
            builder.Property(p => p.Price).HasColumnType("decimal(18,20");
            builder.Property(P=>P.PictureUrl).IsRequired();
        }
    }
}
