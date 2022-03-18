using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniClub.Dtos.Create;
using UniClub.Dtos.GetWithPagination;
using UniClub.Dtos.Response;

namespace UniClub.Razor.Pages.Events
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
        public CreateEventDto Event { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await Mediator.Send(Event);

            return RedirectToPage("./Index");
        }
    }
}
