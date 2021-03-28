using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SilentAuction.Data;
using SilentAuction.Models;

namespace SilentAuction.Pages.Items
{
    public class DetailsModel : PageModel
    {
        private readonly SilentAuction.Data.ToolContext _context;

        public DetailsModel(SilentAuction.Data.ToolContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
