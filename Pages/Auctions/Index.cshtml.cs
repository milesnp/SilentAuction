using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SilentAuction.Data;
using SilentAuction.Models;

namespace SilentAuction.Pages.Auctions
{
    public class IndexModel : PageModel
    {
        private readonly SilentAuction.Data.ToolContext _context;

        public IndexModel(SilentAuction.Data.ToolContext context)
        {
            _context = context;
        }

        public IList<Auction> Auction { get;set; }

        public async Task OnGetAsync()
        {
            Auction = await _context.Auctions
                .Include(a => a.Organization).ToListAsync();
        }
    }
}
