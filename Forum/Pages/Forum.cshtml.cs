using Forum.Data;
using Forum.Models;
using Forum.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Pages
{
    
    public class ForumModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ForumModel> _logger;

        public ForumModel(ILogger<ForumModel> logger,
            ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IList<ForumIndex> Forums { get; set; }

        public async Task OnGetAsync()
        {
            Forums = await _context.Forums.ToListAsync();
        }
    }
}
