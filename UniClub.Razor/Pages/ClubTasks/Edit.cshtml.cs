using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using UniClub.Dtos.Create;
using UniClub.Dtos.GetById;
using UniClub.Dtos.GetWithPagination;
using UniClub.Dtos.Update;

namespace UniClub.Razor.Pages.ClubTasks
{
    public class EditModel : PageModel
    {
        private ISender _mediator;
        private readonly IMapper _mapper;

        [BindProperty(SupportsGet = true)]
        public GetEventsWithPaginationDto Dto { get; set; }

        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
        public EditModel(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<IActionResult> OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            GetClubTaskByIdDto dto = new GetClubTaskByIdDto(id.Value);
            ClubTask = _mapper.Map<UpdateClubTaskDto>(await Mediator.Send(dto));

            if (ClubTask == null)
            {
                return NotFound();
            }

            var events = await Mediator.Send(Dto);
            var eventsAvailable = events.Items.Where(e => e.IsDeleted == false).ToList();
            ViewData["EventId"] = new SelectList(eventsAvailable, "Id", "EventName");

            return Page();
        }

        [BindProperty]
        public UpdateClubTaskDto ClubTask { get; set; }
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
