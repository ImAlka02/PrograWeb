namespace Peliculas.Models.ViewModel
{
    public class IndexCortosViewModel
    {
        public string Categoria { get; set; } = null!;
        public IEnumerable<CortoModel> Cortos { get; set; } = null!;
     }
    
    public class CortoModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
    }
}
