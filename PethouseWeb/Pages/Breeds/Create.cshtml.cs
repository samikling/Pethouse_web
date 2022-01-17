#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PethouseWeb.Models;

namespace PethouseWeb.Pages.Breeds
{
    public class CreateModel : PageModel
    {
        private readonly PethouseWeb.Models.pethouseContext _context;

        public CreateModel(PethouseWeb.Models.pethouseContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["RaceId"] = new SelectList(_context.Races, "RaceId", "RaceId");
            return Page();
        }

        [BindProperty]
        public Breed Breed { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Breeds.Add(Breed);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
