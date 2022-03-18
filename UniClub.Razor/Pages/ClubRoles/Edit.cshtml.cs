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

namespace UniClub.Razor.Pages.ClubRoles
{
    public class EditModel : PageModel
    {
        private ISender _mediator;
        private readonly IMapper _mapper;

        [BindProperty(SupportsGet = true)]
        public GetClubRolesWithPaginationDto ClubRoleDto { get; set; }

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
            GetClubRoleByIdDto dto = new GetClubRoleByIdDto(id.Value);
            ClubRole = _mapper.Map<UpdateClubRoleDto>(await Mediator.Send(dto));

            if (ClubRole == null)
            {
                return NotFound();
            }

            var reportClubRoles = await Mediator.Send(ClubRoleDto);
            ViewData["ReportClubRoleId"] = new SelectList(reportClubRoles.Items, "Id", "Role");

            return Page();
        }

        [BindProperty]
        public UpdateClubRoleDto ClubRole { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await Mediator.Send(ClubRole);

            return RedirectToPage("./Index");
        }
    }
}
