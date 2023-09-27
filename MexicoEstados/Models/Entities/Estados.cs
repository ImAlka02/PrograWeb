using System;
using System.Collections.Generic;

namespace MexicoEstados.Models.Entities;

public partial class Estados
{
    public int Id { get; set; }

    /// <summary>
    /// NOM_ENT - Nombre de la entidad
    /// </summary>
    public string Nombre { get; set; } = null!;

    /// <summary>
    /// NOM_ABR - Nombre abreviado de la entidad
    /// </summary>
    public string Abrev { get; set; } = null!;
}
