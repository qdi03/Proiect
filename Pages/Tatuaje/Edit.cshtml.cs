using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect.Data;
using Proiect.Models;

namespace Proiect.Pages.Tatuaje
{
    [Authorize(Roles = "Admin")]
    public class EditModel : TattooCategoriesPageModel
    {
        private readonly Proiect.Data.ProiectContext _context;

        public EditModel(Proiect.Data.ProiectContext context)
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

            Tatuaj = await _context.Tatuaj
                    .Include(b => b.Artist)
                    .Include(b => b.Salon)
                    .Include(b => b.TattooCategories).ThenInclude(b => b.Category)
                    .AsNoTracking().FirstOrDefaultAsync(m => m.ID == id);

            var tatuaj = await _context.Tatuaj.FirstOrDefaultAsync(m => m.ID == id);
            if (Tatuaj == null)
            {
                return NotFound();
            }
            PopulateAssignedCategoryData(_context, Tatuaj);
            Tatuaj = tatuaj;
            ViewData["ArtistID"] = new SelectList(_context.Set<Artist>(), "ID", "Name");
            ViewData["SalonID"] = new SelectList(_context.Set<Salon>(), "ID", "NumeSalon");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            var tattooToUpdate = await _context.Tatuaj
                                .Include(i => i.Artist)
                                .Include(i => i.Salon)
                                .Include(i => i.TattooCategories)
                                    .ThenInclude(i => i.Category)
                                .FirstOrDefaultAsync(s => s.ID == id);
            if (tattooToUpdate == null)
            {
                return NotFound();
            }

            if(await TryUpdateModelAsync<Tatuaj>(
                tattooToUpdate,
                "Tatuaj",
                i => i.Name, i => i.ArtistID, i => i.Price, i => i.Durata, i => i.SalonID))
            {
                UpdateTattooCategories(_context, selectedCategories, tattooToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            UpdateTattooCategories(_context, selectedCategories, tattooToUpdate);
            PopulateAssignedCategoryData(_context, tattooToUpdate);
            return Page();
        }
    }
}
