#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PethouseWeb.Models;

namespace PethouseWeb.Pages.Pets
{
    public class DetailsModel : PageModel
    {
        private readonly PethouseWeb.Models.pethouseContext _context;

        public DetailsModel(PethouseWeb.Models.pethouseContext context)
        {
            _context = context;
        }

        public Pet Pet { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Pet = await _context.Pets
                .Include(p => p.Breed)
                .Include(p => p.Race)
                .Include(p => p.User).FirstOrDefaultAsync(m => m.PetId == id);

            if (Pet == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
