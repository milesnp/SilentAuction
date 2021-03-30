using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SilentAuction.Data;
using SilentAuction.Models;

namespace SilentAuction.Pages.WinningBids
{
    public class EditModel : PageModel
    {
        private readonly SilentAuction.Data.ToolContext _context;

        public SelectList Status { get; set; }

        public EditModel(SilentAuction.Data.ToolContext context)
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
           ViewData["BidderID"] = new SelectList(_context.Bidders, "ID", "FullName");
           ViewData["DonationSpecialistID"] = new SelectList(_context.DonationSpecialists, "ID", "FullName");
           ViewData["ItemID"] = new SelectList(_context.Items, "ItemID", "ShortName");

            Status = new SelectList(Enum.GetNames(typeof(Models.BidStatus)), WinningBid.BidStatus);

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(WinningBid).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WinningBidExists(WinningBid.ItemID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool WinningBidExists(int id)
        {
            return _context.WinningBids.Any(e => e.ItemID == id);
        }
    }
}
