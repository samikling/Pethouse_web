#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PethouseWeb.Models;

namespace PethouseWeb.Pages.Treatments
{
    public class DeleteModel : PageModel
    {
        private readonly PethouseWeb.Models.pethouseContext _context;

        public DeleteModel(PethouseWeb.Models.pethouseContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Grooming = await _context.Groomings.FindAsync(id);

            if (Grooming != null)
            {
                _context.Groomings.Remove(Grooming);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
