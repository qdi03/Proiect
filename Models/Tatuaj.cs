using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proiect.Models
{
    public class Tatuaj
    {
        public int ID { get; set; }

        [Display(Name = "Tattoo Name")]
        [Required(ErrorMessage = "Numele tatuajului este obligatoriu!")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "Lungimea numelui trebuie sa fie cuprinsa intre 3 si 150!")]
        public string Name { get; set; }
        public int ArtistID { get; set; }
        public Artist? Artist { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        [Range(0.01, 2000, ErrorMessage = "Pretul trebuie sa fie cuprins intre 0.01 si 2000!")]
        public decimal Price { get; set; }

        [Display(Name = "Durate(ore)")]
        public int Durata { get; set; }

        public int? SalonID { get; set; }
        public Salon? Salon { get; set; }

        public ICollection<Appointment>? Appointments { get; set; }
        public ICollection<TattooCategory>? TattooCategories { get; set; }

    }
}
