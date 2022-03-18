using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using UniClub.Dtos.GetById;
using UniClub.Dtos.Response;

namespace UniClub.Razor.Pages.Universities
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
        public UniversityDto University { get; set; }
        public async Task<IActionResult> OnGet(int? id)
        {
            if (id == null || id < 1)
            {
                return NotFound();
            }
            GetUniversityByIdDto dto = new GetUniversityByIdDto(id.Value);
            University = await Mediator.Send(dto);
            if (University == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
