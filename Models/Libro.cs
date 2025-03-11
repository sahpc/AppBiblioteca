using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AppBiblioteca.Models;

[Index("Isbn", Name = "UQ__Libros__99F9D0A487FE53E6", IsUnique = true)]
public partial class Libro
{
    [Key]
    [Column("libro_id")]
    public int LibroId { get; set; }

    [Column("titulo")]
    [StringLength(255)]
    public string Titulo { get; set; } = null!;

    [Column("genero")]
    [StringLength(100)]
    public string? Genero { get; set; }

    [Column("fecha_publicacion")]
    public DateOnly? FechaPublicacion { get; set; }

    [Column("isbn")]
    [StringLength(20)]
    public string? Isbn { get; set; }

    [ForeignKey("LibroId")]
    [InverseProperty("Libros")]
    public virtual ICollection<Autore> Autors { get; set; } = new List<Autore>();
}
