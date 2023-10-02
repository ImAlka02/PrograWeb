﻿using System;
using System.Collections.Generic;

namespace Peliculas.Models.Entities;

public partial class Apariciones
{
    public int Id { get; set; }

    public int IdPersonaje { get; set; }

    public int IdPelicula { get; set; }

    public virtual Pelicula IdPeliculaNavigation { get; set; } = null!;

    public virtual Personaje IdPersonajeNavigation { get; set; } = null!;
}
