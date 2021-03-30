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
    public class DeleteModel : PageModel
    {
        private readonly SilentAuction.Data.ToolContext _context;

        public DeleteModel(SilentAuction.Data.ToolContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            WinningBid = await _context.WinningBids.FindAsync(id);

            if (WinningBid != null)
            {
                _context.WinningBids.Remove(WinningBid);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
