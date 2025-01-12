using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect.Data;
using Proiect.Models;

namespace Proiect.Pages.Tatuaje
{
    [Authorize(Roles = "Admin")]
    public class DeleteModel : PageModel
    {
        private readonly Proiect.Data.ProiectContext _context;

        public DeleteModel(Proiect.Data.ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Tatuaj Tatuaj { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tatuaj = await _context.Tatuaj.FirstOrDefaultAsync(m => m.ID == id);

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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tatuaj = await _context.Tatuaj.FindAsync(id);
            if (tatuaj != null)
            {
                Tatuaj = tatuaj;
                _context.Tatuaj.Remove(Tatuaj);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
