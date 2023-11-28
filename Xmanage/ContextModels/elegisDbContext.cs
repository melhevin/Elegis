using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Xmanage.ContextModels
{
    public partial class elegisDbContext : DbContext
    {
        public elegisDbContext()
        {
        }

        public elegisDbContext(DbContextOptions<elegisDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Chat> Chat { get; set; }
        public virtual DbSet<CheckList> CheckList { get; set; }
        public virtual DbSet<Document> Document { get; set; }
        public virtual DbSet<Labour> Labour { get; set; }
        public virtual DbSet<Priority> Priority { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Workers> Workers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=Elegis;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chat>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DateCreate).HasColumnType("datetime");

                entity.HasOne(d => d.IdLabourNavigation)
                    .WithMany(p => p.Chat)
                    .HasForeignKey(d => d.IdLabour)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Chat_Labour");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Chat)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK_Chat_Users");
            });

            modelBuilder.Entity<CheckList>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DateCreate).HasColumnType("datetime");

                entity.Property(e => e.DateDeadline).HasColumnType("datetime");

                entity.Property(e => e.DateSolved).HasColumnType("datetime");

                entity.Property(e => e.Describe).IsRequired();

                entity.HasOne(d => d.IdLabourNavigation)
                    .WithMany(p => p.CheckList)
                    .HasForeignKey(d => d.IdLabour)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CheckList_Labour1");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.CheckList)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CheckList_Users1");
            });

            modelBuilder.Entity<Document>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Doc).IsRequired();

                entity.HasOne(d => d.IdLabourNavigation)
                    .WithMany(p => p.Document)
                    .HasForeignKey(d => d.IdLabour)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Document_Labour1");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Document)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK_Document_Users1");
            });

            modelBuilder.Entity<Labour>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Company)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DateCreate).HasColumnType("datetime");

                entity.Property(e => e.DateDeadline).HasColumnType("datetime");

                entity.Property(e => e.DateSolved).HasColumnType("datetime");

                entity.Property(e => e.Describe).IsRequired();

                entity.HasOne(d => d.IdPriorityNavigation)
                    .WithMany(p => p.Labour)
                    .HasForeignKey(d => d.IdPriority)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Labour_Priority1");

                entity.HasOne(d => d.IdStatusNavigation)
                    .WithMany(p => p.Labour)
                    .HasForeignKey(d => d.IdStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Labour_Status1");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Labour)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Labour_Users");
            });

            modelBuilder.Entity<Priority>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Describe)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Describe)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NameSurname)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Workers>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.IdLabourNavigation)
                    .WithMany(p => p.Workers)
                    .HasForeignKey(d => d.IdLabour)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Workers_Labour");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Workers)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Workers_Users");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
