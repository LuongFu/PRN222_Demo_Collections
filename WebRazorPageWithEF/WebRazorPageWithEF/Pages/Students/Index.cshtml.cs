using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebRazorPageWithEF.Pages.Models;

namespace WebRazorPageWithEF.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly WebRazorPageWithEF.Pages.Models.RazorPagesLabDbContext _context;

        public IndexModel(WebRazorPageWithEF.Pages.Models.RazorPagesLabDbContext context)
        {
            _context = context;
        }

        public IList<Student> Student { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Student = await _context.Students.ToListAsync();
        }
    }
}
