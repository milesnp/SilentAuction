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
    public class IndexModel : PageModel
    {
        private readonly SilentAuction.Data.ToolContext _context;

        public IndexModel(SilentAuction.Data.ToolContext context)
        {
            _context = context;
        }

        public IList<WinningBid> WinningBid { get;set; }

        public async Task OnGetAsync()
        {
            WinningBid = await _context.WinningBids
                .Include(w => w.Bidder)
                .Include(w => w.DonationSpecialist)
                .Include(w => w.Item).ToListAsync();
        }
    }
}
