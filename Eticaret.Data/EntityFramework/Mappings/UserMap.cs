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
    public class UserMap : IEntityTypeConfiguration<User>
    {

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Name).HasColumnType("VARCHAR(50)").IsRequired();

            builder.Property(x => x.Surname).HasColumnType("VARCHAR(50)").IsRequired();

            builder.Property(x => x.Password).HasColumnType("VARCHAR(50)").IsRequired();

            builder.Property(x => x.Email).HasColumnType("VARCHAR(50)");

            builder.Property(x => x.IsActive).HasColumnType("Bit");

            builder.ToTable("Users");

            builder.HasData(new User()
                {
                    Id = 1,
                    Name = "Ad 1",
                    Surname = "Soyad 1",
                    Email = "deneme1@gmail.com",
                    Password = "123456",
                    IsActive = true

                },
                new User()
                {
                    Id = 2,
                    Name = "Ad 2",
                    Surname = "Soyad 2",
                    Email = "deneme2@gmail.com",
                    Password = "1234567",
                    IsActive = true

                },
                new User()
                {
                    Id = 3,
                    Name = "Ad 3",
                    Surname = "Soyad 3",
                    Email = "deneme3@gmail.com",
                    Password = "12345678",
                    IsActive = true

                }
            );

        }
    }
}
