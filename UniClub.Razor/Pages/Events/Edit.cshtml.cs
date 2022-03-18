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

namespace UniClub.Razor.Pages.Events
{
    public class EditModel : PageModel
    {
        private ISender _mediator;
        private readonly IMapper _mapper;


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
            GetEventByIdDto dto = new GetEventByIdDto(id.Value);
            Event = _mapper.Map<UpdateEventDto>(await Mediator.Send(dto));

            if (Event == null)
            {
                return NotFound();
            }

            return Page();
        }

        [BindProperty]
        public UpdateEventDto Event { get; set; }
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
