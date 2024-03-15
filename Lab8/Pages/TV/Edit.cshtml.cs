using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab8.Data;
using Lab8.Models;

namespace Lab8.Pages.TV
{
    public class EditModel : PageModel
    {
        private readonly Lab8.Data.Lab8Context _context;

        public EditModel(Lab8.Data.Lab8Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Shows Shows { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Shows == null)
            {
                return NotFound();
            }

            var shows =  await _context.Shows.FirstOrDefaultAsync(m => m.Id == id);
            if (shows == null)
            {
                return NotFound();
            }
            Shows = shows;
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

            _context.Attach(Shows).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShowsExists(Shows.Id))
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

        private bool ShowsExists(int id)
        {
          return (_context.Shows?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
