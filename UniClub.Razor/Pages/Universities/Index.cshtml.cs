using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using UniClub.Domain.Common;
using UniClub.Dtos.GetWithPagination;
using UniClub.Dtos.Response;
using UniClub.Razor.Filters;

namespace UniClub.Razor.Pages.Universities
{
    [AuthorizationFilter(Roles = "SystemAdministrator")]
    public class IndexModel : PageModel
    {
        private ISender _mediator;
        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();

        public PaginatedList<UniversityDto> Universities { get; set; }
        [BindProperty(SupportsGet = true)]
        public GetUniversitiesWithPaginationDto Dto { get; set; }

        public async Task OnGetAsync()
        {
            Universities = await Mediator.Send(Dto);
        }
    }
}
