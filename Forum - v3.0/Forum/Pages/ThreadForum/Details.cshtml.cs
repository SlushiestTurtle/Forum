using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Forum.Data;
using Forum.Models;

namespace Forum.Pages.ThreadForum
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

      public ForumThread ForumThread { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.ForumThread == null)
            {
                return NotFound();
            }

            var forumthread = await _context.ForumThread.FirstOrDefaultAsync(m => m.Id == id);
            if (forumthread == null)
            {
                return NotFound();
            }
            else 
            {
                ForumThread = forumthread;
            }
            return Page();
        }
    }
}
