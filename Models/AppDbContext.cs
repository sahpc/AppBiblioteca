using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AppBiblioteca.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Autore> Autores { get; set; }

    public virtual DbSet<Libro> Libros { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=Biblioteca;User Id=sa;Password=sa;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Autore>(entity =>
        {
            entity.HasKey(e => e.AutorId).HasName("PK__Autores__80C6EC52D2351708");
        });

        modelBuilder.Entity<Libro>(entity =>
        {
            entity.HasKey(e => e.LibroId).HasName("PK__Libros__5BB6A2FCCA973BA6");

            entity.HasMany(d => d.Autors).WithMany(p => p.Libros)
                .UsingEntity<Dictionary<string, object>>(
                    "LibroAutor",
                    r => r.HasOne<Autore>().WithMany()
                        .HasForeignKey("AutorId")
                        .HasConstraintName("FK__Libro_Aut__autor__164452B1"),
                    l => l.HasOne<Libro>().WithMany()
                        .HasForeignKey("LibroId")
                        .HasConstraintName("FK__Libro_Aut__libro__15502E78"),
                    j =>
                    {
                        j.HasKey("LibroId", "AutorId").HasName("PK__Libro_Au__63BACC39CBE096C6");
                        j.ToTable("Libro_Autor");
                        j.IndexerProperty<int>("LibroId").HasColumnName("libro_id");
                        j.IndexerProperty<int>("AutorId").HasColumnName("autor_id");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
