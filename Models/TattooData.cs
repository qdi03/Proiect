namespace Proiect.Models
{
    public class TattooData
    {
        public IEnumerable<Tatuaj> Tatuaje { get; set; }
        public IEnumerable<Category> Categories { get; set; }   
        public IEnumerable<TattooCategory> TattooCategories { get; set; }
    }
}
