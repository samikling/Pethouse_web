#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PethouseWeb.Models;

namespace PethouseWeb.Pages.Races
{
    public class DetailsModel : PageModel
    {
        private readonly PethouseWeb.Models.pethouseContext _context;

        public DetailsModel(PethouseWeb.Models.pethouseContext context)
        {
            _context = context;
        }

        public Race Race { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Race = await _context.Races.FirstOrDefaultAsync(m => m.RaceId == id);

            if (Race == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
