using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using UniClub.Dtos.GetById;
using UniClub.Dtos.Response;
using UniClub.Dtos.Update;

namespace UniClub.Razor.Pages.Events
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
        public EventDto Event { get; set; }

        public async Task<IActionResult> OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            GetEventByIdDto dto = new GetEventByIdDto(id.Value);
            Event = await Mediator.Send(dto);
            if (Event == null)
            {
                return NotFound();
            }

            return Page();
        }


    }
}
