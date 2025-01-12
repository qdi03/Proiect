using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace Proiect.Models
{
    public class Appointment
    {
        public int ID { get; set; }
        public int? ClientID { get; set; }
        public Client? Client { get; set; }
        public int? TatuajID { get; set; }
        public Tatuaj? Tatuaj { get; set; }

        [DataType(DataType.Date)]
        public DateTime AppointmentDate { get; set; }

        [DataType(DataType.Time)]
        public TimeSpan AppointmentTime { get; set; }
    }
}
