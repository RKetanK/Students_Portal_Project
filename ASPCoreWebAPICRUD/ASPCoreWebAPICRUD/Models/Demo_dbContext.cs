using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ASPCoreWebAPICRUD.Models
{
    public partial class Demo_dbContext : DbContext
    {
        public Demo_dbContext()
        {
        }

        public Demo_dbContext(DbContextOptions<Demo_dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<StudentsTable> StudentsTables { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning      
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentsTable>(entity =>
            {
                entity.HasKey(e => e.StudentId);

                entity.ToTable("Students_table");

                entity.Property(e => e.StudentId).ValueGeneratedNever();

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
