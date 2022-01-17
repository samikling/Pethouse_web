#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PethouseWeb.Models;

namespace PethouseWeb.Pages.Medications
{
    public class DetailsModel : PageModel
    {
        private readonly PethouseWeb.Models.pethouseContext _context;

        public DetailsModel(PethouseWeb.Models.pethouseContext context)
        {
            _context = context;
        }

        public Medication Medication { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Medication = await _context.Medications
                .Include(m => m.Pet).FirstOrDefaultAsync(m => m.MedId == id);

            if (Medication == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
