using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniClub.Domain.Common;
using UniClub.Domain.Common.Interfaces;
using UniClub.Domain.Entities;
using UniClub.Dtos.GetWithPagination;
using UniClub.Dtos.Response;

namespace UniClub.Razor.Pages.ClubRoles
{
    public class IndexModel : PageModel
    {
        private ISender _mediator;
        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();

        public PaginatedList<ClubRoleDto> ClubRoles { get; set; }
        [BindProperty(SupportsGet = true)]
        public GetClubRolesWithPaginationDto Dto { get; set; }

        public async Task OnGetAsync()
        {
            ClubRoles = await Mediator.Send(Dto);
        }
    }
}