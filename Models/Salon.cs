using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace Proiect.Models
{
    public class Salon
    {
        public int ID { get; set; }

        [Display(Name = "Nume Salon")]
        public string NumeSalon {  get; set; }
        public ICollection<Tatuaj>? Tatuaje { get; set; }
    }
}
