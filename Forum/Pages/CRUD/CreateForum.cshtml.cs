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

namespace Forum.Pages.CRUD
{
    public class CreateForumModel : PageModel
    {
        private readonly Forum.Data.ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CreateForumModel(Forum.Data.ApplicationDbContext context,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ForumIndex ForumIndex { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            ForumIndex.Created = DateTime.Now;

            _context.Forums.Add(ForumIndex);
            await _context.SaveChangesAsync();

            return RedirectToPage("../Forum");
        }
    }
}
