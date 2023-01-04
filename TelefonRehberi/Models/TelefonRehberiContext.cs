using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TelefonRehberi.Models;

public partial class TelefonRehberiContext : DbContext
{
    public TelefonRehberiContext()
    {
    }

    public TelefonRehberiContext(DbContextOptions<TelefonRehberiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Kisiler> Kisilers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=TelefonRehberi;Trusted_Connection=True;Encrypt=false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Kisiler>(entity =>
        {
            entity.HasKey(e => e.KisilerId).HasName("PK__Kisiler__196CC58B2494CC9B");

            entity.ToTable("Kisiler");

            entity.Property(e => e.KisiAdi).HasMaxLength(30);
            entity.Property(e => e.KisiSoyadi).HasMaxLength(30);
            entity.Property(e => e.TelefonNo)
                .HasMaxLength(11)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
