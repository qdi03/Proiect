using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Proiect.Data;
using Proiect.Models;

namespace Proiect.Pages.Tatuaje
{
    public class IndexModel : PageModel
    {
        private readonly Proiect.Data.ProiectContext _context;

        public IndexModel(Proiect.Data.ProiectContext context)
        {
            _context = context;
        }

        public IList<Tatuaj> Tatuaj { get; set; } = default!;
        public TattooData TattooD { get; set; }
        public int TatuajID { get; set; }
        public int CategoryID { get; set; }

        public string NameSort { get; set; }
        public string ArtistSort { get; set; }

        public string CurrentFilter { get; set; }

        public async Task OnGetAsync(int? id, int? categoryID, string sortOrder, string searchString)
        {
            TattooD = new TattooData();
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ArtistSort = sortOrder == "artist" ? "artist_desc" : "artist";

            CurrentFilter = searchString;

            TattooD.Tatuaje = await _context.Tatuaj
                              .Include(b => b.Artist)
                              .Include(b => b.Salon)
                              .Include(b => b.TattooCategories)
                              .ThenInclude(b => b.Category)
                              .AsNoTracking()
                              .OrderBy(b => b.Name)
                              .ToListAsync();

            if (!String.IsNullOrEmpty(searchString))
            {
                TattooD.Tatuaje = TattooD.Tatuaje.Where(s => s.Artist.Name.Contains(searchString)
               || s.Name.Contains(searchString));
            }
                if (id != null)
            {
                TatuajID = id.Value;
                Tatuaj tatuaj = TattooD.Tatuaje.Where(i => i.ID == id.Value).Single();
                TattooD.Categories = tatuaj.TattooCategories.Select(s => s.Category);
            }

            switch (sortOrder)
            {
                case "name_desc":
                    TattooD.Tatuaje = TattooD.Tatuaje.OrderByDescending(s => s.Name);
                    break;
                case "artist_desc":
                    TattooD.Tatuaje = TattooD.Tatuaje.OrderByDescending(s => s.Artist.Name);
                    break;
                case "artist":
                    TattooD.Tatuaje = TattooD.Tatuaje.OrderBy(s => s.Artist.Name);
                    break;
                default:
                    TattooD.Tatuaje = TattooD.Tatuaje.OrderBy(s => s.Name);
                    break;
            }
        }
    }
}
