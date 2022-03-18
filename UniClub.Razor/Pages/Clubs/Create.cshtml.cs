using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
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

        [BindProperty]
        public CreateClubDto Club { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (UniId == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Club.UniId = UniId.Value;
            await Mediator.Send(Club);

            return RedirectToPage("./Index?uniId", UniId);
        }
    }
}
