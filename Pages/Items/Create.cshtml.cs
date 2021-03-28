using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SilentAuction.Data;
using SilentAuction.Models;

namespace SilentAuction.Pages.Items
{
    public class CreateModel : PageModel
    {
        private readonly SilentAuction.Data.ToolContext _context;

        public CreateModel(SilentAuction.Data.ToolContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["AuctionID"] = new SelectList(_context.Auctions, "ID", "AuctionName");
        ViewData["DonationSpecialistID"] = new SelectList(_context.DonationSpecialists, "ID", "FirstName");
        ViewData["DonorID"] = new SelectList(_context.Organizations, "ID", "CompanyName");
            return Page();
        }

        [BindProperty]
        public Item Item { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Items.Add(Item);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
