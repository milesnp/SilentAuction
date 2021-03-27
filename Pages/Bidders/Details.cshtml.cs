using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SilentAuction.Data;
using SilentAuction.Models;

namespace SilentAuction.Pages.Bidders
{
    public class DetailsModel : PageModel
    {
        private readonly SilentAuction.Data.ToolContext _context;

        public DetailsModel(SilentAuction.Data.ToolContext context)
        {
            _context = context;
        }

        public Bidder Bidder { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Bidder = await _context.Bidders.FirstOrDefaultAsync(m => m.ID == id);

            if (Bidder == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
