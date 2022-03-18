using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using UniClub.Dtos.Delete;
using UniClub.Dtos.GetById;
using UniClub.Dtos.Response;
using UniClub.Dtos.Update;

namespace UniClub.Razor.Pages.ClubRoles
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

        [BindProperty]
        public ClubRoleDto ClubRole { get; set; }

        [BindProperty]
        public ClubRoleDto ReportToClubRole { get; set; }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            GetClubRoleByIdDto dto = new GetClubRoleByIdDto(id.Value);
            ClubRole = await Mediator.Send(dto);

            if (ClubRole != null)
            {
                DeleteClubRoleDto delete = new DeleteClubRoleDto(id.Value);
                await Mediator.Send(delete);
            }

            return RedirectToPage("./Index");
        }
    }
}
