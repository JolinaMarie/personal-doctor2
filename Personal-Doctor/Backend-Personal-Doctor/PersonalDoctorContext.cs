using System;
using System.Collections.Generic;
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

    public virtual DbSet<EfSession> Sessions { get; set; }

    public virtual DbSet<EfUser> Users { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EfSession>(entity =>
        {
            entity.HasKey(e => e.SessionId).HasName("PK__Sessions__C9F4927073A24E93");

            entity.Property(e => e.SessionId).HasColumnName("SessionID");
            entity.Property(e => e.Expiry).HasColumnType("date");
            entity.Property(e => e.SessionKey)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserId).HasColumnName("UserID");
        });

        modelBuilder.Entity<EfUser>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__tmp_ms_x__1788CC4CC9209A6D");

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Firstname)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Lastname)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Passwort)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
