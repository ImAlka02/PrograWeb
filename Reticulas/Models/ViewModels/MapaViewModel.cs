using Reticulas.Models.Entities;

namespace Reticulas.Models.ViewModels
{
    public class MapaViewModel
    {
        public string NombreCarrera { get; set; } = null!;
        public string Plan { get; set; } = null!;
        public int Creditos { get; set; }
        public IEnumerable<SemestreModel> Semestre { get; set; }

    }

    public class SemestreModel
    {
        public int NumSemestre { get; set; } 
        public IEnumerable<MateriaModel> Materias { get; set; }
    }

    public class MateriaModel
    {
        public string Clave { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Creditos { get; set; } = null!;
    }

}
