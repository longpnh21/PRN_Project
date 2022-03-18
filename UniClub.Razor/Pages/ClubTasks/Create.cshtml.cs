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
using System.Linq;

namespace UniClub.Razor.Pages.ClubTasks
{
    public class CreateModel : PageModel
    {
        private ISender _mediator;
        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();

        [BindProperty(SupportsGet = true)]
        public GetEventsWithPaginationDto Dto { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var events = await Mediator.Send(Dto);
            ViewData["EventId"] = new SelectList(events.Items, "Id", "EventName");
            return Page();
        }

        [BindProperty]
        public CreateClubTaskDto ClubTask { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await Mediator.Send(ClubTask);

            return RedirectToPage("./Index");
        }
    }
}
