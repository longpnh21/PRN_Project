using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using UniClub.Dtos.GetById;
using UniClub.Dtos.Response;
using UniClub.Dtos.Update;

namespace UniClub.Razor.Pages.Departments
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
        public DepartmentDto Department { get; set; }

        [BindProperty]
        public UniversityDto University { get; set; }

        public async Task<IActionResult> OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            GetDepartmentByIdDto dto = new GetDepartmentByIdDto(id.Value);
            Department = await Mediator.Send(dto);
            if (Department == null)
            {
                return NotFound();
            }

            GetUniversityByIdDto UniDto = new GetUniversityByIdDto(Department.UniId);
            University = await Mediator.Send(UniDto);

            return Page();
        }


    }
}
