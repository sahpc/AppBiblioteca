using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AppBiblioteca.Models;

public partial class Autore
{
    [Key]
    [Column("autor_id")]
    public int AutorId { get; set; }

    [Column("nombre")]
    [StringLength(100)]
    public string Nombre { get; set; } = null!;

    [Column("apellido")]
    [StringLength(100)]
    public string Apellido { get; set; } = null!;

    [Column("fecha_nacimiento")]
    public DateOnly? FechaNacimiento { get; set; }

    [Column("nacionalidad")]
    [StringLength(50)]
    public string? Nacionalidad { get; set; }

    [ForeignKey("AutorId")]
    [InverseProperty("Autors")]
    public virtual ICollection<Libro> Libros { get; set; } = new List<Libro>();
}
