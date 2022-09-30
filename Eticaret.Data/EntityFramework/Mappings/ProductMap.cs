using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eticaret.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eticaret.Data.EntityFramework.Mappings
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            //primary key
            builder.HasKey(x => x.Id);
            //identity col
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.ProductName).HasColumnType("VARCHAR(50)").IsRequired();

            builder.Property(x => x.Price).IsRequired().HasColumnType("decimal(18,2)");

            builder.ToTable("Products");

            builder.HasData(new Product()
            {
                Id = 1,
                ProductName = "Kurşun Kalem",
                Price = 4,

            },
                new Product()
                {
                    Id = 2,
                    ProductName = "Pilot Kalem",
                    Price = 14,

                }
                );
        }
    }
}
