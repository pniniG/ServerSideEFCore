using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace EFCoreDal.Models
{
    public partial class myDBContext : DbContext
    {
        public myDBContext()
        {
        }

        public myDBContext(DbContextOptions<myDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblCategory> TblCategories { get; set; }
        public virtual DbSet<TblContact> TblContacts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server= .\\sqlexpress;Database =myDB;Trusted_Connection =True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Hebrew_CI_AS");

            modelBuilder.Entity<TblCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                    .HasName("PK__tbl_cate__19093A0B114C4049");

                entity.ToTable("tbl_categories");

                entity.Property(e => e.CategoryId).ValueGeneratedNever();

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(25);
            });

            modelBuilder.Entity<TblContact>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("PK__tbl_cont__737584F7814B5ADC");

                entity.ToTable("tbl_contacts");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.MailAdress)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.PhoneNumber).HasMaxLength(50);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.TblContacts)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_[tbl_contacts]_[tbl_categories]");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
