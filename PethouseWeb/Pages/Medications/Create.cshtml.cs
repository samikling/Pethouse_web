#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PethouseWeb.Models;

namespace PethouseWeb.Pages.Medications
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
        ViewData["PetId"] = new SelectList(_context.Pets, "PetId", "PetId");
            return Page();
        }

        [BindProperty]
        public Medication Medication { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Medications.Add(Medication);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
