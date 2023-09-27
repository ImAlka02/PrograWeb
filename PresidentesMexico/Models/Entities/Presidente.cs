using System;
using System.Collections.Generic;

namespace PresidentesMexico.Models.Entitis;

public partial class Presidente
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public DateOnly? FechaNacimiento { get; set; }

    public DateOnly? FechaFallecimiento { get; set; }

    public string? CiudadNacimiento { get; set; }

    public int? IdEstadoRepublica { get; set; }

    public string? Ocupacion { get; set; }

    public DateOnly InicioGobierno { get; set; }

    public DateOnly? TerminoGobierno { get; set; }

    public int IdPartidoPolitico { get; set; }

    public string Biografia { get; set; } = null!;

    public virtual Estadorepublica? IdEstadoRepublicaNavigation { get; set; }

    public virtual Partidopolitico IdPartidoPoliticoNavigation { get; set; } = null!;
}
