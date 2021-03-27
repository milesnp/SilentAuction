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

namespace SilentAuction.Pages.Auctions
{
    public class EditModel : PageModel
    {
        private readonly SilentAuction.Data.ToolContext _context;

        public EditModel(SilentAuction.Data.ToolContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Auction Auction { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Auction = await _context.Auctions
                .Include(a => a.Organization).FirstOrDefaultAsync(m => m.ID == id);

            if (Auction == null)
            {
                return NotFound();
            }
           ViewData["OrganizationID"] = new SelectList(_context.Set<Organization>(), "ID", "CompanyName");
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

            _context.Attach(Auction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuctionExists(Auction.ID))
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

        private bool AuctionExists(int id)
        {
            return _context.Auctions.Any(e => e.ID == id);
        }
    }
}
