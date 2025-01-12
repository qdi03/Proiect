using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proiect.Data;
using Proiect.Models;

namespace Proiect.Pages.Tatuaje
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : TattooCategoriesPageModel
    {
        private readonly Proiect.Data.ProiectContext _context;

        public CreateModel(Proiect.Data.ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["ArtistID"] = new SelectList(_context.Set<Artist>(), "ID", "Name");
            ViewData["SalonID"] = new SelectList(_context.Set<Salon>(), "ID", "NumeSalon");

            var tatuaj = new Tatuaj();
            tatuaj.TattooCategories = new List<TattooCategory>();
            
            PopulateAssignedCategoryData(_context, tatuaj);
            return Page();
        }

        [BindProperty]
        public Tatuaj Tatuaj { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newTattoo = new Tatuaj();
            if(selectedCategories != null)
            {
                newTattoo.TattooCategories = new List<TattooCategory>();
                foreach(var cat in selectedCategories)
                {
                    var catToadd = new TattooCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newTattoo.TattooCategories.Add(catToadd);   
                }
            }

            Tatuaj.TattooCategories = newTattoo.TattooCategories;
            _context.Tatuaj.Add(Tatuaj);
                await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
