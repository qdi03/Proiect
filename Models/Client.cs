using System.ComponentModel.DataAnnotations;

namespace Proiect.Models
{
    public class Client
    {
        public int ID { get; set; }

        [RegularExpression(@"^[A-Z]+[a-z\s]*$", ErrorMessage = "Prenumele trebuie sa inceapa cu majuscula (ex. Adi sau Adi Matei sau Adi-Matei)")]
        [StringLength(30, MinimumLength = 3)]
        public string? FirstName { get; set; }

        [RegularExpression(@"^[A-Z]+[a-z\s]*$", ErrorMessage = "Numele de familie trebuie sa inceapa cu majuscula (ex. Pop sau Pop-Mihailescu)")]
        [StringLength(30, MinimumLength = 3)]
        public string? LastName { get; set; }
        public string Email { get; set; }


        [RegularExpression(@"^0([0-9]{3})[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Telefonul trebuie să fie de forma '0722-123-123', '0722.123.123' sau '0722 123 123' și să înceapă cu 0.")]
        public string? Phone { get; set; }

        [Display(Name = "Full Name")]
        public string? FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        public ICollection<Appointment>? Appointments { get; set; }
    }
}

