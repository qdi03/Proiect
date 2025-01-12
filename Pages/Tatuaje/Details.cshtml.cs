using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect.Data;
using Proiect.Models;

namespace Proiect.Pages.Tatuaje
{
    public class DetailsModel : PageModel
    {
        private readonly Proiect.Data.ProiectContext _context;

        public DetailsModel(Proiect.Data.ProiectContext context)
        {
            _context = context;
        }

        public Tatuaj Tatuaj { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tatuaj = await _context.Tatuaj
                .Include(b => b.Artist)
                .Include(b => b.TattooCategories)
                    .ThenInclude(b => b.Category)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tatuaj == null)
            {
                return NotFound();
            }
            else
            {
                Tatuaj = tatuaj;
            }
            return Page();
        }
    }
}
