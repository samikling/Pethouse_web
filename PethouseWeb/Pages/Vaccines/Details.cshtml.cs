#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PethouseWeb.Models;

namespace PethouseWeb.Pages.Vaccines
{
    public class DetailsModel : PageModel
    {
        private readonly PethouseWeb.Models.pethouseContext _context;

        public DetailsModel(PethouseWeb.Models.pethouseContext context)
        {
            _context = context;
        }

        public Vaccine Vaccine { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Vaccine = await _context.Vaccines
                .Include(v => v.Pet).FirstOrDefaultAsync(m => m.VacId == id);

            if (Vaccine == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
