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
    public class IndexModel : PageModel
    {
        private readonly PethouseWeb.Models.pethouseContext _context;

        public IndexModel(PethouseWeb.Models.pethouseContext context)
        {
            _context = context;
        }

        public IList<Race> Race { get;set; }

        public async Task OnGetAsync()
        {
            Race = await _context.Races.ToListAsync();
        }
    }
}
