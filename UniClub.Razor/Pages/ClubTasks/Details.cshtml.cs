using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using UniClub.Dtos.GetById;
using UniClub.Dtos.Response;
using UniClub.Dtos.Update;

namespace UniClub.Razor.Pages.ClubTasks
{
    public class DetailsModel : PageModel
    {
        private ISender _mediator;
        private readonly IMapper _mapper;

        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
        public DetailsModel(IMapper mapper)
        {
            _mapper = mapper;
        }
        [BindProperty]
        public ClubTaskDto ClubTask { get; set; }

        [BindProperty]
        public EventDto Event { get; set; }

        public async Task<IActionResult> OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            GetClubTaskByIdDto dto = new GetClubTaskByIdDto(id.Value);
            ClubTask = await Mediator.Send(dto);
            if (ClubTask == null)
            {
                return NotFound();
            }

            GetEventByIdDto UniDto = new GetEventByIdDto(ClubTask.EventId);
            Event = await Mediator.Send(UniDto);

            return Page();
        }


    }
}
