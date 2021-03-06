using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SilentAuction.Data;
using SilentAuction.Models;

namespace SilentAuction.Pages.WinningBids
{
    public class DetailsModel : PageModel
    {
        private readonly SilentAuction.Data.ToolContext _context;

        public DetailsModel(SilentAuction.Data.ToolContext context)
        {
            _context = context;
        }

        public WinningBid WinningBid { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            WinningBid = await _context.WinningBids
                .Include(w => w.Bidder)
                .Include(w => w.DonationSpecialist)
                .Include(w => w.Item).FirstOrDefaultAsync(m => m.ItemID == id);

            if (WinningBid == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
