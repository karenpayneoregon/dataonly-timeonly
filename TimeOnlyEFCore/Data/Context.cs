using System;
using Microsoft.EntityFrameworkCore;
using TimeOnlyEFCore.Models;
using TimeOnlyEFCore.LanguageExtensions;

#nullable disable

namespace TimeOnlyEFCore.Data
{
    public partial class Context : DbContext
    {
        public Context()
        {
        }

        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public virtual DbSet<TimeTable> TimeTable { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(BuildConnection());
            }
        }

        /// <summary>
        /// Note value converters for converting two time(7) properties to TimeOnly
        /// https://docs.microsoft.com/en-us/ef/core/modeling/value-conversions?tabs=data-annotations
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder
                .Entity<TimeTable>()
                .Property(e => e.StartTime)
                .HasConversion(ts => ts.Value.ToTimeSpan(),
                    ts => ts.ToTimeOnly());

            modelBuilder
                .Entity<TimeTable>()
                .Property(e => e.EndTime)
                .HasConversion(ts => ts.Value.ToTimeSpan(),
                    ts => ts.ToTimeOnly());

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}