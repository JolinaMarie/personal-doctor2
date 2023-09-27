using System;
using System.Collections.Generic;
using Backend_Personal_Doctor.Models.Naehrwerte.DTOs;
using Backend_Personal_Doctor.Models.Sessions.DTOs;
using Backend_Personal_Doctor.Models.Users.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Backend_Personal_Doctor;

public partial class PersonalDoctorContext : DbContext
{
    public PersonalDoctorContext()
    {
    }

    public PersonalDoctorContext(DbContextOptions<PersonalDoctorContext> options)
        : base(options)
    {
    }

    public virtual DbSet<EfNaehrwert> Naehrwerte { get; set; }

    public virtual DbSet<EfSession> Sessions { get; set; }

    public virtual DbSet<EfUser> Users { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    => optionsBuilder.UseMySql("server=fs213.sepe21.de;port=3306;database=Projektseminar;user=root;password=geheim", ServerVersion.Parse("8.0.3-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<EfNaehrwert>(entity =>
        {
            entity.HasKey(e => e.NahrungId).HasName("PRIMARY");

            entity.ToTable("Naehrwerte");

            entity.Property(e => e.NahrungId)
                .HasColumnType("int(11)")
                .HasColumnName("NahrungID");
            entity.Property(e => e.Brennwert).HasColumnType("int(255)");
            entity.Property(e => e.Essen).HasMaxLength(50);
            entity.Property(e => e.Fett).HasPrecision(5, 2);
            entity.Property(e => e.Kohlenhydrate).HasPrecision(5, 2);
            entity.Property(e => e.Proteingehalt).HasPrecision(5, 2);
            entity.Property(e => e.Zucker).HasPrecision(5, 2);
        });

        modelBuilder.Entity<EfSession>(entity =>
        {
            entity.HasKey(e => e.SessionId).HasName("PRIMARY");

            entity.Property(e => e.SessionId)
                .HasColumnType("int(11)")
                .HasColumnName("SessionID");
            entity.Property(e => e.Expiry).HasColumnType("datetime");
            entity.Property(e => e.SessionKey).HasMaxLength(50);
            entity.Property(e => e.UserId)
                .HasColumnType("int(11)")
                .HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Session)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fk_UserSessions");
        });

        modelBuilder.Entity<EfUser>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PRIMARY");

            entity.Property(e => e.UserId).HasColumnType("int(11)");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Firstname).HasMaxLength(50);
            entity.Property(e => e.Lastname).HasMaxLength(50);
            entity.Property(e => e.Passwort).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
