using System.Security.Policy;

namespace Proiect.Models.ViewModels
{
    public class SalonIndexData
    {
        public IEnumerable<Salon> Saloane { get; set; }
        public IEnumerable<Tatuaj> Tatuaje { get; set; }
    }
}
