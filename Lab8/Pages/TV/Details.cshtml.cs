using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lab8.Data;
using Lab8.Models;

namespace Lab8.Pages.TV
{
    public class DetailsModel : PageModel
    {
        private readonly Lab8.Data.Lab8Context _context;

        public DetailsModel(Lab8.Data.Lab8Context context)
        {
            _context = context;
        }

      public Shows Shows { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Shows == null)
            {
                return NotFound();
            }

            var shows = await _context.Shows.FirstOrDefaultAsync(m => m.Id == id);
            if (shows == null)
            {
                return NotFound();
            }
            else 
            {
                Shows = shows;
            }
            return Page();
        }
    }
}
