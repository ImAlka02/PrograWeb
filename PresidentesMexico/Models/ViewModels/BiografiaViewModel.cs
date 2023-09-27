namespace PresidentesMexico.Models.ViewModels
{
    public class BiografiaViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string FechaNacimiento { get; set; } = null!;
        public string FechaDefuncionNacimiento { get; set; } = null!;
        public string CiudadNacimiento { get; set; } = null!;
        public string EstadoNacimiento { get; set; } = null!;
        public string Ocupacion { get; set; } = null!;
        public string InicioGobierno { get; set; } = null!;
        public string FinGobierno { get; set; } = null!;
        public string NombrePartido { get; set; } = null!;
        public int IdPartido {get; set; } 
        public string Biografia { get; set; } = null!;

    }
}
