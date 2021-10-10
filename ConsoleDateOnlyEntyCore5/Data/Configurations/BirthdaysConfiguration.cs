using DateOnlyEFCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

#nullable disable

namespace DateOnlyEFCore.Data.Configurations
{
    public class BirthdaysConfiguration : IEntityTypeConfiguration<Birthdays>
    {
        public void Configure(EntityTypeBuilder<Birthdays> entity)
        {
            entity.Property(e => e.BirthDate).HasColumnType("date");
        }
    }
}
