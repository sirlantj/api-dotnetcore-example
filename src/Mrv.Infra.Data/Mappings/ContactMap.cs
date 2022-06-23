using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mrv.Domain.Models;

namespace Mrv.Infra.Data.Mappings
{
    public class ContactMap : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(c => c.Name)
                .HasColumnName("Name")
                .HasColumnType("varchar(50)");

            builder.Property(c => c.LastName)
                .HasColumnName("LastName")
                .HasColumnType("varchar(50)");

            builder.Property(c => c.Email)
                .HasColumnName("Email")
                .HasColumnType("varchar(100)");

            builder.Property(c => c.Phone)
               .HasColumnName("Phone")
               .HasColumnType("varchar(15)");

            builder.HasKey(x => x.Id);
        }
    }
}