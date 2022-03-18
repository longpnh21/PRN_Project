using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using UniClub.Dtos.Create;

namespace UniClub.Razor.Pages.Clubs
{
    public class CreateModel : PageModel
    {
        private ISender _mediator;
        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();

        public IActionResult OnGet()
        {
            if (UniId == null)
            {
                return NotFound();
            }
            return Page();
        }
        [BindProperty(SupportsGet = true)]
        public int? UniId { get; set; }
        public string Message { get; set; }

        [BindProperty]
        public CreateClubDto Club { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (UniId == null || UniId < 1)
                {
                    return NotFound();
                }
                if (!ModelState.IsValid)
                {
                    return Page();
                }
                Club.UniId = UniId.Value;
                await Mediator.Send(Club);

                return RedirectToPage("./Index", new { uniId = UniId });
            }
            catch (Exception e)
            {
                Message = e.Message;
                Message.Replace("--", "--\n");
                return Page();
            }
        }
    }
}
