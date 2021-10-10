using System.Linq;
using DateOnlyEFCore.Data.Configurations;
using DateOnlyEFCore.Models;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DateOnlyEFCore.Data
{
    public partial class Context : DbContext
    {
        public Context() { }
        public Context(DbContextOptions<Context> options) : base(options) { }
        public virtual DbSet<Birthdays> Birthdays { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(BuildConnection());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BirthdaysConfiguration());

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
