using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Forum.Data;
using Forum.Models;

namespace Forum.Pages.CRUD
{
    public class EditForumModel : PageModel
    {
        private readonly Forum.Data.ApplicationDbContext _context;

        public EditForumModel(Forum.Data.ApplicationDbContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            ForumIndex.Created = DateTime.Now;
            _context.Attach(ForumIndex).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ForumIndexExists(ForumIndex.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("../Forum");
        }

        private bool ForumIndexExists(int id)
        {
            return _context.Forums.Any(e => e.Id == id);
        }
    }
}
