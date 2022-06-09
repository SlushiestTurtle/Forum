using Forum.Data;
using Forum.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.Pages
{
    public class PostModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public PostModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Post> Posts { get; set; }

        public int forumId { get; set; }

        public async Task OnGetAsync(int id)
        {
            ForumIndex forumChoice = await _context.Forums.FindAsync(id);
            Posts = new List<Post>();
            var posts = await _context.Posts.ToListAsync();
            if (ModelState.IsValid)
            {
                foreach (var item in posts)
                {
                    if (item.Forum == forumChoice)
                    {
                        Posts.Add(item);
                    }
                }
            }
        }
    }
}
