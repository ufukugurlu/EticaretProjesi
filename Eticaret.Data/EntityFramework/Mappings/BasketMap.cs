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
    public class BasketMap : IEntityTypeConfiguration<Basket>
    {

        public void Configure(EntityTypeBuilder<Basket> builder)
        {
            builder.HasKey(x => x.Id);
            //builder.Property(a => a.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.ProductId);

            builder.Property(x => x.UserId);

            builder.Property(x => x.Total);

            builder.Property(x => x.ProductName);

            //builder.HasOne<User>(a => a.KEY_UserId).WithMany(a => a.).HasForeignKey(a => a.proje_tip_ID_FK).HasConstraintName("FK_IYSP_proje_tip_ID");

            builder.ToTable("Baskets");

        }
    }
}
