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
    public class IndexModel : PageModel
    {
        private readonly PethouseWeb.Models.pethouseContext _context;

        public IndexModel(PethouseWeb.Models.pethouseContext context)
        {
            _context = context;
        }

        public IList<Pet> Pet { get;set; }

        public async Task OnGetAsync()
        {
            Pet = await _context.Pets
                .Include(p => p.Breed)
                .Include(p => p.Race)
                .Include(p => p.User).ToListAsync();
        }
    }
}
