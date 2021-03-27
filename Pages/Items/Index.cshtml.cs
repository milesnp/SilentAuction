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
    public class IndexModel : PageModel
    {
        private readonly SilentAuction.Data.ToolContext _context;

        public IndexModel(SilentAuction.Data.ToolContext context)
        {
            _context = context;
        }

        public IList<Item> Item { get;set; }

        public async Task OnGetAsync()
        {
            Item = await _context.Items
                .Include(i => i.Auction)
                .Include(i => i.Donor).ToListAsync();
        }
    }
}
