using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MinicoreCompras.Models;

public partial class MiniCoreComprasContext : DbContext
{
    public MiniCoreComprasContext()
    {
    }

    public MiniCoreComprasContext(DbContextOptions<MiniCoreComprasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Contrato> Contratos { get; set; }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__clientes__885457EE3102FCF7");

            entity.ToTable("clientes");

            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.NombreCliente)
                .HasMaxLength(500)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Contrato>(entity =>
        {
            entity.HasKey(e => e.IdContrato).HasName("PK__Contrato__91431FE1C0001ED1");

            entity.Property(e => e.IdContrato).HasColumnName("idContrato");
            entity.Property(e => e.Contratos)
                .HasMaxLength(900)
                .IsUnicode(false)
                .HasColumnName("contratos");
            entity.Property(e => e.FechaContrato)
                .HasColumnType("date")
                .HasColumnName("fechaContrato");
            entity.Property(e => e.IdCliente).HasColumnName("idCliente");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Contratos)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PersonOrder");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
