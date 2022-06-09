using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Forum.Data;
using Forum.Models;

namespace Forum.Pages.CRUD
{
    public class DeleteForumModel : PageModel
    {
        private readonly Forum.Data.ApplicationDbContext _context;

        public DeleteForumModel(Forum.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ForumIndex ForumIndex { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ForumIndex = await _context.Forums.FirstOrDefaultAsync(m => m.Id == id);

            if (ForumIndex == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ForumIndex = await _context.Forums.FindAsync(id);

            if (ForumIndex != null)
            {
                _context.Forums.Remove(ForumIndex);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("../Forum");
        }
    }
}
