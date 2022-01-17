using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PethouseWeb.Models
{
    public partial class pethouseContext : DbContext
    {
        public pethouseContext()
        {
        }

        public pethouseContext(DbContextOptions<pethouseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Breed> Breeds { get; set; } = null!;
        public virtual DbSet<Grooming> Groomings { get; set; } = null!;
        public virtual DbSet<Medication> Medications { get; set; } = null!;
        public virtual DbSet<Pet> Pets { get; set; } = null!;
        public virtual DbSet<Race> Races { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Vaccine> Vaccines { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-DPPJVHA\\SQLEXPRESS;Database=pethouse;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Breed>(entity =>
            {
                entity.Property(e => e.BreedId).HasColumnName("Breed_id");

                entity.Property(e => e.Breedname)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RaceId).HasColumnName("Race_id");

                entity.HasOne(d => d.Race)
                    .WithMany(p => p.Breeds)
                    .HasForeignKey(d => d.RaceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Breeds__Race_id__286302EC");
            });

            modelBuilder.Entity<Grooming>(entity =>
            {
                //entity.HasNoKey();

                entity.ToTable("Grooming");

                entity.Property(e => e.Comments)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.GroomDate).HasColumnType("date");

                entity.Property(e => e.GroomExpDate).HasColumnType("date");

                entity.Property(e => e.Groomname)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PetId).HasColumnName("Pet_id");

                entity.HasOne(d => d.Pet)
                    .WithMany()
                    .HasForeignKey(d => d.PetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Grooming__Pet_id__32E0915F");
            });

            modelBuilder.Entity<Medication>(entity =>
            {
                //entity.HasNoKey();

                entity.Property(e => e.MedDate).HasColumnType("date");

                entity.Property(e => e.MedExpDate).HasColumnType("date");

                entity.Property(e => e.Medname)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PetId).HasColumnName("Pet_id");

                entity.HasOne(d => d.Pet)
                    .WithMany()
                    .HasForeignKey(d => d.PetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Medicatio__Pet_i__30F848ED");
            });

            modelBuilder.Entity<Pet>(entity =>
            {
                entity.Property(e => e.PetId).HasColumnName("Pet_id");

                entity.Property(e => e.Birthdate).HasColumnType("date");

                entity.Property(e => e.BreedId).HasColumnName("Breed_id");

                entity.Property(e => e.Petname)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Photo)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.RaceId).HasColumnName("Race_id");

                entity.Property(e => e.UserId).HasColumnName("User_id");

                entity.HasOne(d => d.Breed)
                    .WithMany(p => p.Pets)
                    .HasForeignKey(d => d.BreedId)
                    .HasConstraintName("FK__Pets__Breed_id__2D27B809");

                entity.HasOne(d => d.Race)
                    .WithMany(p => p.Pets)
                    .HasForeignKey(d => d.RaceId)
                    .HasConstraintName("FK__Pets__Race_id__2C3393D0");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Pets)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Pets__User_id__2B3F6F97");
            });

            modelBuilder.Entity<Race>(entity =>
            {
                entity.Property(e => e.RaceId)
                    .ValueGeneratedNever()
                    .HasColumnName("Race_id");

                entity.Property(e => e.Racename)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).HasColumnName("User_id");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Vaccine>(entity =>
            {
                //entity.HasNoKey();

                entity.Property(e => e.PetId).HasColumnName("Pet_id");

                entity.Property(e => e.VacDate).HasColumnType("date");

                entity.Property(e => e.VacExpDate).HasColumnType("date");

                entity.Property(e => e.Vacname)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Pet)
                    .WithMany()
                    .HasForeignKey(d => d.PetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Vaccines__Pet_id__2F10007B");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
