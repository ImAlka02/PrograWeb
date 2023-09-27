namespace PresidentesMexico.Models.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<PresidenteModel> Presidentes { get; set; } = null!;
    }

    public class PresidenteModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Periodo { get; set; } = null!;
    }
}
