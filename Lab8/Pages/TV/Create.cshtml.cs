using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Lab8.Data;
using Lab8.Models;

namespace Lab8.Pages.TV
{
    public class CreateModel : PageModel
    {
        private readonly Lab8.Data.Lab8Context _context;

        public CreateModel(Lab8.Data.Lab8Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Shows Shows { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Shows == null || Shows == null)
            {
                return Page();
            }

            _context.Shows.Add(Shows);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
