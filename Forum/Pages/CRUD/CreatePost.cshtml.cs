using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Forum.Data;
using Forum.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace Forum.Pages.CRUD
{
    public class CreatePostModel : PageModel
    {
        private readonly Forum.Data.ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CreatePostModel(Forum.Data.ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task OnGetAsync()
        {
            var forum = await _context.Forums.ToListAsync();
            selectListItems = forum.Select(x => new SelectListItem() { Text= x.Title, Value= x.Id.ToString() }).ToList();

            //var database = new SelectList(await _context.Forums.ToListAsync(), "Id", "Title");       
            //ViewData["Forum"] = database;
        }
        

        [BindProperty]
        public Post Post { get; set; }

        [BindProperty]
        public string id { get; set; }
        public ForumIndex forumid { get; set; }
        public List<SelectListItem> selectListItems { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var findForum = await _context.Forums.FindAsync(Int32.Parse(id));
            var findUser = await _userManager.FindByIdAsync(userId);
            if (!ModelState.IsValid)
            {
                Post.Forum = findForum;
                Post.User = findUser;
            }
            Console.WriteLine(selectListItems);
            //Post = new Post();

            Post.Created = DateTime.Now;
            _context.Posts.Add(Post);
            await _context.SaveChangesAsync();

            return RedirectToPage("../Forum");
        }
    }
}
