using System;
using System.Collections.Generic;

namespace ServidorASP.Models;

public partial class Articulo
{
    public long Id { get; set; }

    public string Titulo { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string? Tags { get; set; }

    public string Url { get; set; } = null!;

    public string Contenido { get; set; } = null!;

    public DateTime? FechaHoraCreacion { get; set; }

    public int? Visitas { get; set; }

    public int? Likes { get; set; }

    public int? Compartidos { get; set; }

    public double Prioridad { get; set; }

    public string? Image { get; set; }

    public string? DescripcionImagen { get; set; }

    public long? EstadoId { get; set; }

    public virtual ICollection<ArticuloAutor> ArticuloAutors { get; set; } = new List<ArticuloAutor>();

    public virtual ICollection<ArticuloCategoria> ArticuloCategoria { get; set; } = new List<ArticuloCategoria>();

    public virtual EstadoArticulo? Estado { get; set; }

    public string RealUrl()
    {
        // Usa la lógica necesaria para slugificar la URL, aquí estoy asumiendo que ya tienes una función para eso
        string slugifiedUrl = Slugify(Url);

        // Combina la URL slugificada y el ID en la cadena de la URL
        return $"/articulos/{slugifiedUrl}/{Id}";
    }

    // Función para slugificar la URL
    private string Slugify(string input)
    {
        return input.Replace(" ", "-").ToLower();
    }

    public int CalcularTiempoLectura()
    {
        int velocidad_lectura_wpm = 200;
        int palabras_artiruclo = Contenido.Split().Length;
        double tiempo_estimado = (double)palabras_artiruclo / velocidad_lectura_wpm;
        return (int)Math.Round(tiempo_estimado);
    }
}
