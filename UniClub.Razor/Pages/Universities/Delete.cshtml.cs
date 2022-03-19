using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using UniClub.Dtos.Delete;
using UniClub.Dtos.GetById;
using UniClub.Dtos.Response;
using UniClub.Razor.Filters;

namespace UniClub.Razor.Pages.Universities
{
    [AuthorizationFilter(Roles = "SystemAdministrator")]
    public class DeleteModel : PageModel
    {
        private ISender _mediator;
        private readonly IMapper _mapper;

        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
        public DeleteModel(IMapper mapper)
        {
            _mapper = mapper;
        }
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

        [BindProperty]
        public UniversityDto University { get; set; }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || id < 1)
            {
                return NotFound();
            }

            DeleteUniversityDto delete = new DeleteUniversityDto(id.Value);
            await Mediator.Send(delete);

            return RedirectToPage("./Index");
        }
    }
}
