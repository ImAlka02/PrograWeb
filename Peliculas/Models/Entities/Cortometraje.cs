﻿using System;
using System.Collections.Generic;

namespace Peliculas.Models.Entities;

public partial class Cortometraje
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public int? IdCategoria { get; set; }

    public virtual Categoria? IdCategoriaNavigation { get; set; }
}
