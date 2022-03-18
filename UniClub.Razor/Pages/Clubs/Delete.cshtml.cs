using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using UniClub.Dtos.Delete;
using UniClub.Dtos.GetById;
using UniClub.Dtos.Response;

namespace UniClub.Razor.Pages.Clubs
{
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
            GetClubByIdDto dto = new GetClubByIdDto(id.Value);
            Club = await Mediator.Send(dto);

            if (Club == null)
            {
                return NotFound();
            }
            return Page();
        }

        [BindProperty]
        public ClubDto Club { get; set; }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || id < 1)
            {
                return NotFound();
            }

            DeleteClubDto delete = new DeleteClubDto(id.Value);
            await Mediator.Send(delete);

            return RedirectToPage("./Index", new { uniId = Club.UniId });
        }
    }
}
