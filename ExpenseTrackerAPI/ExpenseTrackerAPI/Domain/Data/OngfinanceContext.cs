using System;
using System.Collections.Generic;
using ExpenseTrackerAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackerAPI.Domain.Data;

public partial class OngfinanceContext : DbContext
{
    public OngfinanceContext()
    {
    }

    public OngfinanceContext(DbContextOptions<OngfinanceContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Transaction> Transactions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3306;database=ongfinance;uid=usr_rafiusk;pwd=rafa05", ServerVersion.Parse("8.0.12-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.IdTransaction).HasName("PRIMARY");

            entity.ToTable("transactions");

            entity.Property(e => e.IdTransaction)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("idTransaction");
            entity.Property(e => e.Amount)
                .HasPrecision(5, 2)
                .HasColumnName("amount");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.Description)
                .HasMaxLength(45)
                .HasColumnName("description");
            entity.Property(e => e.Type)
                .HasColumnType("int(11)")
                .HasColumnName("type");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
