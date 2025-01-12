namespace Proiect.Models
{
    public class TattooCategory
    {
        public int ID { get; set; }
        public int TatuajID { get; set; }
        public Tatuaj Tatuaj { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
