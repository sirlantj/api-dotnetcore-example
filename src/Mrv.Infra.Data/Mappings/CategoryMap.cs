using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mrv.Domain.Models;

namespace Mrv.Infra.Data.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id")
                .HasColumnType("int")
                .IsRequired(); 

            builder.Property(c => c.Name)
                .HasColumnName("Name")
                .HasColumnType("varchar(100)");

            builder.HasKey(x => x.Id);
        }
    }
}