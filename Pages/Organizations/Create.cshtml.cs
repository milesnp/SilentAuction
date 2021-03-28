using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SilentAuction.Data;
using SilentAuction.Models;

namespace SilentAuction.Pages.Organizations
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
        ViewData["DonationSpecialistID"] = new SelectList(_context.DonationSpecialists, "ID", "FullName");
            return Page();
        }

        [BindProperty]
        public Organization Organization { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Organizations.Add(Organization);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
