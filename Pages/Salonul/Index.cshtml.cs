using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect.Data;
using Proiect.Models;
using Proiect.Models.ViewModels;

namespace Proiect.Pages.Salonul
{
    public class IndexModel : PageModel
    {
        private readonly Proiect.Data.ProiectContext _context;

        public IndexModel(Proiect.Data.ProiectContext context)
        {
            _context = context;
        }

        public IList<Salon> Salon { get;set; } = default!;
        
        public SalonIndexData SalonData { get; set; }
        public int SalonID { get; set; }
        public int TatuajID { get; set; }

        public async Task OnGetAsync(int? id, int? TatuajID)
        {
            SalonData = new SalonIndexData();
            SalonData.Saloane = await _context.Salon
            .Include(i => i.Tatuaje)
            .ThenInclude(c => c.Artist)
            .OrderBy(i => i.NumeSalon)
            .ToListAsync();
            if (id != null)
            {
                SalonID = id.Value;
                Salon salon = SalonData.Saloane
                .Where(i => i.ID == id.Value).Single();
                SalonData.Tatuaje = salon.Tatuaje;
            }
        }
    }
}
