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
    public class IndexModel : PageModel
    {
        private readonly Lab8.Data.Lab8Context _context;

        public IndexModel(Lab8.Data.Lab8Context context)
        {
            _context = context;
        }

        public IList<Shows> Shows { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Shows != null)
            {
                Shows = await _context.Shows.ToListAsync();
            }
        }
    }
}
