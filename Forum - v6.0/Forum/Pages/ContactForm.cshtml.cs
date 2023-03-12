using Forum.Data;
using Forum.Interface;
using Forum.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;

namespace Forum.Pages
{
    public class ContactFormModel : PageModel
    {
        private readonly ICommentService _commentService;
        private readonly ApplicationDbContext _applicationDbContext;

        public ContactFormModel(ICommentService commentService, ApplicationDbContext context)
        {
            _commentService = commentService;
            _applicationDbContext = context;
        }

        [BindProperty] public string? From { get; set; }
        [BindProperty] public string? Subject { get; set; }
        [BindProperty] public string? Message { get; set; }

        public async Task<IActionResult> OnPost()
        {
            var contactUs = new ContactUs();

            if (From != null && Subject != null && Message != null)
            {
                contactUs.From = From;
                contactUs.Subject = Subject;
                contactUs.Message = Message;

                _applicationDbContext.ContactUs.Add(contactUs);

                await _applicationDbContext.SaveChangesAsync();
                await _commentService.Send(From, Subject, Message);
            }
            else
            {
                return NotFound();
            }
            return RedirectToPage("Tanks");
        }
    }
}
