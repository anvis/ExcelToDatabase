using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataLayer.Models
{
    public partial class ScreenerContext : DbContext
    {
        public ScreenerContext()
        {
        }

        public ScreenerContext(DbContextOptions<ScreenerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Fundamanetals> Fundamanetals { get; set; }
        public virtual DbSet<Stock> Stock { get; set; }
        public virtual DbSet<StockOwnerShip> StockOwnerShip { get; set; }
        public virtual DbSet<Temp> Temp { get; set; }
        public virtual DbSet<Temp2> Temp2 { get; set; }
        public virtual DbSet<Transactions> Transactions { get; set; }
        public virtual DbSet<WatchListStocks> WatchListStocks { get; set; }
        public virtual DbSet<Watchlist> Watchlist { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=IN1-1024735LT\\ANVISERVER;Database=Screener;User ID=sa;Password=Anvi@4545");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fundamanetals>(entity =>
            {
                entity.Property(e => e.Ebit).HasColumnName("EBIT");

                entity.Property(e => e.Eps).HasColumnName("EPS");

                entity.Property(e => e.Pbv).HasColumnName("PBV");

                entity.Property(e => e.Peg).HasColumnName("PEG");

                entity.Property(e => e.Peratio).HasColumnName("PERatio");

                entity.Property(e => e.Roa).HasColumnName("ROA");

                entity.Property(e => e.Roce).HasColumnName("ROCE");

                entity.Property(e => e.Roi).HasColumnName("ROI");

                entity.HasOne(d => d.Stock)
                    .WithMany(p => p.Fundamanetals)
                    .HasForeignKey(d => d.StockId)
                    .HasConstraintName("FK_Fundamanetals_Stock");
            });

            modelBuilder.Entity<Stock>(entity =>
            {
                entity.Property(e => e.Mcap).HasColumnName("MCap");

                entity.Property(e => e.McapCategory).HasMaxLength(50);

                entity.Property(e => e.Sector)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.StockName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<StockOwnerShip>(entity =>
            {
                entity.Property(e => e.Diiholdings).HasColumnName("DIIHoldings");

                entity.Property(e => e.Fiiholdings).HasColumnName("FIIHoldings");

                entity.Property(e => e.SixMnthsDiiholdings).HasColumnName("SixMnthsDIIHoldings");

                entity.Property(e => e.SixMnthsFiiholdings).HasColumnName("SixMnthsFIIHoldings");

                entity.Property(e => e.ThreeMnthsDiiholdings).HasColumnName("ThreeMnthsDIIHoldings");

                entity.Property(e => e.ThreeMnthsFiiholdings).HasColumnName("ThreeMnthsFIIHoldings");

                entity.HasOne(d => d.Stock)
                    .WithMany(p => p.StockOwnerShip)
                    .HasForeignKey(d => d.StockId)
                    .HasConstraintName("FK_StockOwnerShip_StockOwnerShip");
            });

            modelBuilder.Entity<Temp>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("temp");

                entity.Property(e => e.Re)
                    .HasColumnName("re")
                    .HasMaxLength(50);

                entity.Property(e => e.Ty)
                    .HasColumnName("ty")
                    .HasMaxLength(50);

                entity.Property(e => e.We)
                    .HasColumnName("we")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Temp2>(entity =>
            {
                entity.ToTable("temp2");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Re)
                    .HasColumnName("re")
                    .HasMaxLength(50);

                entity.Property(e => e.Ty)
                    .HasColumnName("ty")
                    .HasMaxLength(50);

                entity.Property(e => e.We)
                    .HasColumnName("we")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Transactions>(entity =>
            {
                entity.Property(e => e.TransactionType)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.Stock)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.StockId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transactions_Stock");
            });

            modelBuilder.Entity<WatchListStocks>(entity =>
            {
                entity.HasOne(d => d.Stock)
                    .WithMany(p => p.WatchListStocks)
                    .HasForeignKey(d => d.StockId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WatchListStocks_Stock");

                entity.HasOne(d => d.Transaction)
                    .WithMany(p => p.WatchListStocks)
                    .HasForeignKey(d => d.TransactionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WatchListStocks_Transactions");

                entity.HasOne(d => d.WatchList)
                    .WithMany(p => p.WatchListStocks)
                    .HasForeignKey(d => d.WatchListId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WatchListStocks_WatchListStocks");
            });

            modelBuilder.Entity<Watchlist>(entity =>
            {
                entity.Property(e => e.WatchListName).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
