using System;
using FinancialWebApi.Project.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FinancialWebApi.Project.DatabaseContext
{
    public partial class FinancialContext : DbContext
    {
        public FinancialContext()
        {
        }

        public FinancialContext(DbContextOptions<FinancialContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=CASA-PC\\SQLEXPRESS,1433;Initial Catalog=Financial;User ID=sa;Password=10081997w;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasColumnName("CPF")
                    .HasMaxLength(14);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.NomeCompleto)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.TelefoneCelular).HasMaxLength(20);

                entity.Property(e => e.TelefoneFixo).HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
