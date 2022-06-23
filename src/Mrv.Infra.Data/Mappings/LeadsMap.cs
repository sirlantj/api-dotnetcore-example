using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mrv.Domain.Models;

namespace Mrv.Infra.Data.Mappings
{
    public class LeadsMap : IEntityTypeConfiguration<Leads>
    {
        public void Configure(EntityTypeBuilder<Leads> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(c => c.CategoryId)
                .HasColumnName("CategoryId")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(c => c.ContactId)
                .HasColumnName("ContactId")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(c => c.Suburb)
                .HasColumnName("Suburb")
                .HasColumnType("varchar(100)");

            builder.Property(c => c.Price)
                .HasColumnName("Price")
                .HasColumnType("decimal(10,2)");

            builder.Property(c => c.Status)
                .HasColumnName("Status")
                .HasColumnType("varchar(1)");

            builder.Property(c => c.Description)
                .HasColumnName("Description")
                .HasColumnType("text");

            builder.Property(c => c.DateCreated)
               .HasColumnName("DateCreated")
               .HasColumnType("datetime");

            builder.HasKey(x => x.Id);
        }
    }
}