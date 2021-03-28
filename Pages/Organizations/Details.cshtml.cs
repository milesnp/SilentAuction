using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SilentAuction.Data;
using SilentAuction.Models;

namespace SilentAuction.Pages.Organizations
{
    public class DetailsModel : PageModel
    {
        private readonly SilentAuction.Data.ToolContext _context;

        public DetailsModel(SilentAuction.Data.ToolContext context)
        {
            _context = context;
        }

        public Organization Organization { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Organization = await _context.Organizations
                .Include(o => o.DonationSpecialist).FirstOrDefaultAsync(m => m.ID == id);

            if (Organization == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
