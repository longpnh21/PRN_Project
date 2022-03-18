using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using UniClub.Dtos.Create;
using UniClub.Dtos.GetById;
using UniClub.Dtos.Update;

namespace UniClub.Razor.Pages.Universities
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
            GetUniversityByIdDto dto = new GetUniversityByIdDto(id.Value);
            University = _mapper.Map<UpdateUniversityDto>(await Mediator.Send(dto));

            if (University == null)
            {
                return NotFound();
            }
            return Page();
        }

        [BindProperty]
        public UpdateUniversityDto University { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await Mediator.Send(University);

            return RedirectToPage("./Index");
        }
    }
}
