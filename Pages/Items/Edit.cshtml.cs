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

namespace SilentAuction.Pages.Items
{
    public class EditModel : PageModel
    {
        private readonly SilentAuction.Data.ToolContext _context;

        public EditModel(SilentAuction.Data.ToolContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Item Item { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Item = await _context.Items
                .Include(i => i.Auction)
                .Include(i => i.DonationSpecialist)
                .Include(i => i.Donor).FirstOrDefaultAsync(m => m.ItemID == id);

            if (Item == null)
            {
                return NotFound();
            }
           ViewData["AuctionID"] = new SelectList(_context.Auctions, "ID", "AuctionName");
           ViewData["DonationSpecialistID"] = new SelectList(_context.DonationSpecialists, "ID", "FirstName");
           ViewData["DonorID"] = new SelectList(_context.Organizations, "ID", "CompanyName");
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

            _context.Attach(Item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExists(Item.ItemID))
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

        private bool ItemExists(int id)
        {
            return _context.Items.Any(e => e.ItemID == id);
        }
    }
}
