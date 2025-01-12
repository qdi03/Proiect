using System.ComponentModel.DataAnnotations;

namespace Proiect.Models
{
    public class Artist
    {
        public int ID { get; set; }

        [Display(Name = "Tattoo Artist")]
        public string Name { get; set; }
        public ICollection<Tatuaj>? Tatuaje { get; set; }
    }
}
