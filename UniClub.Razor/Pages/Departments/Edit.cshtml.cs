using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Threading.Tasks;
using UniClub.Dtos.Create;
using UniClub.Dtos.GetById;
using UniClub.Dtos.GetWithPagination;
using UniClub.Dtos.Update;

namespace UniClub.Razor.Pages.Departments
{
    public class EditModel : PageModel
    {
        private ISender _mediator;
        private readonly IMapper _mapper;

        [BindProperty(SupportsGet = true)]
        public GetUniversitiesWithPaginationDto Dto { get; set; }

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
            GetDepartmentByIdDto dto = new GetDepartmentByIdDto(id.Value);
            Department = _mapper.Map<UpdateDepartmentDto>(await Mediator.Send(dto));

            if (Department == null)
            {
                return NotFound();
            }

            var universities = await Mediator.Send(Dto);
            var universitiesAvailable = universities.Items.Where(uni => uni.IsDeleted == false).ToList();
            ViewData["UniId"] = new SelectList(universitiesAvailable, "Id", "UniName");

            return Page();
        }

        [BindProperty]
        public UpdateDepartmentDto Department { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await Mediator.Send(Department);

            return RedirectToPage("./Index");
        }
    }
}
