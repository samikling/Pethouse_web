#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PethouseWeb.Models;

namespace PethouseWeb.Pages.Treatments
{
    public class EditModel : PageModel
    {
        private readonly PethouseWeb.Models.pethouseContext _context;

        public EditModel(PethouseWeb.Models.pethouseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Grooming Grooming { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Grooming = await _context.Groomings
                .Include(g => g.Pet).FirstOrDefaultAsync(m => m.GroomId == id);

            if (Grooming == null)
            {
                return NotFound();
            }
           ViewData["PetId"] = new SelectList(_context.Pets, "PetId", "PetId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Grooming).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroomingExists(Grooming.GroomId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool GroomingExists(int id)
        {
            return _context.Groomings.Any(e => e.GroomId == id);
        }
    }
}
