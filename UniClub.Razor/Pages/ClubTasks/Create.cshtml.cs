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
using System;

namespace UniClub.Razor.Pages.ClubTasks
{
    public class CreateModel : PageModel
    {
        private ISender _mediator;
        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
        public string Message { get; set; }
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
            try
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }

                if (Dto.StartDate > Dto.EndDate)
                {
                    throw new Exception("StartDate must be before EndDate");
                }

                await Mediator.Send(ClubTask);

                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                Message.Replace("--", "--\n");
                return Page();
            }
        }
    }
}
