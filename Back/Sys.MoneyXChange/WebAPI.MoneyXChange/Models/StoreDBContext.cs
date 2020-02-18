using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebAPI.MoneyXChange.Models
{
    public partial class StoreDBContext : DbContext
    {
        public StoreDBContext()
        {
        }

        public StoreDBContext(DbContextOptions<StoreDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Currency> Currency { get; set; }
        public virtual DbSet<CurrencyRate> CurrencyRate { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserAccount> UserAccount { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Currency>(entity =>
            {
                entity.HasKey(e => e.CurId);

                entity.ToTable("CURRENCY");

                entity.Property(e => e.CurId)
                    .HasColumnName("CUR_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CurDescription)
                    .IsRequired()
                    .HasColumnName("CUR_description")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CurIslocal).HasColumnName("CUR_islocal");

                entity.Property(e => e.CurRelation).HasColumnName("CUR_relation");

                entity.Property(e => e.CurSimbol)
                    .IsRequired()
                    .HasColumnName("CUR_simbol")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.CurStatus).HasColumnName("CUR_status");
            });

            modelBuilder.Entity<CurrencyRate>(entity =>
            {
                entity.HasKey(e => e.CrrDateRate);

                entity.ToTable("CURRENCY_RATE");

                entity.Property(e => e.CrrDateRate)
                    .HasColumnName("CRR_dateRate")
                    .HasColumnType("datetime");

                entity.Property(e => e.CrrCurrencyFrom).HasColumnName("CRR_currencyFrom");

                entity.Property(e => e.CrrCurrencyTo).HasColumnName("CRR_currencyTo");

                entity.Property(e => e.CrrExchangeRate).HasColumnName("CRR_exchangeRate");

                entity.HasOne(d => d.CrrCurrencyFromNavigation)
                    .WithMany(p => p.CurrencyRateCrrCurrencyFromNavigation)
                    .HasForeignKey(d => d.CrrCurrencyFrom)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CURRENCY_RATE_CURRENCY_FROM");

                entity.HasOne(d => d.CrrCurrencyToNavigation)
                    .WithMany(p => p.CurrencyRateCrrCurrencyToNavigation)
                    .HasForeignKey(d => d.CrrCurrencyTo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CURRENCY_RATE_CURRENCY_TO");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UspId);

                entity.ToTable("USER");

                entity.Property(e => e.UspId).HasColumnName("USP_id");

                entity.Property(e => e.UspEmail)
                    .IsRequired()
                    .HasColumnName("USP_email")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.UspFirstname)
                    .IsRequired()
                    .HasColumnName("USP_firstname")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UspLastname)
                    .IsRequired()
                    .HasColumnName("USP_lastname")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserAccount>(entity =>
            {
                entity.HasKey(e => e.UspId);

                entity.ToTable("USER_ACCOUNT");

                entity.Property(e => e.UspId)
                    .HasColumnName("USP_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.UsaPassword)
                    .IsRequired()
                    .HasColumnName("USA_password")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.UsaPasswordHash)
                    .HasColumnName("USA_password_hash")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.UsaPasswordSalt)
                    .HasColumnName("USA_password_salt")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.UsaUsername)
                    .IsRequired()
                    .HasColumnName("USA_username")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Usp)
                    .WithOne(p => p.UserAccount)
                    .HasForeignKey<UserAccount>(d => d.UspId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USER_ACCOUNT_USER");
            });
        }
    }
}
