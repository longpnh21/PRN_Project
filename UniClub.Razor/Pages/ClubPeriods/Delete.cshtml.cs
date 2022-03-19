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

namespace UniClub.Razor.Pages.ClubPeriods
{
    [AuthorizationFilter(Roles = "SchoolAdmin")]
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
            GetClubPeriodByIdDto dto = new GetClubPeriodByIdDto(id.Value);
            ClubPeriod = await Mediator.Send(dto);

            if (ClubPeriod == null)
            {
                return NotFound();
            }
            return Page();
        }

        [BindProperty]
        public ClubPeriodDto ClubPeriod { get; set; }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || id < 1)
            {
                return NotFound();
            }

            DeleteClubPeriodDto delete = new DeleteClubPeriodDto(id.Value);
            await Mediator.Send(delete);

            return RedirectToPage("./Index", new { clubId = ClubPeriod.ClubId });
        }
    }
}
