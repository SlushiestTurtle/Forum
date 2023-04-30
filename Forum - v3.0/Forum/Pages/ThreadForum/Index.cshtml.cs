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
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<ForumThread> ForumThread { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.ForumThread != null)
            {
                ForumThread = await _context.ForumThread.ToListAsync();
            }
        }
    }
}
