using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using UniClub.Dtos.GetById;
using UniClub.Dtos.GetWithPagination;
using UniClub.Dtos.Response;
using UniClub.Dtos.Update;

namespace UniClub.Razor.Pages.ClubRoles
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
        public ClubRoleDto ClubRole { get; set; }

        [BindProperty]
        public ClubRoleDto ReportToClubRole { get; set; }

        public async Task<IActionResult> OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            GetClubRoleByIdDto dto = new GetClubRoleByIdDto(id.Value);
            ClubRole = await Mediator.Send(dto);
            if (ClubRole == null)
            {
                return NotFound();
            }

            GetClubRoleByIdDto reportDto = new GetClubRoleByIdDto(id.Value);
            ReportToClubRole = await Mediator.Send(dto);

            return Page();
        }


    }
}
