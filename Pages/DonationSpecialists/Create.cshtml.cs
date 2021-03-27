using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SilentAuction.Data;
using SilentAuction.Models;

namespace SilentAuction.Pages.DonationSpecialists
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
            return Page();
        }

        [BindProperty]
        public DonationSpecialist DonationSpecialist { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.DonationSpecialists.Add(DonationSpecialist);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
