using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using My_API.Models;

namespace My_API.Connection;

public partial class ApplicationDBContext : DbContext
{
    public ApplicationDBContext()
    {
    }

    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
    {
    }

    public virtual DbSet<HistorySignIn> HistorySignIns { get; set; }

    public virtual DbSet<MasterEmployee> MasterEmployees { get; set; }

    public virtual DbSet<MasterMenu> MasterMenus { get; set; }

    public virtual DbSet<MasterPesanan> MasterPesanans { get; set; }

    public virtual DbSet<MasterTransaksi> MasterTransaksis { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //=>optionsBuilder.UseSqlServer("Server=RESHAPROGRAMMER; Database=DB_Inspirotechs; User Id=sa; Password=P@ssw0rd; Trusted_Connection=True; TrustServerCertificate=True; MultipleActiveResultSets=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<HistorySignIn>(entity =>
        {
            entity.ToTable("HistorySignIn");

            entity.Property(e => e.LastLogged).HasColumnType("datetime");
            entity.Property(e => e.Nik).HasColumnName("NIK");
        });

        modelBuilder.Entity<MasterEmployee>(entity =>
        {
            entity.HasKey(e => e.Nik);

            entity.ToTable("MasterEmployee");

            entity.Property(e => e.Nik)
                .ValueGeneratedNever()
                .HasColumnName("NIK");
            entity.Property(e => e.AlamatDomisili)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.AlamatLengkap)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Email1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Email_1");
            entity.Property(e => e.Email2)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Email_2");
            entity.Property(e => e.HakAkses)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.Jabatan)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.JenisKelamin)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.NamaLengkap)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NamaPanggilan)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NomerTelepon)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.PasswordLogin)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.TanggalLahir).HasColumnType("date");
            entity.Property(e => e.TempatLahir)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UsernameLogin)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MasterMenu>(entity =>
        {
            entity.HasKey(e => e.KodeMenu);

            entity.ToTable("MasterMenu");

            entity.Property(e => e.KodeMenu)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.HargaSatuan).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.JenisMenu)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NamaMenu)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MasterPesanan>(entity =>
        {
            entity.HasKey(e => e.KodePemesanan);

            entity.ToTable("MasterPesanan");

            entity.Property(e => e.KodePemesanan)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.HargaSatuan).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.KodeMenu)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NamaMenu)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NamaPemesan)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.KodeMenuNavigation).WithMany(p => p.MasterPesanans)
                .HasForeignKey(d => d.KodeMenu)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MasterPesanan_MasterMenu");
        });

        modelBuilder.Entity<MasterTransaksi>(entity =>
        {
            entity.HasKey(e => e.KodeTransaksi);

            entity.ToTable("MasterTransaksi");

            entity.Property(e => e.KodeTransaksi)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.KodeMenu)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.KodePemesanan)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NamaPesanan)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nik).HasColumnName("NIK");
            entity.Property(e => e.TotalPembayaran).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.KodeMenuNavigation).WithMany(p => p.MasterTransaksis)
                .HasForeignKey(d => d.KodeMenu)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MasterTransaksi_MasterMenu");

            entity.HasOne(d => d.KodePemesananNavigation).WithMany(p => p.MasterTransaksis)
                .HasForeignKey(d => d.KodePemesanan)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MasterTransaksi_MasterPesanan");

            entity.HasOne(d => d.NikNavigation).WithMany(p => p.MasterTransaksis)
                .HasForeignKey(d => d.Nik)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MasterTransaksi_MasterEmployee");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
