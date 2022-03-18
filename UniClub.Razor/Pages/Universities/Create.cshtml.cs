using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using UniClub.Dtos.Create;

namespace UniClub.Razor.Pages.Universities
{
    public class CreateModel : PageModel
    {
        private ISender _mediator;
        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CreateUniversityDto University { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await Mediator.Send(University);

            return RedirectToPage("./Index");
        }
    }
}
